using System.Collections.Generic;
using System.Reflection;
using System;
using ServiceTitan.ProblemOne.ArrayExtensions;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;

namespace ServiceTitan.ProblemOne
{
    public static class ObjectExtensions
    {
        private static readonly MethodInfo CloneMethod = typeof(Object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);

        public static bool IsPrimitive(this Type type)
        {
            if (type == typeof(String)) return true;
            return (type.IsValueType & type.IsPrimitive);
        }

        public static Object Copy(this Object originalObject)
        {
            return InternalCopy(originalObject, new Dictionary<Object, Object>(new ReferenceEqualityComparer()));
        }
        private static Object InternalCopy(Object originalObject, IDictionary<Object, Object> visited)
        {
            
            if (originalObject == null) return null;
            var typeToReflect = originalObject.GetType();
            if (IsPrimitive(typeToReflect)) return originalObject;
            if (visited.ContainsKey(originalObject)) return visited[originalObject];
            if (typeof(Delegate).IsAssignableFrom(typeToReflect)) return null;

            //пройтись во всем мемберам и в зависимости от атрибута сделать их копии

            var cloneObject = CloneMethod.Invoke(originalObject, null);
            if (typeToReflect.IsArray)
            {
                var arrayType = typeToReflect.GetElementType();
                if (IsPrimitive(arrayType) == false)
                {
                    Array clonedArray = (Array)cloneObject;
                    clonedArray.ForEach((array, indices) => array.SetValue(InternalCopy(clonedArray.GetValue(indices), visited), indices));
                }

            }
            visited.Add(originalObject, cloneObject);
            //CopyFields(originalObject, visited, cloneObject, typeToReflect);
            CopyProperties(originalObject, visited, cloneObject, typeToReflect);
            //RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect);
            return cloneObject;
        }

        private static void RecursiveCopyBaseTypePrivateFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect)
        {
            if (typeToReflect.BaseType != null)
            {
                RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
                CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, info => info.IsPrivate);
            }
        }

        private static void CopyFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy, Func<FieldInfo, bool> filter = null)
        {
            foreach (FieldInfo fieldInfo in typeToReflect.GetFields(bindingFlags))
            {
                if (filter != null && filter(fieldInfo) == false) continue;
                if (IsPrimitive(fieldInfo.FieldType)) continue;
                var originalFieldValue = fieldInfo.GetValue(originalObject);
                var clonedFieldValue = InternalCopy(originalFieldValue, visited);
                fieldInfo.SetValue(cloneObject, clonedFieldValue);
            }
        }
        private static void CopyProperties(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy, Func<PropertyInfo, bool> filter = null)
        {
            if (typeToReflect.IsArray || typeToReflect.IsEnumerableType()) return;
            foreach (PropertyInfo propertyInfo in typeToReflect.GetProperties(bindingFlags))
            {
                if (filter != null && filter(propertyInfo) == false) continue;
                var attr = propertyInfo.GetCustomAttribute(typeof(CloneableAttribute));
                if (attr is CloneableAttribute a)
                {
                    switch (a.Mode)
                    {
                        case CloningMode.Ignore:
                            {
                                propertyInfo.SetValue(cloneObject, null);
                                break;
                            }
                        case CloningMode.Shallow:
                            {
                                propertyInfo.SetValue(cloneObject, propertyInfo.GetValue(originalObject));
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    continue;
                }
                if (IsPrimitive(propertyInfo.PropertyType)) continue;
                var originalPropertyValue = propertyInfo.GetValue(originalObject);
                var clonedPropertyValue = InternalCopy(originalPropertyValue, visited);
                propertyInfo.SetValue(cloneObject, clonedPropertyValue);
            }
        }
        public static T Copy<T>(this T original)
        {
            return (T)Copy((Object)original);
        }

        public static CloneableAttribute GetFieldAttr<T>(this T source, Expression<Func<T, object>> field)
        {
            var member = field.Body as MemberExpression;
            if (member == null) return null; // or throw exception

            var fieldName = member.Member.Name;

            var test = typeof(T);
            var fieldType = test.GetField(fieldName);
            if (fieldType != null)
            {
                var attribute = fieldType.GetCustomAttribute<CloneableAttribute>();

                return attribute;
            }

            return null;
        }

        private static bool IsEnumerableType(this Type type)
        {
            return (type.GetInterface(nameof(IEnumerable)) != null);
        }
    }

    public class ReferenceEqualityComparer : EqualityComparer<Object>
    {
        public override bool Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }
        public override int GetHashCode(object obj)
        {
            if (obj == null) return 0;
            return obj.GetHashCode();
        }
    }

    

    namespace ArrayExtensions
    {
        public static class ArrayExtensions
        {
            public static void ForEach(this Array array, Action<Array, int[]> action)
            {
                if (array.LongLength == 0) return;
                ArrayTraverse walker = new ArrayTraverse(array);
                do action(array, walker.Position);
                while (walker.Step());
            }
        }

        internal class ArrayTraverse
        {
            public int[] Position;
            private int[] maxLengths;

            public ArrayTraverse(Array array)
            {
                maxLengths = new int[array.Rank];
                for (int i = 0; i < array.Rank; ++i)
                {
                    maxLengths[i] = array.GetLength(i) - 1;
                }
                Position = new int[array.Rank];
            }

            public bool Step()
            {
                for (int i = 0; i < Position.Length; ++i)
                {
                    if (Position[i] < maxLengths[i])
                    {
                        Position[i]++;
                        for (int j = 0; j < i; j++)
                        {
                            Position[j] = 0;
                        }
                        return true;
                    }
                }
                return false;
            }
        }
    }

}