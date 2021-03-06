USE [master]
GO
/****** Object:  Database [survey]    Script Date: 24.04.2020 17:29:09 ******/
CREATE DATABASE [survey]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'survey', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\survey.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'survey_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\survey_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [survey] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [survey].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [survey] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [survey] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [survey] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [survey] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [survey] SET ARITHABORT OFF 
GO
ALTER DATABASE [survey] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [survey] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [survey] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [survey] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [survey] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [survey] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [survey] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [survey] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [survey] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [survey] SET  DISABLE_BROKER 
GO
ALTER DATABASE [survey] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [survey] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [survey] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [survey] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [survey] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [survey] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [survey] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [survey] SET RECOVERY FULL 
GO
ALTER DATABASE [survey] SET  MULTI_USER 
GO
ALTER DATABASE [survey] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [survey] SET DB_CHAINING OFF 
GO
ALTER DATABASE [survey] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [survey] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [survey] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'survey', N'ON'
GO
ALTER DATABASE [survey] SET QUERY_STORE = OFF
GO
USE [survey]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 24.04.2020 17:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Answer_options] [int] NULL,
	[id_Users] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Answer_options]    Script Date: 24.04.2020 17:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer_options](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[answer] [nvarchar](max) NULL,
	[id_Question] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 24.04.2020 17:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[question] [nvarchar](max) NOT NULL,
	[id_Users] [int] NULL,
	[addAnswer] [tinyint] NULL,
	[createDate] [datetime2](7) NULL,
	[expiresOn] [datetime2](7) NULL,
	[isCompleted] [bit] NULL,
	[isHidden] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24.04.2020 17:29:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](max) NULL,
	[password_email] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer_options] ON 

INSERT [dbo].[Answer_options] ([id], [answer], [id_Question]) VALUES (1, N'Завтра', 1)
INSERT [dbo].[Answer_options] ([id], [answer], [id_Question]) VALUES (2, N'10', 1)
INSERT [dbo].[Answer_options] ([id], [answer], [id_Question]) VALUES (3, N'Никогда', NULL)
SET IDENTITY_INSERT [dbo].[Answer_options] OFF
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([id], [question], [id_Users], [addAnswer], [createDate], [expiresOn], [isCompleted], [isHidden]) VALUES (1, N'Когда закончится канантин?', 1, 0, CAST(N'2020-04-24T16:54:32.8833333' AS DateTime2), CAST(N'2020-04-24T16:54:32.8833333' AS DateTime2), 0, 0)
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [email], [password_email]) VALUES (1, N'Nick', N'1111')
INSERT [dbo].[Users] ([id], [email], [password_email]) VALUES (2, N'Vasya', N'2222')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Question] ADD  DEFAULT ((0)) FOR [addAnswer]
GO
ALTER TABLE [dbo].[Question] ADD  DEFAULT (getdate()) FOR [createDate]
GO
ALTER TABLE [dbo].[Question] ADD  DEFAULT (getdate()) FOR [expiresOn]
GO
ALTER TABLE [dbo].[Question] ADD  DEFAULT ((0)) FOR [isCompleted]
GO
ALTER TABLE [dbo].[Question] ADD  DEFAULT ((0)) FOR [isHidden]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD FOREIGN KEY([id_Answer_options])
REFERENCES [dbo].[Answer_options] ([id])
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD FOREIGN KEY([id_Users])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Answer_options]  WITH CHECK ADD FOREIGN KEY([id_Question])
REFERENCES [dbo].[Question] ([id])
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD FOREIGN KEY([id_Users])
REFERENCES [dbo].[Users] ([id])
GO
USE [master]
GO
ALTER DATABASE [survey] SET  READ_WRITE 
GO
