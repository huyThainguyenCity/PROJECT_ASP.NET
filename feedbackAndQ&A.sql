USE [master]
GO
/****** Object:  Database [ProjectPRN231_HuyDQ]    Script Date: 3/18/2024 9:56:18 PM ******/
CREATE DATABASE [ProjectPRN231_HuyDQ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectPRN231_HuyDQ', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MAYAO\MSSQL\DATA\ProjectPRN231_HuyDQ.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectPRN231_HuyDQ_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MAYAO\MSSQL\DATA\ProjectPRN231_HuyDQ_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectPRN231_HuyDQ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectPRN231_HuyDQ', N'ON'
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET QUERY_STORE = OFF
GO
USE [ProjectPRN231_HuyDQ]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 3/18/2024 9:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[role_id] [int] NULL,
	[FullName] [nvarchar](50) NULL,
	[TeacherCode] [nvarchar](50) NULL,
	[StudentCode] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[PhoneNumber] [int] NULL,
	[Avatar] [nvarchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 3/18/2024 9:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
	[AccountID] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 3/18/2024 9:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuenstionID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
	[AccountID] [int] NULL,
	[Answer_Description] [nvarchar](500) NULL,
	[ReplyDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QuenstionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/18/2024 9:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] NOT NULL,
	[role_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 3/18/2024 9:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](50) NULL,
	[SubjectCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject_Account]    Script Date: 3/18/2024 9:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject_Account](
	[Subject_Account_id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[AccountID] [int] NULL,
 CONSTRAINT [PK_Subject_Account] PRIMARY KEY CLUSTERED 
(
	[Subject_Account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountID], [username], [password], [role_id], [FullName], [TeacherCode], [StudentCode], [Address], [PhoneNumber], [Avatar]) VALUES (0, N'quan', N'123', 2, N'nguyen thai quan', NULL, N'HE153695', N'ha noi', 912546876, NULL)
INSERT [dbo].[Account] ([AccountID], [username], [password], [role_id], [FullName], [TeacherCode], [StudentCode], [Address], [PhoneNumber], [Avatar]) VALUES (1, N'huy', N'123', 1, N'do quang huy', N'HuyDQ', NULL, N'thai nguyen', 989668350, NULL)
INSERT [dbo].[Account] ([AccountID], [username], [password], [role_id], [FullName], [TeacherCode], [StudentCode], [Address], [PhoneNumber], [Avatar]) VALUES (2, N'hoang', N'123', 2, N'nguyen huy hoang', NULL, N'HV167584', N'hoa lac', 989668350, NULL)
INSERT [dbo].[Account] ([AccountID], [username], [password], [role_id], [FullName], [TeacherCode], [StudentCode], [Address], [PhoneNumber], [Avatar]) VALUES (10, N'dat', N'123', 2, N'nguyen tien dat', NULL, N'HS143923', N'hoa lac', 987476235, NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([FeedbackID], [SubjectID], [Description], [CreateDate], [AccountID], [Status]) VALUES (3, 1, N'Thầy đẹp trai', CAST(N'2022-03-02T00:00:00.000' AS DateTime), 10, NULL)
INSERT [dbo].[Feedback] ([FeedbackID], [SubjectID], [Description], [CreateDate], [AccountID], [Status]) VALUES (4, 2, N'Thầy quá oce', CAST(N'2022-03-02T00:00:00.000' AS DateTime), 2, NULL)
INSERT [dbo].[Feedback] ([FeedbackID], [SubjectID], [Description], [CreateDate], [AccountID], [Status]) VALUES (11, 1, N'Thầy dạy dễ hiểu', CAST(N'2022-03-02T00:00:00.000' AS DateTime), 2, NULL)
INSERT [dbo].[Feedback] ([FeedbackID], [SubjectID], [Description], [CreateDate], [AccountID], [Status]) VALUES (12, 1, N'Thầy hay trả lời câu hỏi cuối buổi', CAST(N'2022-03-02T00:00:00.000' AS DateTime), 2, NULL)
INSERT [dbo].[Feedback] ([FeedbackID], [SubjectID], [Description], [CreateDate], [AccountID], [Status]) VALUES (15, 1, N'Thầy dạy rất hay', CAST(N'2024-03-18T21:19:48.763' AS DateTime), 2, NULL)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([QuenstionID], [SubjectID], [Description], [CreateDate], [AccountID], [Answer_Description], [ReplyDate], [Status]) VALUES (1, 2, N'Phần lab1 hôm nay của em chưa nộp ạ', CAST(N'2024-03-02T00:00:00.000' AS DateTime), 2, NULL, NULL, NULL)
INSERT [dbo].[Question] ([QuenstionID], [SubjectID], [Description], [CreateDate], [AccountID], [Answer_Description], [ReplyDate], [Status]) VALUES (2, 2, N'Em muốn nghỉ học', CAST(N'2024-03-02T00:00:00.000' AS DateTime), 2, NULL, NULL, NULL)
INSERT [dbo].[Question] ([QuenstionID], [SubjectID], [Description], [CreateDate], [AccountID], [Answer_Description], [ReplyDate], [Status]) VALUES (3, 1, N'Em xin phép nghỉ buổi hôm nay ạ', CAST(N'2024-03-02T00:00:00.000' AS DateTime), 2, N'Không được em nhé', CAST(N'2024-03-18T21:18:00.840' AS DateTime), NULL)
INSERT [dbo].[Question] ([QuenstionID], [SubjectID], [Description], [CreateDate], [AccountID], [Answer_Description], [ReplyDate], [Status]) VALUES (4, 1, N'Em chào thầy, em có một số lỗ hổng kiến thức ạ', CAST(N'2024-03-02T00:00:00.000' AS DateTime), 2, N'tôi không đồng ý', CAST(N'2022-03-03T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Question] ([QuenstionID], [SubjectID], [Description], [CreateDate], [AccountID], [Answer_Description], [ReplyDate], [Status]) VALUES (5, 1, N'Thái Quân hôm nay xin nghỉ', CAST(N'2024-03-02T00:00:00.000' AS DateTime), 10, NULL, NULL, NULL)
INSERT [dbo].[Question] ([QuenstionID], [SubjectID], [Description], [CreateDate], [AccountID], [Answer_Description], [ReplyDate], [Status]) VALUES (8, 1, N'em muốn đặt câu hỏi ạ', CAST(N'2024-03-09T16:49:30.547' AS DateTime), 2, NULL, NULL, NULL)
INSERT [dbo].[Question] ([QuenstionID], [SubjectID], [Description], [CreateDate], [AccountID], [Answer_Description], [ReplyDate], [Status]) VALUES (9, 2, N'em xin lỗi', CAST(N'2024-03-09T17:01:28.233' AS DateTime), 2, NULL, NULL, NULL)
INSERT [dbo].[Question] ([QuenstionID], [SubjectID], [Description], [CreateDate], [AccountID], [Answer_Description], [ReplyDate], [Status]) VALUES (10, 1, N'em hỏi nhé', CAST(N'2024-03-09T17:05:36.497' AS DateTime), 2, NULL, NULL, NULL)
INSERT [dbo].[Question] ([QuenstionID], [SubjectID], [Description], [CreateDate], [AccountID], [Answer_Description], [ReplyDate], [Status]) VALUES (11, 1, N'pt1 đề sai', CAST(N'2024-03-09T17:08:17.847' AS DateTime), 2, NULL, NULL, NULL)
INSERT [dbo].[Question] ([QuenstionID], [SubjectID], [Description], [CreateDate], [AccountID], [Answer_Description], [ReplyDate], [Status]) VALUES (12, 3, N'Ơ ', CAST(N'2024-03-10T00:22:52.907' AS DateTime), 2, NULL, NULL, NULL)
INSERT [dbo].[Question] ([QuenstionID], [SubjectID], [Description], [CreateDate], [AccountID], [Answer_Description], [ReplyDate], [Status]) VALUES (13, 1, N'Thầy ơi, pe 3 điểm thì project mấy là qua ạ', CAST(N'2024-03-18T21:19:15.517' AS DateTime), 2, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
INSERT [dbo].[Role] ([role_id], [role_name]) VALUES (1, N'teacher')
INSERT [dbo].[Role] ([role_id], [role_name]) VALUES (2, N'student')
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([SubjectID], [SubjectName], [SubjectCode]) VALUES (1, N'DataStructor', N'PRN221')
INSERT [dbo].[Subject] ([SubjectID], [SubjectName], [SubjectCode]) VALUES (2, N'Dalalogist', N'PRJ301')
INSERT [dbo].[Subject] ([SubjectID], [SubjectName], [SubjectCode]) VALUES (3, N'DataStructor and Dalalogist', N'LAB211')
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject_Account] ON 

INSERT [dbo].[Subject_Account] ([Subject_Account_id], [SubjectID], [AccountID]) VALUES (1, 1, 1)
INSERT [dbo].[Subject_Account] ([Subject_Account_id], [SubjectID], [AccountID]) VALUES (2, 1, 2)
INSERT [dbo].[Subject_Account] ([Subject_Account_id], [SubjectID], [AccountID]) VALUES (3, 2, 1)
INSERT [dbo].[Subject_Account] ([Subject_Account_id], [SubjectID], [AccountID]) VALUES (4, 2, 2)
INSERT [dbo].[Subject_Account] ([Subject_Account_id], [SubjectID], [AccountID]) VALUES (5, 1, 10)
INSERT [dbo].[Subject_Account] ([Subject_Account_id], [SubjectID], [AccountID]) VALUES (6, 2, 10)
SET IDENTITY_INSERT [dbo].[Subject_Account] OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Account]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Subject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([SubjectID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Subject]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Account]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Subject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([SubjectID])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Subject]
GO
ALTER TABLE [dbo].[Subject_Account]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Account_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Subject_Account] CHECK CONSTRAINT [FK_Subject_Account_Account]
GO
ALTER TABLE [dbo].[Subject_Account]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Account_Subject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([SubjectID])
GO
ALTER TABLE [dbo].[Subject_Account] CHECK CONSTRAINT [FK_Subject_Account_Subject]
GO
USE [master]
GO
ALTER DATABASE [ProjectPRN231_HuyDQ] SET  READ_WRITE 
GO
