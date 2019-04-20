using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Solution
{
    public interface IPushToPullStream : IDisposable
    {
        Stream PushStream { get; }
        Stream PullStream { get; }
        void CompleteWrite();
    }
}

namespace Solution
{
    public abstract class StreamBase : Stream
    {
        protected long _position;
        public override bool CanSeek { get; } = false;
        public override bool CanRead { get; } = false;
        public override bool CanWrite { get; } = false;
        public override long Length { get; }

        public override long Position
        {
            get => _position;
            set
            {
                if (_position != value) throw new NotSupportedException();
            }
        }

        public override void Flush() { }
        public override long Seek(long offset, SeekOrigin origin) =>
            throw new System.NotSupportedException();
        public override void SetLength(long value) =>
            throw new System.NotSupportedException();
        public override int Read(byte[] buffer, int offset, int count) =>
            throw new NotSupportedException();
        public override void Write(byte[] buffer, int offset, int count) =>
            throw new NotSupportedException();
    }

    public class PushStreamImpl : StreamBase
    {
        public PushToPullStream Owner { get; }
        public override bool CanWrite => true;

        public PushStreamImpl(PushToPullStream owner) => Owner = owner;

        public override void Write(byte[] buffer, int offset, int count) =>
            Task.Run(() => WriteAsync(buffer, offset, count, CancellationToken.None)).Wait();

        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            // Implement this method
            throw new NotImplementedException();
        }
    }

    public class PullStreamImpl : StreamBase
    {
        public PushToPullStream Owner { get; }
        public override bool CanRead => true;

        public PullStreamImpl(PushToPullStream owner) => Owner = owner;

        public override int Read(byte[] buffer, int offset, int count) =>
            Task.Run(() => ReadAsync(buffer, offset, count, CancellationToken.None)).Result;

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count,
            CancellationToken cancellationToken)
        {
            // Implement this method
            throw new NotImplementedException();
        }
    }

    public class PushToPullStream : IPushToPullStream
    {
        public const int DefaultBufferSize = 8192;

        // You may declare the buffer elsewhere, but the important part about it is:
        // you should design your impl. in such a way this buffer is never exceeded.
        // I.e. if a writer (the code using PushStream) tries to write more data you
        // can actually buffer, it has to wait.
        public byte[] Buffer { get; set; }
        public Stream PushStream { get; protected set; }
        public Stream PullStream { get; protected set; }

        public PushToPullStream(int bufferSize = DefaultBufferSize)
        {
            Buffer = new byte[bufferSize];
            PushStream = new PushStreamImpl(this);
            PullStream = new PullStreamImpl(this);
        }

        public virtual void CompleteWrite()
        {
            // Implement this method
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            PushStream?.Dispose();
            PushStream = null;
            PullStream?.Dispose();
            PullStream = null;
        }
    }
}

namespace Solution
{
    public class Solution
    {
        public static void Main()
        {
            var tester = new PushToPullStreamTester()
            {
                PushToPullFactory = () => new PushToPullStream(100)
            };
            tester.Test();
            Console.WriteLine("Test passed.");
        }
    }

    public class PushToPullStreamTester
    {
        public Func<IPushToPullStream> PushToPullFactory { get; set; }
        public Random Random1 { get; set; } = new Random(12345);
        public Random Random2 { get; set; } = new Random(54321);

        public void Test()
        {
            for (var l = 0; l < 100; l++)
                for (var s = 1; s <= 8; s <<= 1)
                    TestOne(l, s);
            TestOne(20000000, 8192, 0.001, 0);
            TestOne(20000000, 8192, 0, 0.001);
        }

        private void TestOne(long length, int maxChunkLength = 1024,
            double pushDelayProbability = 0,
            double pullDelayProbability = 0,
            int delayDurationInMilliseconds = 50)
        {
            using (var p2p = PushToPullFactory.Invoke())
            {
                long inputCrc = 0;
                long outputCrc = 0;

                var writerTask = Task.Run(async () => {
                    var buffer = new byte[maxChunkLength];
                    while (p2p.PushStream.Position < length)
                    {
                        var chunkSize = (int)Math.Min(
                            Random1.Next(1 + maxChunkLength),
                            length - p2p.PushStream.Position);
                        Random1.NextBytes(buffer);
                        AccumulateCrc(buffer, buffer.Length, ref inputCrc);
                        if (Random1.NextDouble() < pushDelayProbability)
                            await Task.Delay(delayDurationInMilliseconds);
                        await p2p.PushStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    p2p.CompleteWrite();
                });
                var readerTask = Task.Run(async () => {
                    var buffer = new byte[maxChunkLength];
                    var readLength = 1;
                    while (readLength > 0)
                    {
                        var chunkSize = 1 + Random2.Next(maxChunkLength);
                        if (Random1.NextDouble() < pullDelayProbability)
                            await Task.Delay(delayDurationInMilliseconds);
                        readLength = await p2p.PullStream.ReadAsync(buffer, 0, buffer.Length);
                        AccumulateCrc(buffer, readLength, ref outputCrc);
                    }
                });

                Task.WaitAll(writerTask, readerTask);
                if (inputCrc != outputCrc)
                    throw new InvalidOperationException("CRC check failed.");
            }
        }

        private void AccumulateCrc(byte[] buffer, int length, ref long crc)
        {
            unchecked
            {
                var c = crc;
                for (var i = 0; i < length; i++)
                {
                    var x = buffer[i];
                    c = 271 * c + x;
                }

                crc = c;
            }
        }
    }
}