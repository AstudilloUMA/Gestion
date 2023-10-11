USE [master]
GO
/****** Object:  Database [rediam]    Script Date: 11/10/2023 16:33:12 ******/
CREATE DATABASE [rediam]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'rediam', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\rediam.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'rediam_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\rediam_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [rediam] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [rediam].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [rediam] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [rediam] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [rediam] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [rediam] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [rediam] SET ARITHABORT OFF 
GO
ALTER DATABASE [rediam] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [rediam] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [rediam] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [rediam] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [rediam] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [rediam] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [rediam] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [rediam] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [rediam] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [rediam] SET  ENABLE_BROKER 
GO
ALTER DATABASE [rediam] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [rediam] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [rediam] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [rediam] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [rediam] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [rediam] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [rediam] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [rediam] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [rediam] SET  MULTI_USER 
GO
ALTER DATABASE [rediam] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [rediam] SET DB_CHAINING OFF 
GO
ALTER DATABASE [rediam] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [rediam] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [rediam] SET DELAYED_DURABILITY = DISABLED 
GO
USE [rediam]
GO
/****** Object:  Table [dbo].[Montes]    Script Date: 11/10/2023 16:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Montes](
	[CODIGO_MONTE] [int] NOT NULL,
	[COD_PROVINCIA] [nchar](2) NOT NULL,
	[ESPACIO_NATURAL] [varchar](255) NOT NULL,
	[SUPERFICIE] [decimal](18, 0) NOT NULL,
	[NUMERO_MONTES] [int] NOT NULL,
 CONSTRAINT [PK_Montes] PRIMARY KEY CLUSTERED 
(
	[CODIGO_MONTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 11/10/2023 16:33:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[Codigo] [nchar](2) NOT NULL,
	[Provincia] [nchar](40) NOT NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Provincias] ([Codigo], [Provincia]) VALUES (N'AL', N'ALMERÍA                                 ')
INSERT [dbo].[Provincias] ([Codigo], [Provincia]) VALUES (N'CA', N'CÁDIZ                                   ')
INSERT [dbo].[Provincias] ([Codigo], [Provincia]) VALUES (N'CO', N'CÓRDOBA                                 ')
INSERT [dbo].[Provincias] ([Codigo], [Provincia]) VALUES (N'GR', N'GRANADA                                 ')
INSERT [dbo].[Provincias] ([Codigo], [Provincia]) VALUES (N'H ', N'HUELVA                                  ')
INSERT [dbo].[Provincias] ([Codigo], [Provincia]) VALUES (N'J ', N'JAEN                                    ')
INSERT [dbo].[Provincias] ([Codigo], [Provincia]) VALUES (N'MA', N'MÁLAGA                                  ')
INSERT [dbo].[Provincias] ([Codigo], [Provincia]) VALUES (N'SE', N'SEVILLA                                 ')
ALTER TABLE [dbo].[Montes]  WITH CHECK ADD  CONSTRAINT [FK_Montes_Provincias] FOREIGN KEY([COD_PROVINCIA])
REFERENCES [dbo].[Provincias] ([Codigo])
GO
ALTER TABLE [dbo].[Montes] CHECK CONSTRAINT [FK_Montes_Provincias]
GO
USE [master]
GO
ALTER DATABASE [rediam] SET  READ_WRITE 
GO
