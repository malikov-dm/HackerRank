IF OBJECT_ID('dbo.TC_Company', 'U') IS NOT NULL 
	DROP TABLE [dbo].[TC_Company]
GO

CREATE TABLE [dbo].[TC_Company](
	[company_code] [nvarchar](50) NULL,
	[founder] [nvarchar](50) NULL
)
GO

INSERT INTO [dbo].[TC_Company]([company_code], [founder]) 
	VALUES(N'C1', N'Monika')
INSERT INTO [dbo].[TC_Company]([company_code], [founder]) 
	VALUES(N'C2', N'Samantha')
GO

IF OBJECT_ID('dbo.TC_Lead_Manager', 'U') IS NOT NULL 
	DROP TABLE [dbo].[TC_Lead_Manager]
GO

CREATE TABLE [dbo].[TC_Lead_Manager](
	[lead_manager_code] [nvarchar](50) NULL,
	[company_code] [nvarchar](50) NULL
)
GO

INSERT INTO [dbo].[TC_Lead_Manager]([lead_manager_code], [company_code]) 
	VALUES(N'LM1', N'C1')
INSERT INTO [dbo].[TC_Lead_Manager]([lead_manager_code], [company_code]) 
	VALUES(N'LM2', N'C2')
GO

IF OBJECT_ID('dbo.TC_Senior_Manager ', 'U') IS NOT NULL 
	DROP TABLE [dbo].[TC_Senior_Manager]
GO

CREATE TABLE [dbo].[TC_Senior_Manager](
	[senior_manager_code] [nvarchar](50) NULL,
	[lead_manager_code] [nvarchar](50) NULL,
	[company_code] [nvarchar](50) NULL
)
GO

INSERT INTO [dbo].[TC_Senior_Manager]([senior_manager_code], [lead_manager_code], [company_code]) 
	VALUES(N'SM1', N'LM1', N'C1')
INSERT INTO [dbo].[TC_Senior_Manager]([senior_manager_code], [lead_manager_code], [company_code]) 
	VALUES(N'SM2', N'LM1', N'C1')
INSERT INTO [dbo].[TC_Senior_Manager]([senior_manager_code], [lead_manager_code], [company_code]) 
	VALUES(N'SM3', N'LM2', N'C2')
GO

IF OBJECT_ID('dbo.TC_Manager ', 'U') IS NOT NULL 
	DROP TABLE [dbo].[TC_Manager]
GO

CREATE TABLE [dbo].[TC_Manager](
	[manager_code] [nvarchar](50) NULL,
	[senior_manager_code] [nvarchar](50) NULL,
	[lead_manager_code] [nvarchar](50) NULL,
	[company_code] [nvarchar](50) NULL
)
GO

INSERT INTO [dbo].[TC_Manager]([manager_code], [senior_manager_code], [lead_manager_code], [company_code]) 
	VALUES(N'M1', N'SM1', N'LM1', N'C1')
INSERT INTO [dbo].[TC_Manager]([manager_code], [senior_manager_code], [lead_manager_code], [company_code]) 
	VALUES(N'M2', N'SM3', N'LM2', N'C2')
INSERT INTO [dbo].[TC_Manager]([manager_code], [senior_manager_code], [lead_manager_code], [company_code]) 
	VALUES(N'M3', N'SM3', N'LM2', N'C2')
GO

IF OBJECT_ID('dbo.TC_Employee ', 'U') IS NOT NULL 
	DROP TABLE [dbo].[TC_Employee]
GO

CREATE TABLE [dbo].[TC_Employee](
	[employee_code] [nvarchar](50) NULL,
	[manager_code] [nvarchar](50) NULL,
	[senior_manager_code] [nvarchar](50) NULL,
	[lead_manager_code] [nvarchar](50) NULL,
	[company_code] [nvarchar](50) NULL
)
GO

INSERT INTO [dbo].[TC_Employee]([employee_code], [manager_code], [senior_manager_code], [lead_manager_code], [company_code]) 
	VALUES(N'E1', N'M1', N'SM1', N'LM1', N'C1')
INSERT INTO [dbo].[TC_Employee]([employee_code], [manager_code], [senior_manager_code], [lead_manager_code], [company_code]) 
	VALUES(N'E2', N'M1', N'SM1', N'LM1', N'C2')
INSERT INTO [dbo].[TC_Employee]([employee_code], [manager_code], [senior_manager_code], [lead_manager_code], [company_code]) 
	VALUES(N'E3', N'M2', N'SM3', N'LM2', N'C2')
INSERT INTO [dbo].[TC_Employee]([employee_code], [manager_code], [senior_manager_code], [lead_manager_code], [company_code]) 
	VALUES(N'E4', N'M3', N'SM3', N'LM2', N'C2')
GO
