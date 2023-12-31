USE [master]
GO
/****** Object:  Database [QLNV]    Script Date: 8/21/2023 3:27:05 PM ******/
CREATE DATABASE [QLNV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLNV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QLNV.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLNV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QLNV_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLNV] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLNV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLNV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLNV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLNV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLNV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLNV] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLNV] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLNV] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLNV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLNV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLNV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLNV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLNV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLNV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLNV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLNV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLNV] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLNV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLNV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLNV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLNV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLNV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLNV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLNV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLNV] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLNV] SET  MULTI_USER 
GO
ALTER DATABASE [QLNV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLNV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLNV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLNV] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLNV]
GO
/****** Object:  Table [dbo].[account]    Script Date: 8/21/2023 3:27:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[acc_id] [int] NULL,
	[acc_name] [nvarchar](255) NULL,
	[acc_password] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bangcap]    Script Date: 8/21/2023 3:27:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bangcap](
	[mabang] [int] NULL,
	[tenbang] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[chamcong]    Script Date: 8/21/2023 3:27:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chamcong](
	[manv] [int] NOT NULL,
	[tennv] [nvarchar](255) NULL,
	[id_matt] [int] NULL,
	[ngay] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[chucvu]    Script Date: 8/21/2023 3:27:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chucvu](
	[mach] [int] NULL,
	[tench] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[employee]    Script Date: 8/21/2023 3:27:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[id] [int] NOT NULL,
	[name] [nvarchar](255) NULL,
	[ngsinh] [nvarchar](255) NULL,
	[cccd] [nvarchar](21) NULL,
	[ngcap] [nvarchar](255) NULL,
	[gt] [nvarchar](10) NULL,
	[hinh] [nvarchar](255) NULL,
	[diachi] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
	[sdt] [int] NULL,
	[id_bang] [int] NULL,
	[id_phong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[loainhanvien]    Script Date: 8/21/2023 3:27:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loainhanvien](
	[maloai] [int] NULL,
	[tenloai] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[phongban]    Script Date: 8/21/2023 3:27:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phongban](
	[maphong] [int] NULL,
	[tenphong] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tinhtrang]    Script Date: 8/21/2023 3:27:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tinhtrang](
	[matt] [int] NULL,
	[tentt] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ttcv]    Script Date: 8/21/2023 3:27:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ttcv](
	[manv] [int] NOT NULL,
	[ngvaolam] [nvarchar](255) NULL,
	[id_loainv] [int] NULL,
	[id_chucvu] [int] NULL,
	[congviec] [nvarchar](255) NULL,
	[id_phong] [int] NULL,
	[muclg] [float] NULL,
	[hso] [int] NULL,
	[tknh] [int] NULL,
	[nghang] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[account] ([acc_id], [acc_name], [acc_password]) VALUES (1, N'ngoc', N'abc123')
INSERT [dbo].[bangcap] ([mabang], [tenbang]) VALUES (1, N'THPT')
INSERT [dbo].[bangcap] ([mabang], [tenbang]) VALUES (2, N'Dai hoc')
INSERT [dbo].[bangcap] ([mabang], [tenbang]) VALUES (3, N'Cao dang')
INSERT [dbo].[bangcap] ([mabang], [tenbang]) VALUES (4, N'Trung cap')
INSERT [dbo].[bangcap] ([mabang], [tenbang]) VALUES (5, N'Khac')
INSERT [dbo].[chamcong] ([manv], [tennv], [id_matt], [ngay]) VALUES (2, N'a', 5, N'20/08/2023')
INSERT [dbo].[chucvu] ([mach], [tench]) VALUES (1, N'Quan ly')
INSERT [dbo].[chucvu] ([mach], [tench]) VALUES (2, N'Nhan vien')
INSERT [dbo].[chucvu] ([mach], [tench]) VALUES (3, N'Truong phong')
INSERT [dbo].[chucvu] ([mach], [tench]) VALUES (4, N'Giam doc')
INSERT [dbo].[employee] ([id], [name], [ngsinh], [cccd], [ngcap], [gt], [hinh], [diachi], [email], [sdt], [id_bang], [id_phong]) VALUES (1, N'ngoc', N'14/06/2023', N'1', N'20/08/2023', N'Nữ', N'meo.jpg', N'1', N'1@gmail.com', 1, 1, 2)
INSERT [dbo].[employee] ([id], [name], [ngsinh], [cccd], [ngcap], [gt], [hinh], [diachi], [email], [sdt], [id_bang], [id_phong]) VALUES (2, N'a', N'14/06/2023', N'1', N'20/08/2023', N'Nữ', N'egg_gold_brocken.jpg', N'1', N'1@gmail.com', 1, 1, 2)
INSERT [dbo].[employee] ([id], [name], [ngsinh], [cccd], [ngcap], [gt], [hinh], [diachi], [email], [sdt], [id_bang], [id_phong]) VALUES (3, N'a', N'14/06/2023', N'1', N'20/08/2023', N'Nữ', N'egg_gold_brocken.jpg', N'1', N'1@gmail.com', 1, 1, 2)
INSERT [dbo].[loainhanvien] ([maloai], [tenloai]) VALUES (1, N'Chinh thuc')
INSERT [dbo].[loainhanvien] ([maloai], [tenloai]) VALUES (2, N'Thuc tap')
INSERT [dbo].[loainhanvien] ([maloai], [tenloai]) VALUES (3, N'Cong tac vien')
INSERT [dbo].[phongban] ([maphong], [tenphong]) VALUES (1, N'Nhan su')
INSERT [dbo].[phongban] ([maphong], [tenphong]) VALUES (2, N'Tai chinh - Ke toan')
INSERT [dbo].[phongban] ([maphong], [tenphong]) VALUES (3, N'Cham soc khach hang')
INSERT [dbo].[phongban] ([maphong], [tenphong]) VALUES (4, N'Ky thuat')
INSERT [dbo].[phongban] ([maphong], [tenphong]) VALUES (5, N'Vat tu')
INSERT [dbo].[tinhtrang] ([matt], [tentt]) VALUES (1, N'Di lam')
INSERT [dbo].[tinhtrang] ([matt], [tentt]) VALUES (2, N'Di tre')
INSERT [dbo].[tinhtrang] ([matt], [tentt]) VALUES (3, N'Nghi co luong')
INSERT [dbo].[tinhtrang] ([matt], [tentt]) VALUES (4, N'Nghi khong luong')
INSERT [dbo].[tinhtrang] ([matt], [tentt]) VALUES (5, N'Ly do khac')
ALTER TABLE [dbo].[chamcong]  WITH CHECK ADD  CONSTRAINT [fk_chamcong_employee] FOREIGN KEY([manv])
REFERENCES [dbo].[employee] ([id])
GO
ALTER TABLE [dbo].[chamcong] CHECK CONSTRAINT [fk_chamcong_employee]
GO
ALTER TABLE [dbo].[ttcv]  WITH CHECK ADD  CONSTRAINT [fk_ttcv_employee] FOREIGN KEY([manv])
REFERENCES [dbo].[employee] ([id])
GO
ALTER TABLE [dbo].[ttcv] CHECK CONSTRAINT [fk_ttcv_employee]
GO
USE [master]
GO
ALTER DATABASE [QLNV] SET  READ_WRITE 
GO
