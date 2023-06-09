USE [master]
GO
/****** Object:  Database [HopitalManagerment]    Script Date: 4/5/2023 2:58:34 PM ******/
CREATE DATABASE [HopitalManagerment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HopitalManagerment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HopitalManagerment.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HopitalManagerment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HopitalManagerment_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HopitalManagerment] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HopitalManagerment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HopitalManagerment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HopitalManagerment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HopitalManagerment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HopitalManagerment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HopitalManagerment] SET ARITHABORT OFF 
GO
ALTER DATABASE [HopitalManagerment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HopitalManagerment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HopitalManagerment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HopitalManagerment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HopitalManagerment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HopitalManagerment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HopitalManagerment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HopitalManagerment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HopitalManagerment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HopitalManagerment] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HopitalManagerment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HopitalManagerment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HopitalManagerment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HopitalManagerment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HopitalManagerment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HopitalManagerment] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HopitalManagerment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HopitalManagerment] SET RECOVERY FULL 
GO
ALTER DATABASE [HopitalManagerment] SET  MULTI_USER 
GO
ALTER DATABASE [HopitalManagerment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HopitalManagerment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HopitalManagerment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HopitalManagerment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HopitalManagerment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HopitalManagerment] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HopitalManagerment', N'ON'
GO
ALTER DATABASE [HopitalManagerment] SET QUERY_STORE = ON
GO
ALTER DATABASE [HopitalManagerment] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HopitalManagerment]
GO
/****** Object:  UserDefinedFunction [dbo].[getTotalItemFunc]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create Function [dbo].[getTotalItemFunc]
	(@SearchText nvarchar(100) )
	returns INT
  AS
  begin
  return 
  Case WHEN @SearchText <> 'none' then ( select count(*) from Staffs 
		Where (isDelete = 0 and role ='Doctor') and (
			staffName like '%' + @SearchText +'%' or
			age  like '%' + @SearchText +'%' or
			gender  like '%' + @SearchText +'%' or
			department like '%' + @SearchText +'%' or
			specialization like '%' + @SearchText +'%' or
			phoneNumber like '%' + @SearchText +'%' or
			[address] like '%' + @SearchText +'%' or
			email like '%' + @SearchText +'%' 
		) )
	Else (Select count(*) from Staffs where (isDelete= 0 and role='Doctor')) end end

GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BloodTestInfors]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BloodTestInfors](
	[bloodTestId] [int] IDENTITY(1,1) NOT NULL,
	[Mediclatestype] [nvarchar](100) NOT NULL,
	[bloodGroup] [nvarchar](10) NOT NULL,
	[haemoglobin] [real] NOT NULL,
	[bloodsugar] [real] NOT NULL,
	[sacid] [real] NOT NULL,
	[description] [nvarchar](500) NULL,
	[patientId] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
	[lastModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_BloodTestInfors] PRIMARY KEY CLUSTERED 
(
	[bloodTestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discharges]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discharges](
	[dischargeId] [int] IDENTITY(1,1) NOT NULL,
	[joinDate] [nvarchar](max) NOT NULL,
	[dischargeDate] [nvarchar](max) NOT NULL,
	[patientId] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
	[lastModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Discharges] PRIMARY KEY CLUSTERED 
(
	[dischargeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InPatients]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InPatients](
	[inPatientId] [int] IDENTITY(1,1) NOT NULL,
	[familyPhone] [nvarchar](11) NOT NULL,
	[dateIn] [nvarchar](20) NOT NULL,
	[dateOut] [nvarchar](20) NOT NULL,
	[symptoms] [nvarchar](500) NOT NULL,
	[department] [nvarchar](100) NOT NULL,
	[wardNum] [int] NOT NULL,
	[bedNum] [int] NOT NULL,
	[patientId] [int] NOT NULL,
	[staffId] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
	[lastModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_InPatients] PRIMARY KEY CLUSTERED 
(
	[inPatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicines]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicines](
	[medicineId] [int] IDENTITY(1,1) NOT NULL,
	[medicineName] [nvarchar](100) NOT NULL,
	[price] [real] NOT NULL,
	[company] [nvarchar](100) NOT NULL,
	[description] [nvarchar](500) NULL,
	[isDelete] [bit] NOT NULL,
	[lastModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Medicines] PRIMARY KEY CLUSTERED 
(
	[medicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OutPatients]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutPatients](
	[outPatientId] [int] IDENTITY(1,1) NOT NULL,
	[familyPhone] [nvarchar](10) NOT NULL,
	[onDate] [nvarchar](20) NOT NULL,
	[department] [nvarchar](500) NOT NULL,
	[isDelete] [bit] NOT NULL,
	[patientId] [int] NOT NULL,
	[staffId] [int] NOT NULL,
	[lastModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_OutPatients] PRIMARY KEY CLUSTERED 
(
	[outPatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[patientId] [int] IDENTITY(1,1) NOT NULL,
	[patientName] [nvarchar](200) NOT NULL,
	[age] [int] NOT NULL,
	[phoneNumber] [nvarchar](12) NOT NULL,
	[gender] [nvarchar](10) NOT NULL,
	[address] [nvarchar](500) NOT NULL,
	[occupation] [nvarchar](100) NULL,
	[isDelete] [bit] NOT NULL,
	[lastModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[patientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PharmaceInfors]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PharmaceInfors](
	[pharmacyInforId] [int] IDENTITY(1,1) NOT NULL,
	[department] [nvarchar](100) NOT NULL,
	[status] [nvarchar](20) NOT NULL,
	[description] [nvarchar](500) NULL,
	[isDelete] [bit] NOT NULL,
	[patientId] [int] NOT NULL,
	[lastModified] [datetime2](7) NOT NULL,
	[medicineId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_PharmaceInfors] PRIMARY KEY CLUSTERED 
(
	[pharmacyInforId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[staffId] [int] IDENTITY(1,1) NOT NULL,
	[staffName] [nvarchar](100) NOT NULL,
	[userName] [nvarchar](100) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[age] [int] NOT NULL,
	[gender] [nvarchar](10) NOT NULL,
	[department] [nvarchar](100) NOT NULL,
	[specialization] [nvarchar](max) NULL,
	[phoneNumber] [nvarchar](12) NOT NULL,
	[address] [nvarchar](500) NULL,
	[email] [nvarchar](100) NOT NULL,
	[role] [nvarchar](max) NOT NULL,
	[isDelete] [bit] NOT NULL,
	[lastAccess] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[staffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SurgeryInfors]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurgeryInfors](
	[surgeryInforId] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](100) NOT NULL,
	[result] [nvarchar](100) NOT NULL,
	[description] [nvarchar](500) NULL,
	[isDelete] [bit] NOT NULL,
	[surgeryRequestId] [int] NOT NULL,
	[lastModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_SurgeryInfors] PRIMARY KEY CLUSTERED 
(
	[surgeryInforId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SurgeryRequest]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurgeryRequest](
	[surgeryRequestId] [int] IDENTITY(1,1) NOT NULL,
	[surgeryTpye] [nvarchar](100) NOT NULL,
	[surgeryDate] [nvarchar](100) NOT NULL,
	[status] [nvarchar](100) NOT NULL,
	[description] [nvarchar](500) NULL,
	[isDelete] [bit] NOT NULL,
	[patientId] [int] NOT NULL,
	[staffId] [int] NOT NULL,
	[lastModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_SurgeryRequest] PRIMARY KEY CLUSTERED 
(
	[surgeryRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UrineTestInfors]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrineTestInfors](
	[urineTestId] [int] IDENTITY(1,1) NOT NULL,
	[mediclatestype] [nvarchar](100) NOT NULL,
	[color] [nvarchar](100) NOT NULL,
	[calrity] [nvarchar](100) NOT NULL,
	[odor] [nvarchar](100) NOT NULL,
	[specificgravity] [nvarchar](100) NOT NULL,
	[glucose] [real] NOT NULL,
	[description] [nvarchar](500) NULL,
	[isDelete] [bit] NOT NULL,
	[patientId] [int] NOT NULL,
	[lastModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UrineTestInfors] PRIMARY KEY CLUSTERED 
(
	[urineTestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230214084346_CreateMigration', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230221083426_AddAccessDate', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230223024704_addLastModifiedColumn', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228030633_ModifideMaxLength', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230310065547_ModifiedPropertiesInBloodTestTable', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230312030935_ModifiedPropertiesInUrineTestTable', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230312035601_ModifiedPropertiesInUrineTestTable', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230316071049_CreateMedicineTable', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230403033111_removeRequiredAddress', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[BloodTestInfors] ON 

INSERT [dbo].[BloodTestInfors] ([bloodTestId], [Mediclatestype], [bloodGroup], [haemoglobin], [bloodsugar], [sacid], [description], [patientId], [isDelete], [lastModified]) VALUES (1, N'abc', N'A', 15.2, 7.2, 7.2, N'avb', 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[BloodTestInfors] ([bloodTestId], [Mediclatestype], [bloodGroup], [haemoglobin], [bloodsugar], [sacid], [description], [patientId], [isDelete], [lastModified]) VALUES (2, N'abc', N'B', 15.2, 7.2, 7.2, N'asd', 3, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[BloodTestInfors] ([bloodTestId], [Mediclatestype], [bloodGroup], [haemoglobin], [bloodsugar], [sacid], [description], [patientId], [isDelete], [lastModified]) VALUES (3, N'Basic metabolic panel', N'B', 13, 7, 7, N'abc', 16, 0, CAST(N'2023-03-10T14:01:43.6309716' AS DateTime2))
INSERT [dbo].[BloodTestInfors] ([bloodTestId], [Mediclatestype], [bloodGroup], [haemoglobin], [bloodsugar], [sacid], [description], [patientId], [isDelete], [lastModified]) VALUES (4, N'Basic metabolic panel', N'A', 15, 7.5, 7, N'asdasd', 4, 0, CAST(N'2023-03-10T15:30:25.3937354' AS DateTime2))
INSERT [dbo].[BloodTestInfors] ([bloodTestId], [Mediclatestype], [bloodGroup], [haemoglobin], [bloodsugar], [sacid], [description], [patientId], [isDelete], [lastModified]) VALUES (5, N'Blood tests to check for heart disease', N'O', 13.2, 6.5, 5.2, N'abccc', 8, 0, CAST(N'2023-03-10T15:32:15.1705535' AS DateTime2))
INSERT [dbo].[BloodTestInfors] ([bloodTestId], [Mediclatestype], [bloodGroup], [haemoglobin], [bloodsugar], [sacid], [description], [patientId], [isDelete], [lastModified]) VALUES (6, N'Basic metabolic panel', N'A', 14.5, 7, 6.3, N'The patient''s blood test results show normal haemoglobin levels, slightly elevated blood sugar levels, and normal sacid levels.', 13, 0, CAST(N'2023-03-10T15:40:05.7171950' AS DateTime2))
INSERT [dbo].[BloodTestInfors] ([bloodTestId], [Mediclatestype], [bloodGroup], [haemoglobin], [bloodsugar], [sacid], [description], [patientId], [isDelete], [lastModified]) VALUES (7, N'Basic metabolic panel', N'B', 13.2, 5.4, 4.8, N'The patient''s blood test results show slightly low haemoglobin levels, normal blood sugar levels, and slightly elevated sacid levels.', 15, 0, CAST(N'2023-03-10T15:43:53.4370334' AS DateTime2))
INSERT [dbo].[BloodTestInfors] ([bloodTestId], [Mediclatestype], [bloodGroup], [haemoglobin], [bloodsugar], [sacid], [description], [patientId], [isDelete], [lastModified]) VALUES (8, N'Basic metabolic panel', N'O', 12.9, 6.1, 5.2, N'The patient''s blood test results show slightly low haemoglobin levels, slightly elevated blood sugar levels, and normal sacid levels.', 15, 0, CAST(N'2023-03-10T15:41:31.3489557' AS DateTime2))
INSERT [dbo].[BloodTestInfors] ([bloodTestId], [Mediclatestype], [bloodGroup], [haemoglobin], [bloodsugar], [sacid], [description], [patientId], [isDelete], [lastModified]) VALUES (9, N'Basic metabolic panel', N'AB', 15.8, 4.8, 6.4, N'The patient''s blood test results show normal haemoglobin levels, normal blood sugar levels, and slightly elevated sacid levels.', 18, 0, CAST(N'2023-03-10T15:43:45.0260195' AS DateTime2))
INSERT [dbo].[BloodTestInfors] ([bloodTestId], [Mediclatestype], [bloodGroup], [haemoglobin], [bloodsugar], [sacid], [description], [patientId], [isDelete], [lastModified]) VALUES (10, N'Basic metabolic panel', N'A', 11.6, 7.5, 5.8, N'The patient''s blood test results show low haemoglobin levels, slightly elevated blood sugar levels, and slightly low sacid levels.', 7, 0, CAST(N'2023-03-10T15:43:40.4946927' AS DateTime2))
SET IDENTITY_INSERT [dbo].[BloodTestInfors] OFF
GO
SET IDENTITY_INSERT [dbo].[InPatients] ON 

INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (8, N'0946136655', N'2023-03-06', N'2023-03-13', N'avc', N'Physical medicine', 2, 5, 18, 11044, 0, CAST(N'2023-03-06T13:18:18.8617563' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (9, N'0616484618', N'2023-03-07', N'2023-03-09', N'abc', N'Physical medicine', 4, 4, 18, 11039, 0, CAST(N'2023-03-07T13:47:45.2723431' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (10, N'0121616561', N'2023-03-09', N'2023-03-11', N'ho, sot', N'Paramedical department', 1, 4, 18, 11047, 0, CAST(N'2023-03-09T15:33:06.3971523' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (11, N'0278981475', N'2023-03-15', N'2023-03-18', N'appendicitis pain', N'Surgical department', 2, 4, 15, 11049, 0, CAST(N'2023-03-15T10:43:45.8574734' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (12, N'0392861581', N'2023-03-15', N'2023-03-18', N'asdavasdg 12easd', N'Paramedical department', 5, 1, 1, 11045, 0, CAST(N'2023-03-15T10:44:23.0428375' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (13, N'0249672946', N'2023-03-16', N'2023-03-21', N'asdasd', N'Rehabilitation department', 4, 4, 12, 11041, 0, CAST(N'2023-03-15T10:44:47.9240773' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (14, N'0649169135', N'2023-03-18', N'2023-03-31', N'Pain that does not respond to non-surgical treatments such as medication or physical therapy', N'Surgical department', 5, 5, 4, 11050, 0, CAST(N'2023-03-17T10:43:28.3935248' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (15, N'0912345678', N'2023-03-17', N'2023-03-18', N'Unexplained weight loss or gain', N'Surgical department', 2, 4, 26, 11056, 0, CAST(N'2023-03-17T14:47:36.8449960' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (16, N'0987654321', N'2023-03-17', N'2023-03-21', N'Chronic fatigue or weakness.', N'Surgical department', 4, 5, 26, 11046, 0, CAST(N'2023-03-17T14:48:36.2643711' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (17, N'0938123456', N'2023-03-18', N'2023-03-19', N'abvavasdv', N'Surgical department', 2, 3, 26, 11053, 0, CAST(N'2023-03-17T14:53:15.5036105' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (18, N'0965432109', N'2023-03-17', N'2023-03-25', N'dfbsdfbs ', N'Surgical department', 1, 3, 21, 11050, 0, CAST(N'2023-03-17T14:54:47.5090099' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (19, N'0978543210', N'2023-03-17', N'2023-03-31', N'3123adfasda', N'Surgical department', 1, 1, 18, 11057, 0, CAST(N'2023-03-17T14:55:21.5297918' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (20, N'0908765432', N'2023-03-17', N'2023-03-30', N'gádgasdfasdf', N'Surgical department', 2, 4, 24, 11042, 0, CAST(N'2023-03-17T15:04:27.3307700' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (21, N'0945678901', N'2023-03-18', N'2023-03-23', N'adsvasdv', N'Surgical department', 5, 4, 16, 11057, 0, CAST(N'2023-03-17T15:05:12.7216021' AS DateTime2))
INSERT [dbo].[InPatients] ([inPatientId], [familyPhone], [dateIn], [dateOut], [symptoms], [department], [wardNum], [bedNum], [patientId], [staffId], [isDelete], [lastModified]) VALUES (22, N'0981234567', N'2023-03-17', N'2023-03-23', N'adsfasdf', N'Surgical department', 4, 3, 19, 11057, 0, CAST(N'2023-03-17T15:06:08.9079202' AS DateTime2))
SET IDENTITY_INSERT [dbo].[InPatients] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicines] ON 

INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (1, N'Aspirin', 5.99, N'Bayer', N'Pain relief and anti-inflammatory medication', 0, CAST(N'2023-03-16T15:32:05.4577640' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (2, N'Amoxicillin', 9.99, N'Teva', N'Antibiotic for bacterial infections', 1, CAST(N'2023-03-16T15:32:42.5205022' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (3, N'Lipitor', 22.5, N'Pfizer', N'Cholesterol-lowering medication', 1, CAST(N'2023-03-16T15:33:05.6989453' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (4, N'Prozac', 15.75, N'Eli Lilly', N'Antidepressant medication', 1, CAST(N'2023-03-16T15:33:31.9889412' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (5, N'Zantac', 8.45, N'GlaxoSmithKline', N'Acid reflux medication', 0, CAST(N'2023-03-16T15:36:01.4839635' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (6, N'Ibuprofen', 4.25, N'Johnson & Johnson', N'Pain relief and anti-inflammatory medication', 0, CAST(N'2023-03-16T15:36:21.4243162' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (7, N'Metformin', 6.99, N'Novartis', N'Medication for diabetes management', 0, CAST(N'2023-03-16T15:36:50.4843003' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (8, N'Atorvastatin', 18.99, N'AstraZeneca', N'Cholesterol-lowering medication', 0, CAST(N'2023-03-16T15:37:16.2994081' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (9, N'Penicillin', 7.75, N'Sandoz', N'Antibiotic for bacterial infections', 0, CAST(N'2023-03-16T15:37:52.0673605' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (10, N'Nexium', 10.99, N'Pfizer', N'Medication for acid reflux and stomach ulcers', 0, CAST(N'2023-03-16T15:38:15.9293261' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (11, N'paracetamol', 2.99, N'Panadol Extra', N'Do not take paracetamol if you are taking any other prescription or non-prescription medications containing paracetamol or acetaminophen.', 0, CAST(N'2023-03-16T20:30:30.7018991' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (12, N'Aspirin', 0.05, N'Bayer', N'Aspirin is a nonsteroidal anti-inflammatory drug (NSAID) used to treat pain, fever, and inflammation. It works by inhibiting the production of prostaglandins, which are involved in pain and inflammation.', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (13, N'Lipitor', 3.5, N'Pfizer', N'Lipitor is a statin drug used to lower cholesterol levels in the blood. It works by blocking an enzyme in the liver that is necessary for the production of cholesterol.', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (14, N'Tylenol', 0.1, N'Johnson & Johnson', N'Tylenol is an analgesic and antipyretic drug used to treat mild to moderate pain and reduce fever. It works by reducing the production of prostaglandins, which are involved in pain and fever.', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (15, N'Zoloft', 2.75, N'Pfizer', N'Zoloft is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, obsessive-compulsive disorder, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (16, N'Advil', 0.2, N'Pfizer', N'Advil is a nonsteroidal anti-inflammatory drug (NSAID) used to treat pain, fever, and inflammation. It works by inhibiting the production of prostaglandins, which are involved in pain and inflammation.', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (17, N'Aspirin', 0.05, N'Bayer', N'Aspirin is a nonsteroidal anti-inflammatory drug (NSAID) used to treat pain, fever, and inflammation. It works by inhibiting the production of prostaglandins, which are involved in pain and inflammation.', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (18, N'Lipitor', 3.5, N'Pfizer', N'Lipitor is a statin drug used to lower cholesterol levels in the blood. It works by blocking an enzyme in the liver that is necessary for the production of cholesterol.', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (19, N'Tylenol', 0.1, N'Johnson & Johnson', N'Tylenol is an analgesic and antipyretic drug used to treat mild to moderate pain and reduce fever. It works by reducing the production of prostaglandins, which are involved in pain and fever.', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (20, N'Zoloft', 2.75, N'Pfizer', N'Zoloft is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, obsessive-compulsive disorder, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (21, N'Advil', 0.2, N'Pfizer', N'Advil is a nonsteroidal anti-inflammatory drug (NSAID) used to treat pain, fever, and inflammation. It works by inhibiting the production of prostaglandins, which are involved in pain and inflammation.', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (22, N'Amoxicillin', 0.15, N'Various', N'Amoxicillin is an antibiotic used to treat bacterial infections. It works by inhibiting the growth of bacteria by preventing the formation of their cell walls.', 1, CAST(N'2023-03-22T19:54:52.9840242' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (23, N'Prozac', 2.5, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-22T19:54:53.7700551' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (24, N'string', 0, N'string', N'string', 1, CAST(N'2023-03-22T20:47:13.7778455' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (25, N'Crestor', 3.75, N'AstraZeneca', N'Crestor is a statin drug used to lower cholesterol levels in the blood. It works by blocking an enzyme in the liver that is necessary for the production of cholesterol.', 1, CAST(N'2023-03-22T19:54:53.7703964' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (26, N'Amoxicillin', 0.15, N'Various', N'Amoxicillin is an antibiotic used to treat bacterial infections. It works by inhibiting the growth of bacteria by preventing the formation of their cell walls.', 0, CAST(N'2023-03-23T10:45:41.7880935' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (27, N'Prozac', 2.5, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 0, CAST(N'2023-03-23T10:45:41.8328693' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (28, N'string', 16, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T08:38:12.4453878' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (29, N'Crestor', 3.75, N'AstraZeneca', N'Crestor is a statin drug used to lower cholesterol levels in the blood. It works by blocking an enzyme in the liver that is necessary for the production of cholesterol.', 1, CAST(N'2023-03-23T10:45:41.8332607' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (30, N'Crestor', 3.9, N'AstraZeneca', N'Crestor is a statin drug used to lower cholesterol levels in the blood. It works by blocking an enzyme in the liver that is necessary for the production of cholesterol.', 1, CAST(N'2023-03-23T13:59:08.1675141' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (31, N'Omeprazole', 2.8, N'AstraZeneca', N'Omeprazole is a proton pump inhibitor (PPI) drug used to reduce the amount of acid produced by the stomach. It is used to treat gastroesophageal reflux disease (GERD) and other digestive conditions.', 1, CAST(N'2023-03-23T14:02:01.1319979' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (32, N'Omeprazole', 2.8, N'AstraZeneca', N'Omeprazole is a proton pump inhibitor (PPI) drug used to reduce the amount of acid produced by the stomach. It is used to treat gastroesophageal reflux disease (GERD) and other digestive conditions.', 1, CAST(N'2023-03-23T14:20:50.4196416' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (33, N'Omeprazole', 2.8, N'AstraZeneca', N'Omeprazole is a proton pump inhibitor (PPI) drug used to reduce the amount of acid produced by the stomach. It is used to treat gastroesophageal reflux disease (GERD) and other digestive conditions.', 1, CAST(N'2023-03-23T14:43:57.7860107' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (34, N'Omeprazole', 2.9, N'abcxyz', N'Omeprazole is a proton pump inhibitor (PPI) drug used to reduce the amount of acid produced by the stomach. It is used to treat gastroesophageal reflux disease (GERD) and other digestive conditions.', 0, CAST(N'2023-03-31T15:13:05.9334298' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (35, N'asdasd', 2.8, N'AstraZeneca', N'Omeprazole is a proton pump inhibitor (PPI) drug used to reduce the amount of acid produced by the stomach. It is used to treat gastroesophageal reflux disease (GERD) and other digestive conditions.', 1, CAST(N'2023-03-23T14:44:54.3516198' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (36, N'asdasd', 2.8, N'AstraZeneca', N'Omeprazole is a proton pump inhibitor (PPI) drug used to reduce the amount of acid produced by the stomach. It is used to treat gastroesophageal reflux disease (GERD) and other digestive conditions.', 1, CAST(N'2023-03-23T14:46:25.9061730' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (37, N'asdasd', 616.5, N'AstraZeneca', N'Omeprazole is a proton pump inhibitor (PPI) drug used to reduce the amount of acid produced by the stomach. It is used to treat gastroesophageal reflux disease (GERD) and other digestive conditions.', 1, CAST(N'2023-03-23T14:47:13.2908659' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (38, N'asdasd', 616.5, N'AstraZeneca', N'Omeprazole is a proton pump inhibitor (PPI) drug used to reduce the amount of acid produced by the stomach. It is used to treat gastroesophageal reflux disease (GERD) and other digestive conditions.', 1, CAST(N'2023-03-23T20:22:56.2295489' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (39, N'asdasd', 616.5, N'AstraZeneca', N'Omeprazole is a proton pump inhibitor (PPI) drug used to reduce the amount of acid produced by the stomach. It is used to treat gastroesophageal reflux disease (GERD) and other digestive conditions.', 1, CAST(N'2023-03-24T08:58:50.5844528' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (40, N'avsdc', 616.5, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-24T09:34:18.1019922' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (41, N'string1', 16, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-24T14:26:01.0739833' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (42, N'string', 16, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T09:04:41.5869534' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (43, N'string', 17, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T09:04:41.8817317' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (44, N'string1', 16, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T09:04:41.8935302' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (45, N'test', 16, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T09:45:18.8794806' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (46, N'test', 17, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T09:45:18.9036777' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (47, N'test', 18, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T09:45:18.9099511' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (48, N'test', 24, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T10:09:28.4274617' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (49, N'test', 17, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T09:46:32.3345837' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (50, N'test', 18, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T09:46:32.3429703' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (51, N'test', 20, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T09:49:47.2274923' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (52, N'test', 21, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T09:49:52.0799067' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (53, N'test', 22, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T10:02:36.0246421' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (54, N'test', 23, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T10:02:36.3444591' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (55, N'abc', 24, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'2023-03-27T10:31:09.4707452' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (56, N'abc', 25, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (57, N'abc', 27, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (58, N'abc', 100, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (59, N'abc', 101, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (60, N'abcd', 103, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (61, N'abcde', 103, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (62, N'abcdf', 0, N'Eli Lilly and Company', N'Prozac is a selective serotonin reuptake inhibitor (SSRI) antidepressant used to treat major depressive disorder, bulimia nervosa, and other mental health conditions. It works by increasing the availability of the neurotransmitter serotonin in the brain.', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (63, N'test1', 12, N'string', N'string', 0, CAST(N'2023-03-28T20:31:12.1954336' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (64, N'test2', 12, N'1sdv', N'vsdfvs', 0, CAST(N'2023-03-28T20:33:15.0224020' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (65, N'abc', 3.3, N'abc', N'ávasdv', 0, CAST(N'2023-03-29T09:49:29.5085706' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (66, N'test3', 22, N'aba', N'ávasdvas', 0, CAST(N'2023-03-31T15:14:02.3694668' AS DateTime2))
INSERT [dbo].[Medicines] ([medicineId], [medicineName], [price], [company], [description], [isDelete], [lastModified]) VALUES (67, N'abcdf', 1.2, N'Eli Lilly and Company', NULL, 0, CAST(N'2023-04-03T10:10:47.6010494' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Medicines] OFF
GO
SET IDENTITY_INSERT [dbo].[OutPatients] ON 

INSERT [dbo].[OutPatients] ([outPatientId], [familyPhone], [onDate], [department], [isDelete], [patientId], [staffId], [lastModified]) VALUES (2, N'0947889455', N'2023-03-06', N'Physical medicine', 0, 18, 11041, CAST(N'2023-03-06T15:06:11.9953246' AS DateTime2))
INSERT [dbo].[OutPatients] ([outPatientId], [familyPhone], [onDate], [department], [isDelete], [patientId], [staffId], [lastModified]) VALUES (3, N'0949616315', N'2023-03-10', N'Nursing department', 0, 18, 11044, CAST(N'2023-03-07T13:46:52.9295688' AS DateTime2))
INSERT [dbo].[OutPatients] ([outPatientId], [familyPhone], [onDate], [department], [isDelete], [patientId], [staffId], [lastModified]) VALUES (4, N'0981234567', N'2023-03-18', N'Surgical department', 0, 13, 11057, CAST(N'2023-03-17T15:06:41.3472721' AS DateTime2))
SET IDENTITY_INSERT [dbo].[OutPatients] OFF
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (1, N'Nguyen Ho Ngoc An', 20, N'0489648923', N'female', N'Da Nang', N'Student', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (2, N'Harry', 32, N'0854967393', N'male', N'Abc', N'Driver', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (3, N'Alice', 0, N'0784785683', N'female', N'Da Nang', N'Teacher', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (4, N'Sunny', 28, N'0649616185', N'female', N'Da Nang', N'engineer ', 0, CAST(N'2023-02-23T16:45:05.7358044' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (5, N'Davic ', 27, N'0194985686', N'male', N'Da Nang', N'none', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (6, N'Anine ', 14, N'0994623562', N'female', N'asdsd', N'sdfs', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (7, N'MarKur', 26, N'0369954852', N'male', N'sdvasdv', N'svavsd', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (8, N'Lucy', 20, N'0596549823', N'female', N'sdfasdf', N'nsfgn', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (9, N'Baal', 0, N'0999561231', N'female', N'asdf', N'ntntbe', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (10, N'Morax', 46, N'0689545645', N'male', N'sdbev', N'kmmuu', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (11, N'Peter', 28, N'0989563389', N'male', N'sdfefbe', N'131dvsdv', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (12, N'makoto', 21, N'0519516667', N'female', N'vavr', N'tbgbasd', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (13, N'Karvin', 22, N'0234689488', N'male', N'sdf', N'none', 0, CAST(N'2023-02-23T14:48:06.7310097' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (14, N'Tran Van Anh', 32, N'0912345678', N'male', N'123 Nguyen Trai, Ha Noi', N'Engineer', 0, CAST(N'2023-02-28T14:34:01.0457501' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (15, N'Nguyen Thi Bich Ngoc', 28, N'0987654321', N'female', N'456 Le Thanh Ton, HCM City', N'Marketing Specialist', 0, CAST(N'2023-02-28T15:16:00.3947266' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (16, N'Le Minh Thanh', 26, N'0965432109', N'male', N'789 Truong Chinh, Ha Noi', N'Software Developer', 0, CAST(N'2023-02-28T16:19:13.2459599' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (17, N'aaa', 24, N'0123456789', N'male', N'sdf', N'Student', 1, CAST(N'2023-02-28T16:10:28.2733737' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (18, N'Pham Van Nam', 30, N'0945678901', N'male', N'147 Le Lai, Da Nang', N'Accountant', 0, CAST(N'2023-02-28T16:22:00.2535719' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (19, N'Nguyen Thi Thu', 32, N'0911112222', N'female', N'123 Nguyen Van Troi, Phu Nhuan District, Ho Chi Minh City', N'Banker', 0, CAST(N'2023-03-17T13:45:58.2061794' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (20, N'Tran Minh Duc', 45, N'0944445555', N'male', N'456 Le Quang Dinh, Go Vap District, Ho Chi Minh City', N'Business Owner', 0, CAST(N'2023-03-17T13:46:40.8333246' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (21, N'Le Thi Kim Ngan', 25, N'0933334444', N'female', N'789 Tran Hung Dao, District 1, Ho Chi Minh City', N'Software Engineer', 0, CAST(N'2023-03-17T13:47:23.8986582' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (22, N'Pham Minh Trung', 38, N'0977778888', N'male', N'246 Ton That Tung, District 1, Ho Chi Minh City', N'Marketing Manager', 0, CAST(N'2023-03-17T13:48:07.8716106' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (23, N'Nguyen Van Hoa', 52, N'0988889999', N'male', N'567 Le Van Sy, Tan Binh District, Ho Chi Minh City', N'Government Officer', 0, CAST(N'2023-03-17T13:48:46.2627729' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (24, N'Hoang Thi Mai', 43, N'0922223333', N'female', N'888 Nguyen Huu Tho, District 7, Ho Chi Minh City', N'Lawyer', 0, CAST(N'2023-03-17T13:50:39.8142161' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (25, N'Tran Thi Thuy Trang', 28, N'0912345678', N'female', N'111 Vo Thi Sau, District 3, Ho Chi Minh City', N'Accountant', 0, CAST(N'2023-03-17T13:51:17.6129241' AS DateTime2))
INSERT [dbo].[Patients] ([patientId], [patientName], [age], [phoneNumber], [gender], [address], [occupation], [isDelete], [lastModified]) VALUES (26, N'Nguyen Van Tuan', 36, N'0966667777', N'male', N'222 Nguyen Thi Thap, District 7, Ho Chi Minh City', N'Engineer', 0, CAST(N'2023-03-17T13:51:48.1632994' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
SET IDENTITY_INSERT [dbo].[PharmaceInfors] ON 

INSERT [dbo].[PharmaceInfors] ([pharmacyInforId], [department], [status], [description], [isDelete], [patientId], [lastModified], [medicineId], [quantity]) VALUES (1, N'Surgical department', N'Ordered', N'avb', 1, 15, CAST(N'2023-03-16T20:30:46.6277810' AS DateTime2), 11, 10)
INSERT [dbo].[PharmaceInfors] ([pharmacyInforId], [department], [status], [description], [isDelete], [patientId], [lastModified], [medicineId], [quantity]) VALUES (2, N'Surgical department', N'Ordered', N'asdasd', 0, 15, CAST(N'2023-03-17T10:35:24.2351644' AS DateTime2), 9, 5)
INSERT [dbo].[PharmaceInfors] ([pharmacyInforId], [department], [status], [description], [isDelete], [patientId], [lastModified], [medicineId], [quantity]) VALUES (3, N'Surgical department', N'Ordered', N'drink before lunch', 0, 18, CAST(N'2023-03-17T14:59:00.2177184' AS DateTime2), 11, 6)
INSERT [dbo].[PharmaceInfors] ([pharmacyInforId], [department], [status], [description], [isDelete], [patientId], [lastModified], [medicineId], [quantity]) VALUES (4, N'Surgical department', N'Ordered', N'cádgasg', 0, 18, CAST(N'2023-03-17T14:59:19.9925886' AS DateTime2), 3, 3)
INSERT [dbo].[PharmaceInfors] ([pharmacyInforId], [department], [status], [description], [isDelete], [patientId], [lastModified], [medicineId], [quantity]) VALUES (5, N'Surgical department', N'Ordered', N'ádasdsdv', 0, 18, CAST(N'2023-03-17T14:59:28.2590633' AS DateTime2), 5, 5)
INSERT [dbo].[PharmaceInfors] ([pharmacyInforId], [department], [status], [description], [isDelete], [patientId], [lastModified], [medicineId], [quantity]) VALUES (6, N'Surgical department', N'Ordered', N'ádfasdfas', 0, 21, CAST(N'2023-03-17T14:59:36.5358179' AS DateTime2), 11, 3)
INSERT [dbo].[PharmaceInfors] ([pharmacyInforId], [department], [status], [description], [isDelete], [patientId], [lastModified], [medicineId], [quantity]) VALUES (7, N'Surgical department', N'Ordered', N'csadvasdv', 0, 21, CAST(N'2023-03-17T15:00:45.0194636' AS DateTime2), 8, 4)
INSERT [dbo].[PharmaceInfors] ([pharmacyInforId], [department], [status], [description], [isDelete], [patientId], [lastModified], [medicineId], [quantity]) VALUES (8, N'Surgical department', N'Ordered', N'ádasd', 0, 19, CAST(N'2023-03-20T14:18:49.1917287' AS DateTime2), 9, 1)
SET IDENTITY_INSERT [dbo].[PharmaceInfors] OFF
GO
SET IDENTITY_INSERT [dbo].[Staffs] ON 

INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11029, N'kumar', N'kumar', N'123456', 28, N'male', N'abc', N'a', N'1234567896', N'kk', N'abc', N'Employee', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11030, N'hieu', N'hieu123', N'12345678', 18, N'male', N'disclosure of information', N'pediatrics', N'0133456789', N'Hue', N'hieuhx1@fsoft.com.vn', N'Doctor', 0, CAST(N'2023-02-27T14:23:28.0626229' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11031, N'eeeeee', N'aádvsadvas', N'123456789', 43, N'female', N'Inpatient service (IP)', N'pathology', N'0133456789', N'fgbf', N'123@123.com', N'Employee', 0, CAST(N'2023-02-27T14:24:38.7258190' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11032, N'Alexander Fleming', N'Doctor1', N'123456789', 25, N'male', N'Inpatient service (IP)', N'obstetrics and gynecology', N'0949616314', N'Da Nang', N'Alex123@gmail.com', N'Doctor', 0, CAST(N'2023-02-28T09:27:23.7919776' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11033, N'Hieu', N'Admin1', N'hieuhohieuho123', 21, N'male', N'Surgical department', N'', N'0341648251', N'Hue', N'hieuhxde160389@fpt.edu.vn', N'Employee', 0, CAST(N'2023-02-28T10:21:47.1035766' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11034, N'Nguyen Van A', N'nguyenvana', N'abc123456', 26, N'male', N'Dietary department', N'anesthesiology', N'0901234567', N'123 Le Loi, Ho Chi Minh City', N'nguyenvana@gmail.com', N'Doctor', 0, CAST(N'2023-02-28T10:26:29.8413182' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11035, N'Tran Thi Binh	', N'binhtran	', N'123456789', 35, N'female', N'Nursing department', N'pediatrics', N'0912345678', N'456 Nguyen Hue, Da Nang', N'binhtran@yahoo.com', N'Doctor', 0, CAST(N'2023-02-28T10:27:52.0846284' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11036, N'Le Hoang Nam', N'namlehoang', N'nam123456', 28, N'male', N'Rehabilitation department', N'anesthesiology', N'0977654321', N'789 Vo Van Kiet, Can Tho', N'namlehoang@hotmail.com', N'Doctor', 0, CAST(N'2023-02-28T10:29:18.3235072' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11037, N'Pham Thi Ngoc', N'ngocpham', N'password123', 30, N'female', N'Pharmacy department', N'pediatrics', N'0945678901', N'147 Nguyen Trai, Ha Noi	', N'ngocpham@outlook.com', N'Doctor', 0, CAST(N'2023-02-28T10:30:11.0469700' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11038, N'Hoang Van Cuong	', N'cuonghoang', N'123abc123abc', 40, N'male', N'Operation theater complex (OT)', N'surgery', N'0987654321', N'234 Tran Duy Hung, Ha Noi', N'cuonghoang@viettel.com.vn', N'Doctor', 0, CAST(N'2023-02-28T10:30:59.7409563' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11039, N'Tran Thi Kim', N'kimtran', N'kim123	kim123	', 22, N'female', N'Pharmacy department', N'anesthesiology', N'0934567890', N'567 Phan Van Tri, Hue', N'kimtran@gmail.com', N'Doctor', 0, CAST(N'2023-02-28T10:31:50.4933668' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11040, N'Nguyen Van B', N'nguyenvanb	', N'123456abc', 27, N'female', N'Nursing department', N'internal medicine', N'0965432109', N'321 Nguyen Van Cu, Ha Noi', N'nguyenvanb@icloud.com', N'Doctor', 0, CAST(N'2023-02-28T10:32:33.4076012' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11041, N'Le Thi Thu', N'thule', N'thu456thu456', 32, N'female', N'Dietary department', N'ophthalmology', N'0923456789', N'789 Nguyen Van Linh, Da Nang', N'thule@hotmail.com', N'Doctor', 0, CAST(N'2023-02-28T10:35:43.6617166' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11042, N'Phan Thi Hoa	', N'hoaphan', N'hoa123hoa123', 29, N'female', N'Radiology department (X-ray)', N'ophthalmology', N'0956789012', N'101 Ton That Thuyet, Ha Noi', N'hoaphan@yahoo.com', N'Doctor', 0, CAST(N'2023-02-28T10:36:31.3419431' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11043, N'Truong Minh Duc', N'ductruongminh', N'duc123456', 26, N'male', N'Physical medicine', N'psychiatry and neurology', N'0888888888', N'456 Tran Hung Dao, HCM City	', N'ductruongminh@outlook.com', N'Doctor', 0, CAST(N'2023-02-28T10:37:11.3096107' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11044, N'Nguyen Thi Hien', N'hienn', N'hien123hien123', 28, N'female', N'Dietary department', N'anesthesiology', N'0912345678', N'123 Nguyen Trai, Ha Noi', N'hienn@gmail.com', N'Doctor', 0, CAST(N'2023-02-28T10:39:05.1730332' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11045, N'Tran Van Tuan', N'tuantran', N'tran123456', 32, N'male', N'Rehabilitation department', N'anesthesiology', N'0987654321', N'456 Le Thanh Ton, HCM City', N'tuantran@yahoo.com', N'Doctor', 0, CAST(N'2023-02-28T10:39:57.4622984' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11046, N'Le Thanh Binh', N'binhlethanh', N'binh456789', 25, N'male', N'Operation theater complex (OT)', N'radiology', N'0965432109', N'789 Truong Chinh, Ha Noi', N'binhlethanh@hotmail.com', N'Doctor', 0, CAST(N'2023-02-28T10:40:42.7684201' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11047, N'Pham Van Quoc', N'quocphamvan', N'quoc456789', 30, N'male', N'Pharmacy department', N'urology', N'0945678901', N'147 Le Lai, Da Nang', N'quocphamvan@outlook.com', N'Doctor', 0, CAST(N'2023-02-28T10:41:34.8814701' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11048, N'Hoang Thi Thuy', N'thuyhoang', N'thuy123456', 32, N'female', N'Rehabilitation department', N'obstetrics and gynecology', N'0934567890', N'567 Vo Thi Sau, Hue	', N'thuyhoang@viettel.com.vn', N'Doctor', 0, CAST(N'2023-02-28T10:42:24.4720483' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11049, N'Tran Van Minh	', N'minhtranvan', N'minh123minh123', 27, N'male', N'Dietary department', N'surgery', N'0977654321', N'321 Nguyen Thai Hoc, Ha Noi', N'minhtranvan@gmail.com', N'Doctor', 0, CAST(N'2023-02-28T10:43:01.8603876' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11050, N'Nguyen Van Cuong', N'cuongnguyenvan', N'cuong123', 35, N'male', N'Surgical department', N'surgery', N'0923456789', N'789 Hai Ba Trung, HCM City', N'cuongnguyenvan@icloud.com', N'Doctor', 0, CAST(N'2023-02-28T10:51:16.7729337' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11051, N'Le Thi Kim', N'kimlethi', N'kim123kim123', 29, N'female', N'Nursing department', N'internal medicine', N'0956789012', N'101 Ton Duc Thang, Da Nang', N'kimlethi@hotmail.com', N'Doctor', 0, CAST(N'2023-02-28T10:52:57.3881400' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11052, N'Phan Thi Hong', N'hongphanthi', N'hong123hong123', 31, N'female', N'Nursing department', N'internal medicine', N'0971234567', N'456 Ho Tung Mau, Ha Noi', N'hongphanthi@yahoo.com', N'Doctor', 0, CAST(N'2023-02-28T10:53:49.9185418' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11053, N'Truong Van Dat', N'dattruongvan', N'dat123dat123', 26, N'male', N'Paramedical department', N'pathology', N'0881264555', N'234 Nguyen Cong Tru, Can Tho', N'dattruongvan@outlook.com', N'Doctor', 0, CAST(N'2023-02-28T10:54:43.1806991' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11054, N'aasdf', N'dfasdf', N'123456987', 55, N'female', N'Nursing department', N'pediatrics', N'0341648251', N'fsd', N'123@123.com', N'Doctor', 1, CAST(N'2023-02-28T13:45:39.6626754' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11055, N'Pham Minh C', N'phamC', N'Cc1!2#3$4%	', 42, N'male', N'Rehabilitation department', N'pathology', N'0987654321', N'789 Nguyen Van Linh, Da Nang', N'phamminhc@gmail.com', N'Doctor', 0, CAST(N'2023-03-03T10:34:45.4097219' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11056, N'Nguyen Minh Duc', N'ducnm', N'pass123456', 32, N'male', N'Surgical department', N'surgery', N'0987654321', N'123 Nguyen Trai, District 1, Ho Chi Minh City', N'duc123d@gmail.com', N'Doctor', 0, CAST(N'2023-03-17T10:52:18.3745384' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11057, N'Tran Thi Anh', N'anhtran', N'anh123456', 27, N'female', N'Surgical department', N'surgery', N'0934567890', N'456 Le Thanh Ton, District 3, Ho Chi Minh City', N'AnhDoc123@gmail.com', N'Doctor', 0, CAST(N'2023-03-17T10:53:42.9790918' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11058, N'sdf', N'áda', N'đá', 0, N'male', N'ad', N'đâ', N'0987654321', N'123 Main Street', N'john.smith@example.com', N'Doctor', 1, CAST(N'2023-03-24T14:09:23.1954783' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11059, N'string', N'string123', N'3PjDyzfx', 15, N'male', N'string', N'string', N'0949616315', N'string', N'string', N'Doctor', 1, CAST(N'2023-04-03T09:52:59.3983401' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11060, N'dasd', N'hieu1233', N'ZB7KFkaM', 33, N'male', N'dasdasd', N'dasd', N'0341648232', N'asdasd', N'fasdf@gma.com', N'Doctor', 1, CAST(N'2023-04-03T10:00:06.0169122' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11061, N'dasd', N'test1123', N'7rQvbyuw', 33, N'male', N'dasdasd', NULL, N'0341648332', N'asdasd', N'fasdf12@gma.com', N'Doctor', 1, CAST(N'2023-04-03T10:14:55.1154884' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11062, N'string', N'string', N'm4cFVmzR', 13, N'male', N'string', N'string', N'string', N'', N'string', N'Doctor', 1, CAST(N'2023-04-03T11:03:54.6191688' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11063, N'string', N'string', N'ckOs9vWX', 13, N'male', N'string', N'string', N'string', NULL, N'string', N'Doctor', 1, CAST(N'2023-04-03T11:08:46.2997656' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11064, N'asd', N'vajsv', N'aXtuTAVx', 33, N'male', N'dasd', NULL, N'0916655315', NULL, N'bac1@masd.com', N'Doctor', 1, CAST(N'2023-04-03T13:26:47.5013354' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11065, N'test12333', N'asfasdf', N'mZepHwi8', 33, N'male', N'dasd', NULL, N'0916633153', NULL, N'bac12@masd.com', N'Doctor', 1, CAST(N'2023-04-03T13:39:07.9576528' AS DateTime2))
INSERT [dbo].[Staffs] ([staffId], [staffName], [userName], [password], [age], [gender], [department], [specialization], [phoneNumber], [address], [email], [role], [isDelete], [lastAccess]) VALUES (11066, N'Robert Lee', N'rlee123', N'robert789', 42, N'male', N'Paramedical department', N'anesthesiology', N'0965432189', N'Da Nang', N'robert.lee@example.com', N'Doctor', 0, CAST(N'2023-04-03T14:00:58.5185643' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Staffs] OFF
GO
SET IDENTITY_INSERT [dbo].[SurgeryRequest] ON 

INSERT [dbo].[SurgeryRequest] ([surgeryRequestId], [surgeryTpye], [surgeryDate], [status], [description], [isDelete], [patientId], [staffId], [lastModified]) VALUES (7, N'Cholecystectomy', N'2023-03-14', N'Complete', N'abc', 0, 2, 11049, CAST(N'2023-03-17T15:15:42.8925025' AS DateTime2))
INSERT [dbo].[SurgeryRequest] ([surgeryRequestId], [surgeryTpye], [surgeryDate], [status], [description], [isDelete], [patientId], [staffId], [lastModified]) VALUES (8, N'Coronary artery bypass grafting (CABG)', N'2023-03-21', N'Complete', N'abc', 0, 4, 11038, CAST(N'2023-03-17T15:15:42.2973073' AS DateTime2))
INSERT [dbo].[SurgeryRequest] ([surgeryRequestId], [surgeryTpye], [surgeryDate], [status], [description], [isDelete], [patientId], [staffId], [lastModified]) VALUES (9, N'Appendectomy', N'2023-03-20', N'Complete', N'abc', 1, 11, 11050, CAST(N'2023-03-14T15:43:02.5386796' AS DateTime2))
INSERT [dbo].[SurgeryRequest] ([surgeryRequestId], [surgeryTpye], [surgeryDate], [status], [description], [isDelete], [patientId], [staffId], [lastModified]) VALUES (10, N'Coronary artery bypass grafting (CABG)', N'2023-03-16', N'In-Queue', N'aasdfas', 0, 16, 11050, CAST(N'2023-03-15T14:44:06.4610158' AS DateTime2))
INSERT [dbo].[SurgeryRequest] ([surgeryRequestId], [surgeryTpye], [surgeryDate], [status], [description], [isDelete], [patientId], [staffId], [lastModified]) VALUES (11, N'Cholecystectomy', N'2023-03-19', N'In-Queue', N'fbsdfbsdf', 0, 25, 11056, CAST(N'2023-03-17T14:49:13.8757860' AS DateTime2))
INSERT [dbo].[SurgeryRequest] ([surgeryRequestId], [surgeryTpye], [surgeryDate], [status], [description], [isDelete], [patientId], [staffId], [lastModified]) VALUES (12, N'Coronary artery bypass grafting (CABG)', N'2023-03-21', N'In-Queue', N'ádfasvas', 0, 22, 11050, CAST(N'2023-03-17T14:49:33.4525476' AS DateTime2))
INSERT [dbo].[SurgeryRequest] ([surgeryRequestId], [surgeryTpye], [surgeryDate], [status], [description], [isDelete], [patientId], [staffId], [lastModified]) VALUES (13, N'Coronary artery bypass grafting (CABG)', N'2023-03-19', N'In-Queue', N'vvavvaavavaavva', 0, 1, 11050, CAST(N'2023-03-17T15:15:37.0384378' AS DateTime2))
INSERT [dbo].[SurgeryRequest] ([surgeryRequestId], [surgeryTpye], [surgeryDate], [status], [description], [isDelete], [patientId], [staffId], [lastModified]) VALUES (14, N'Mastectomy', N'2023-03-18', N'In-Queue', N'vaavavaefvsfbt ', 0, 24, 11050, CAST(N'2023-03-17T15:16:15.1574064' AS DateTime2))
INSERT [dbo].[SurgeryRequest] ([surgeryRequestId], [surgeryTpye], [surgeryDate], [status], [description], [isDelete], [patientId], [staffId], [lastModified]) VALUES (15, N'Rhinoplasty', N'2023-03-24', N'In-Queue', N'scasef', 0, 24, 11049, CAST(N'2023-03-17T15:29:46.4237234' AS DateTime2))
SET IDENTITY_INSERT [dbo].[SurgeryRequest] OFF
GO
SET IDENTITY_INSERT [dbo].[UrineTestInfors] ON 

INSERT [dbo].[UrineTestInfors] ([urineTestId], [mediclatestype], [color], [calrity], [odor], [specificgravity], [glucose], [description], [isDelete], [patientId], [lastModified]) VALUES (3, N'string', N'string', N'string', N'string', N'string', 0, N'string', 0, 18, CAST(N'2023-03-12T10:24:19.8932693' AS DateTime2))
INSERT [dbo].[UrineTestInfors] ([urineTestId], [mediclatestype], [color], [calrity], [odor], [specificgravity], [glucose], [description], [isDelete], [patientId], [lastModified]) VALUES (4, N'Urine Test', N'Amber or honey-colored', N'Cloudy', N'Sweet or fruity', N'Isosthenuria', 2.8, N'abc', 0, 18, CAST(N'2023-03-12T19:31:32.3099232' AS DateTime2))
INSERT [dbo].[UrineTestInfors] ([urineTestId], [mediclatestype], [color], [calrity], [odor], [specificgravity], [glucose], [description], [isDelete], [patientId], [lastModified]) VALUES (5, N'Urine Test', N'Pale yellow to clear', N'Clear', N'Ammonia', N'Normal', 3.9, N'Normal hydration and kidney function, as well as normal levels of glucose in the urine. The specific gravity value is within the normal range, indicating that the kidneys are able to concentrate urine properly.', 0, 4, CAST(N'2023-03-13T09:18:35.9610035' AS DateTime2))
INSERT [dbo].[UrineTestInfors] ([urineTestId], [mediclatestype], [color], [calrity], [odor], [specificgravity], [glucose], [description], [isDelete], [patientId], [lastModified]) VALUES (6, N'Urine Test', N'Amber or honey-colored', N'Cloudy', N'Ammonia', N'Normal', 1.9, N'amber in color, slightly cloudy in clarity, and has a strong odor. The specific gravity value is within the normal range, The glucose test result is negative, indicating that there is no glucose present in the urine', 0, 15, CAST(N'2023-03-13T09:18:03.0049439' AS DateTime2))
SET IDENTITY_INSERT [dbo].[UrineTestInfors] OFF
GO
/****** Object:  Index [IX_BloodTestInfors_patientId]    Script Date: 4/5/2023 2:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_BloodTestInfors_patientId] ON [dbo].[BloodTestInfors]
(
	[patientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Discharges_patientId]    Script Date: 4/5/2023 2:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Discharges_patientId] ON [dbo].[Discharges]
(
	[patientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InPatients_patientId]    Script Date: 4/5/2023 2:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_InPatients_patientId] ON [dbo].[InPatients]
(
	[patientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InPatients_staffId]    Script Date: 4/5/2023 2:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_InPatients_staffId] ON [dbo].[InPatients]
(
	[staffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OutPatients_patientId]    Script Date: 4/5/2023 2:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_OutPatients_patientId] ON [dbo].[OutPatients]
(
	[patientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OutPatients_staffId]    Script Date: 4/5/2023 2:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_OutPatients_staffId] ON [dbo].[OutPatients]
(
	[staffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PharmaceInfors_medicineId]    Script Date: 4/5/2023 2:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_PharmaceInfors_medicineId] ON [dbo].[PharmaceInfors]
(
	[medicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PharmaceInfors_patientId]    Script Date: 4/5/2023 2:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_PharmaceInfors_patientId] ON [dbo].[PharmaceInfors]
(
	[patientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SurgeryInfors_surgeryRequestId]    Script Date: 4/5/2023 2:58:35 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SurgeryInfors_surgeryRequestId] ON [dbo].[SurgeryInfors]
(
	[surgeryRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SurgeryRequest_patientId]    Script Date: 4/5/2023 2:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_SurgeryRequest_patientId] ON [dbo].[SurgeryRequest]
(
	[patientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SurgeryRequest_staffId]    Script Date: 4/5/2023 2:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_SurgeryRequest_staffId] ON [dbo].[SurgeryRequest]
(
	[staffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UrineTestInfors_patientId]    Script Date: 4/5/2023 2:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_UrineTestInfors_patientId] ON [dbo].[UrineTestInfors]
(
	[patientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BloodTestInfors] ADD  DEFAULT (N'') FOR [description]
GO
ALTER TABLE [dbo].[BloodTestInfors] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [lastModified]
GO
ALTER TABLE [dbo].[Discharges] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [lastModified]
GO
ALTER TABLE [dbo].[InPatients] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [lastModified]
GO
ALTER TABLE [dbo].[Medicines] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [lastModified]
GO
ALTER TABLE [dbo].[OutPatients] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [lastModified]
GO
ALTER TABLE [dbo].[Patients] ADD  DEFAULT (N'') FOR [occupation]
GO
ALTER TABLE [dbo].[Patients] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [lastModified]
GO
ALTER TABLE [dbo].[PharmaceInfors] ADD  DEFAULT (N'') FOR [description]
GO
ALTER TABLE [dbo].[PharmaceInfors] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [lastModified]
GO
ALTER TABLE [dbo].[PharmaceInfors] ADD  DEFAULT ((0)) FOR [medicineId]
GO
ALTER TABLE [dbo].[PharmaceInfors] ADD  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[Staffs] ADD  DEFAULT (N'') FOR [email]
GO
ALTER TABLE [dbo].[Staffs] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [lastAccess]
GO
ALTER TABLE [dbo].[SurgeryInfors] ADD  DEFAULT (N'') FOR [description]
GO
ALTER TABLE [dbo].[SurgeryInfors] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [lastModified]
GO
ALTER TABLE [dbo].[SurgeryRequest] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [lastModified]
GO
ALTER TABLE [dbo].[UrineTestInfors] ADD  DEFAULT (N'') FOR [description]
GO
ALTER TABLE [dbo].[UrineTestInfors] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [lastModified]
GO
ALTER TABLE [dbo].[BloodTestInfors]  WITH CHECK ADD  CONSTRAINT [FK_BloodTestInfors_Patients_patientId] FOREIGN KEY([patientId])
REFERENCES [dbo].[Patients] ([patientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BloodTestInfors] CHECK CONSTRAINT [FK_BloodTestInfors_Patients_patientId]
GO
ALTER TABLE [dbo].[Discharges]  WITH CHECK ADD  CONSTRAINT [FK_Discharges_Patients_patientId] FOREIGN KEY([patientId])
REFERENCES [dbo].[Patients] ([patientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Discharges] CHECK CONSTRAINT [FK_Discharges_Patients_patientId]
GO
ALTER TABLE [dbo].[InPatients]  WITH CHECK ADD  CONSTRAINT [FK_InPatients_Patients_patientId] FOREIGN KEY([patientId])
REFERENCES [dbo].[Patients] ([patientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InPatients] CHECK CONSTRAINT [FK_InPatients_Patients_patientId]
GO
ALTER TABLE [dbo].[InPatients]  WITH CHECK ADD  CONSTRAINT [FK_InPatients_Staffs_staffId] FOREIGN KEY([staffId])
REFERENCES [dbo].[Staffs] ([staffId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InPatients] CHECK CONSTRAINT [FK_InPatients_Staffs_staffId]
GO
ALTER TABLE [dbo].[OutPatients]  WITH CHECK ADD  CONSTRAINT [FK_OutPatients_Patients_patientId] FOREIGN KEY([patientId])
REFERENCES [dbo].[Patients] ([patientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OutPatients] CHECK CONSTRAINT [FK_OutPatients_Patients_patientId]
GO
ALTER TABLE [dbo].[OutPatients]  WITH CHECK ADD  CONSTRAINT [FK_OutPatients_Staffs_staffId] FOREIGN KEY([staffId])
REFERENCES [dbo].[Staffs] ([staffId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OutPatients] CHECK CONSTRAINT [FK_OutPatients_Staffs_staffId]
GO
ALTER TABLE [dbo].[PharmaceInfors]  WITH CHECK ADD  CONSTRAINT [FK_PharmaceInfors_Medicines_medicineId] FOREIGN KEY([medicineId])
REFERENCES [dbo].[Medicines] ([medicineId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PharmaceInfors] CHECK CONSTRAINT [FK_PharmaceInfors_Medicines_medicineId]
GO
ALTER TABLE [dbo].[PharmaceInfors]  WITH CHECK ADD  CONSTRAINT [FK_PharmaceInfors_Patients_patientId] FOREIGN KEY([patientId])
REFERENCES [dbo].[Patients] ([patientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PharmaceInfors] CHECK CONSTRAINT [FK_PharmaceInfors_Patients_patientId]
GO
ALTER TABLE [dbo].[SurgeryInfors]  WITH CHECK ADD  CONSTRAINT [FK_SurgeryInfors_SurgeryRequest_surgeryRequestId] FOREIGN KEY([surgeryRequestId])
REFERENCES [dbo].[SurgeryRequest] ([surgeryRequestId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SurgeryInfors] CHECK CONSTRAINT [FK_SurgeryInfors_SurgeryRequest_surgeryRequestId]
GO
ALTER TABLE [dbo].[SurgeryRequest]  WITH CHECK ADD  CONSTRAINT [FK_SurgeryRequest_Patients_patientId] FOREIGN KEY([patientId])
REFERENCES [dbo].[Patients] ([patientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SurgeryRequest] CHECK CONSTRAINT [FK_SurgeryRequest_Patients_patientId]
GO
ALTER TABLE [dbo].[SurgeryRequest]  WITH CHECK ADD  CONSTRAINT [FK_SurgeryRequest_Staffs_staffId] FOREIGN KEY([staffId])
REFERENCES [dbo].[Staffs] ([staffId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SurgeryRequest] CHECK CONSTRAINT [FK_SurgeryRequest_Staffs_staffId]
GO
ALTER TABLE [dbo].[UrineTestInfors]  WITH CHECK ADD  CONSTRAINT [FK_UrineTestInfors_Patients_patientId] FOREIGN KEY([patientId])
REFERENCES [dbo].[Patients] ([patientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UrineTestInfors] CHECK CONSTRAINT [FK_UrineTestInfors_Patients_patientId]
GO
/****** Object:  StoredProcedure [dbo].[getInpatientByDepartment]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[getInpatientByDepartment] 
	 @department nvarchar(50)
as
select InPatients.*,patientName,staffName from InPatients 
inner join Patients on InPatients.patientId = Patients.patientId 
inner join Staffs on InPatients.staffId = Staffs.staffId  
where InPatients.isDelete = 0 and InPatients.department=@department order by InPatients.lastModified desc 
GO
/****** Object:  StoredProcedure [dbo].[getListBloodTest]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[getListBloodTest]
as
Select BloodTestInfors.*, Patients.patientName
from BloodTestInfors inner join Patients
on BloodTestInfors.patientId = Patients.patientId where BloodTestInfors.isDelete = 0 order by BloodTestInfors.lastModified desc;
GO
/****** Object:  StoredProcedure [dbo].[getListInPatientWithDoctorName]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[getListInPatientWithDoctorName]
	@patientId int
as
SELECT inPatientId,familyPhone,dateIn,dateOut,symptoms,InPatients.department,wardNum,bedNum,patientId,InPatients.staffId,InPatients.isDelete,lastModified, Staffs.staffName
FROM InPatients
INNER JOIN Staffs
ON InPatients.staffId = Staffs.staffId where InPatients.isDelete = 0 and patientId = @patientId order by lastModified desc;
GO
/****** Object:  StoredProcedure [dbo].[getListOutPatientWithDoctorName]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getListOutPatientWithDoctorName]
@patientId int
as
SELECT outPatientId,familyPhone,onDate,OutPatients.department,patientId,OutPatients.staffId,OutPatients.isDelete,lastModified, Staffs.staffName
FROM OutPatients
INNER JOIN Staffs
ON OutPatients.staffId = Staffs.staffId where OutPatients.isDelete = 0 and patientId = @patientId order by lastModified desc;
GO
/****** Object:  StoredProcedure [dbo].[getListUrineTest]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getListUrineTest]
as
Select UrineTestInfors.*, Patients.patientName
from UrineTestInfors inner join Patients
on UrineTestInfors.patientId = Patients.patientId where UrineTestInfors.isDelete = 0 order by UrineTestInfors.lastModified desc;
GO
/****** Object:  StoredProcedure [dbo].[getMedicinebyName]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getMedicinebyName] 
 @medicineName nvarchar(50)
as
select * from Medicines where isdelete = 0 and medicineName = @medicineName 
GO
/****** Object:  StoredProcedure [dbo].[getOutpatientByDepartment]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[getOutpatientByDepartment] 
	 @department nvarchar(50)
as
select OutPatients.*,patientName,staffName from OutPatients 
inner join Patients on OutPatients.patientId = Patients.patientId 
inner join Staffs on OutPatients.staffId = Staffs.staffId  
where OutPatients.isDelete = 0 and OutPatients.department=@department order by OutPatients.lastModified desc 
GO
/****** Object:  StoredProcedure [dbo].[getPharmacyByPatientId]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE procedure [dbo].[getPharmacyByPatientId]
   @patientId int
  as 
  select PharmaceInfors.*, Medicines.medicineName, Patients.patientName  from PharmaceInfors
inner join Patients on PharmaceInfors.patientId = Patients.patientId 
inner join Medicines on Medicines.medicineId = PharmaceInfors.medicineId  where PharmaceInfors.isDelete = 0 and PharmaceInfors.patientId = @patientId order by PharmaceInfors.lastModified desc
GO
/****** Object:  StoredProcedure [dbo].[getPharmacyInforBydepartment]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getPharmacyInforBydepartment]
	@department nvarchar(50)
as

select PharmaceInfors.*, Medicines.medicineName, Patients.patientName  from PharmaceInfors
inner join Patients on PharmaceInfors.patientId = Patients.patientId 
inner join Medicines on Medicines.medicineId = PharmaceInfors.medicineId 
where PharmaceInfors.isDelete =0 and department = @department order by lastModified desc
GO
/****** Object:  StoredProcedure [dbo].[getSurgeryDoctor]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getSurgeryDoctor]
as
select * from Staffs where isDelete=0 and role='Doctor' and specialization='surgery' order by [lastAccess] desc
GO
/****** Object:  StoredProcedure [dbo].[getSurgeryRequestbyStaffId]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[getSurgeryRequestbyStaffId]
	@staffId int
as
select SurgeryRequest.*, patientName, staffName from SurgeryRequest
inner join Staffs on SurgeryRequest.staffId = Staffs.staffId 
inner join Patients on SurgeryRequest.patientId = Patients.patientId
where SurgeryRequest.isDelete =0  and SurgeryRequest.staffId = @staffId order by lastModified desc
GO
/****** Object:  StoredProcedure [dbo].[getSurgeryRequestWithName]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getSurgeryRequestWithName]
as
select SurgeryRequest.*,Patients.patientName, Staffs.staffName
from SurgeryRequest 
inner join Patients on SurgeryRequest.patientId = Patients.patientId 
inner join Staffs on SurgeryRequest.staffId = Staffs.staffId 
where SurgeryRequest.isDelete = 0 
order by SurgeryRequest.lastModified desc
GO
/****** Object:  StoredProcedure [dbo].[getTotalItem]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE procedure [dbo].[getTotalItem]
	@SearchText nvarchar(100)
  AS
  select 
  Case WHEN @SearchText <> 'none' then( select count(*) from Staffs 
		Where (isDelete = 0 and role ='Doctor') and (
			staffName like '%' + @SearchText +'%' or
			age  like '%' + @SearchText +'%' or
			gender  like '%' + @SearchText +'%' or
			department like '%' + @SearchText +'%' or
			specialization like '%' + @SearchText +'%' or
			phoneNumber like '%' + @SearchText +'%' or
			[address] like '%' + @SearchText +'%' or
			email like '%' + @SearchText +'%' 
		) )
	Else (Select count(*) from Staffs where (isDelete= 0 and role='Doctor')) end
GO
/****** Object:  StoredProcedure [dbo].[select_staff_data_for_page]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[select_staff_data_for_page]
    @pageNumber INT,
    @pageSize INT,
    @sortByColumn NVARCHAR(50),
    @sortOrder NVARCHAR(4),
    @searchText NVARCHAR(100)
AS
BEGIN
    DECLARE @startIndex INT, @endIndex INT,@totalItem int;
	SET @totalItem = dbo.getTotalItemFunc(@searchText);
    SET @startIndex = (@pageNumber - 1) * @pageSize + 1;
	if @startIndex + @pageNumber - 1 <= @totalItem 
	begin
		SET @endIndex = @startIndex + @pageSize - 1;
	end
	else 
		begin 
			SET @endIndex = @totalItem;
		end

    DECLARE @sqlQuery NVARCHAR(MAX);
    SET @sqlQuery = 'SELECT * FROM (
                        SELECT ROW_NUMBER() OVER (ORDER BY ' + 
                                        CASE WHEN @sortByColumn = 'none' THEN 'LastAccess DESC'
                                        ELSE @sortByColumn + ' ' + @sortOrder END +
                                        ') AS RowNumber, *
                        FROM Staffs
                        WHERE isDelete = 0 AND role = ''Doctor''' + 
                        CASE WHEN @searchText <> 'none' THEN '  AND  ' +
                                                '(staffName LIKE ''%' + @searchText + '%'' OR ' +
                                                'age LIKE ''%' + @searchText + '%'' OR ' +
                                                'gender LIKE ''%' + @searchText + '%'' OR ' +
                                                'department LIKE ''%' + @searchText + '%'' OR ' +
                                                'specialization LIKE ''%' + @searchText + '%'' OR ' +
                                                'address LIKE ''%' + @searchText + '%'' OR ' +
                                                'phoneNumber LIKE ''%' + @searchText + '%'' OR ' +
                                                'email LIKE ''%' + @searchText + '%'')'
                                        ELSE '' END + 
                    ') AS T
                    WHERE T.RowNumber BETWEEN ' + CAST(@startIndex AS NVARCHAR(10)) + ' AND ' + CAST(@endIndex AS NVARCHAR(10));

    EXEC(@sqlQuery);
END
GO
/****** Object:  StoredProcedure [dbo].[selectAllDoctors]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[selectAllDoctors] AS
SELECT * FROM Staffs where isDelete = 0 and role='Doctor';
GO
/****** Object:  StoredProcedure [dbo].[selectAllStaffs]    Script Date: 4/5/2023 2:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[selectAllStaffs] AS
SELECT * FROM Staffs;
GO
USE [master]
GO
ALTER DATABASE [HopitalManagerment] SET  READ_WRITE 
GO
