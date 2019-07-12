/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.1742)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [db_Tickek_AtencionCliente]    Script Date: 12/07/2019 22:04:24 ******/
CREATE DATABASE [db_Tickek_AtencionCliente]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_Tickek_AtencionCliente', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\db_Tickek_AtencionCliente.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_Tickek_AtencionCliente_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\db_Tickek_AtencionCliente_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_Tickek_AtencionCliente].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET  MULTI_USER 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET QUERY_STORE = OFF
GO
USE [db_Tickek_AtencionCliente]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [db_Tickek_AtencionCliente]
GO
/****** Object:  User [quiensepega]    Script Date: 12/07/2019 22:04:24 ******/
CREATE USER [quiensepega] FOR LOGIN [quiensepega] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [quiensepega]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 12/07/2019 22:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cola]    Script Date: 12/07/2019 22:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cola](
	[IdCola] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[TiempoDuracionAtencion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCola] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ColaCliente]    Script Date: 12/07/2019 22:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColaCliente](
	[IdCola] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[EstadoAtencion] [char](1) NOT NULL,
 CONSTRAINT [ColaClient_PK] PRIMARY KEY CLUSTERED 
(
	[IdCola] ASC,
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [Nombres]) VALUES (1, N'María')
INSERT [dbo].[Cliente] ([Id], [Nombres]) VALUES (2, N'Olga')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
SET IDENTITY_INSERT [dbo].[Cola] ON 

INSERT [dbo].[Cola] ([IdCola], [Nombre], [TiempoDuracionAtencion]) VALUES (1, N'Cola1', 2)
INSERT [dbo].[Cola] ([IdCola], [Nombre], [TiempoDuracionAtencion]) VALUES (2, N'Cola2', 3)
SET IDENTITY_INSERT [dbo].[Cola] OFF
ALTER TABLE [dbo].[ColaCliente]  WITH CHECK ADD  CONSTRAINT [ColaCliente_Cliente_FK] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[ColaCliente] CHECK CONSTRAINT [ColaCliente_Cliente_FK]
GO
ALTER TABLE [dbo].[ColaCliente]  WITH CHECK ADD  CONSTRAINT [ColaCliente_ColaAtencionCliente_FK] FOREIGN KEY([IdCola])
REFERENCES [dbo].[Cola] ([IdCola])
GO
ALTER TABLE [dbo].[ColaCliente] CHECK CONSTRAINT [ColaCliente_ColaAtencionCliente_FK]
GO
USE [master]
GO
ALTER DATABASE [db_Tickek_AtencionCliente] SET  READ_WRITE 
GO
