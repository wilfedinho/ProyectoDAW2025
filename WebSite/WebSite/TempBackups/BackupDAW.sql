USE [master]
GO
/****** Object:  Database [BD_PROYECTODAW]    Script Date: 6/7/2025 05:40:12 ******/
CREATE DATABASE [BD_PROYECTODAW]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_PROYECTODAW', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BD_PROYECTODAW.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_PROYECTODAW_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BD_PROYECTODAW_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BD_PROYECTODAW] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_PROYECTODAW].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_PROYECTODAW] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_PROYECTODAW] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_PROYECTODAW] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD_PROYECTODAW] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_PROYECTODAW] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET RECOVERY FULL 
GO
ALTER DATABASE [BD_PROYECTODAW] SET  MULTI_USER 
GO
ALTER DATABASE [BD_PROYECTODAW] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_PROYECTODAW] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_PROYECTODAW] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_PROYECTODAW] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD_PROYECTODAW] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BD_PROYECTODAW] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BD_PROYECTODAW', N'ON'
GO
ALTER DATABASE [BD_PROYECTODAW] SET QUERY_STORE = ON
GO
ALTER DATABASE [BD_PROYECTODAW] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BD_PROYECTODAW]
GO
/****** Object:  Table [dbo].[Beneficio]    Script Date: 6/7/2025 05:40:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficio](
	[CodigoBeneficio] [int] NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[PrecioEstrella] [int] NULL,
	[CantidadBeneficioReclamado] [int] NULL,
	[DescuentoAplicar] [decimal](3, 2) NULL,
	[DVH] [nvarchar](64) NULL,
 CONSTRAINT [PK_Beneficio490WC] PRIMARY KEY CLUSTERED 
(
	[CodigoBeneficio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 6/7/2025 05:40:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[ID_Bitacora] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](20) NULL,
	[Fecha] [date] NULL,
	[Hora] [time](0) NULL,
	[Modulo] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Criticidad] [int] NULL,
	[DVH] [nvarchar](64) NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[ID_Bitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Boleto]    Script Date: 6/7/2025 05:40:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boleto](
	[ID] [nvarchar](20) NOT NULL,
	[Origen] [nvarchar](50) NULL,
	[Destino] [nvarchar](50) NULL,
	[FechaPartidaIDA] [date] NULL,
	[FechaLlegadaIDA] [date] NULL,
	[FechaPartidaVUELTA] [date] NULL,
	[FechaLlegadaVUELTA] [date] NULL,
	[ClaseBoleto] [nvarchar](50) NULL,
	[IsVendido] [bit] NULL,
	[PesoEquipajePermitido] [float] NULL,
	[Precio] [float] NULL,
	[Titular] [nvarchar](50) NULL,
	[NumeroAsiento] [nvarchar](4) NULL,
	[FechaBoletoGenerado] [datetime2](0) NULL,
	[BeneficioAplicado] [nvarchar](50) NULL,
	[DVH] [nvarchar](64) NULL,
 CONSTRAINT [PK_Boleto490WC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DigitoVerificador]    Script Date: 6/7/2025 05:40:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigitoVerificador](
	[Tabla] [nvarchar](50) NOT NULL,
	[DVV] [nvarchar](64) NULL,
	[CR] [int] NULL,
 CONSTRAINT [PK_DigitoVerificador] PRIMARY KEY CLUSTERED 
(
	[Tabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 6/7/2025 05:40:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Username] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[DNI] [nvarchar](50) NULL,
	[Contraseña] [nvarchar](70) NULL,
	[Email] [nvarchar](50) NULL,
	[Rol] [nvarchar](50) NULL,
	[EstrellasCliente] [int] NULL,
	[DVH] [nvarchar](64) NULL,
 CONSTRAINT [PK_Usuario490WC] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Beneficio]    Script Date: 6/7/2025 05:40:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Beneficio](
	[DNI] [nvarchar](50) NOT NULL,
	[CodigoBeneficio] [int] NOT NULL,
	[DVH] [nvarchar](64) NULL,
 CONSTRAINT [PK_Cliente_Beneficio490WC] PRIMARY KEY CLUSTERED 
(
	[DNI] ASC,
	[CodigoBeneficio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Beneficio] ([CodigoBeneficio], [Nombre], [PrecioEstrella], [CantidadBeneficioReclamado], [DescuentoAplicar], [DVH]) VALUES (2, N'20%', 2, 1, CAST(0.20 AS Decimal(3, 2)), N'26e6b884f28972d2113228a864df8d4b927e02578cfa2ea41e3371aaabb54f3a')
INSERT [dbo].[Beneficio] ([CodigoBeneficio], [Nombre], [PrecioEstrella], [CantidadBeneficioReclamado], [DescuentoAplicar], [DVH]) VALUES (3, N'30%', 5, 1, CAST(0.30 AS Decimal(3, 2)), N'3ee760cb0ba12219a7e571e36358ad989decaa3f38b8af838daa443558bf6a6d')
INSERT [dbo].[Beneficio] ([CodigoBeneficio], [Nombre], [PrecioEstrella], [CantidadBeneficioReclamado], [DescuentoAplicar], [DVH]) VALUES (4, N'40%', 10, 4, CAST(0.40 AS Decimal(3, 2)), N'2eb0c97c5989ee05266cf5ec35e1ac7305f8167de5329cab40a3bf9b7ee86609')
INSERT [dbo].[Beneficio] ([CodigoBeneficio], [Nombre], [PrecioEstrella], [CantidadBeneficioReclamado], [DescuentoAplicar], [DVH]) VALUES (5, N'50%', 30, 1, CAST(0.50 AS Decimal(3, 2)), N'2601e9588b29b2cec0afad4a9c3ef19499e95eb88563b1359c42bb5bd4617fc5')
INSERT [dbo].[Beneficio] ([CodigoBeneficio], [Nombre], [PrecioEstrella], [CantidadBeneficioReclamado], [DescuentoAplicar], [DVH]) VALUES (6, N'60%', 45, 42, CAST(0.60 AS Decimal(3, 2)), N'1967c52405ac654ff3ca85591f72e6dc0b8ea17b89166f3789f7fde47a3422cc')
INSERT [dbo].[Beneficio] ([CodigoBeneficio], [Nombre], [PrecioEstrella], [CantidadBeneficioReclamado], [DescuentoAplicar], [DVH]) VALUES (7, N'70%', 70, 0, CAST(0.70 AS Decimal(3, 2)), N'998033e1215e208323305cd5364db520391e8279ea87cecf302a12b9c4703bec')
INSERT [dbo].[Beneficio] ([CodigoBeneficio], [Nombre], [PrecioEstrella], [CantidadBeneficioReclamado], [DescuentoAplicar], [DVH]) VALUES (8, N'80%', 80, 2, CAST(0.80 AS Decimal(3, 2)), N'9e4dfaec09eaeb9bbbb7b78455cc3fcf88b7779716327771de673b2d8b65e28d')
INSERT [dbo].[Beneficio] ([CodigoBeneficio], [Nombre], [PrecioEstrella], [CantidadBeneficioReclamado], [DescuentoAplicar], [DVH]) VALUES (9, N'Pack Verano', 90, 2, CAST(0.90 AS Decimal(3, 2)), N'002aeabe916d513c98bdf75b42dda34c99d7faeff0ee070a1f1d0cfc016d3752')
INSERT [dbo].[Beneficio] ([CodigoBeneficio], [Nombre], [PrecioEstrella], [CantidadBeneficioReclamado], [DescuentoAplicar], [DVH]) VALUES (10, N'100%', 125, 11, CAST(1.00 AS Decimal(3, 2)), N'17095892d30a93c739213305b1e24af35418791e8a299d275251c157044f319b')
INSERT [dbo].[Beneficio] ([CodigoBeneficio], [Nombre], [PrecioEstrella], [CantidadBeneficioReclamado], [DescuentoAplicar], [DVH]) VALUES (11, N'PACK INVIERNO', 100, 1, CAST(0.47 AS Decimal(3, 2)), N'96f43d6815ae83d197ef04f04c5e24da692279d94ee57d5aa4aaaa0a0b14c43b')
GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1146, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'01:32:21' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'ab698b608566ccf3e5c033651382250329881f5894a0a55524a4c6a27c974910')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1147, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'01:33:19' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'47b18005fdb716c0a9555c229df31d0bc3e32bf466bfc9708b38d57bce47602b')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1148, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'01:33:29' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'1c2720b88820ca413e92ad4c96fa975f29436e17430e212f04f9862d771cfa4d')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1149, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'01:34:13' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'd4b50a03b615e73f905ecb9e7674c79e4526aacdc2f64dbfcf240c4f99e1aa5c')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1150, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'01:34:34' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'769d29c20a291e38c7bcf0239dc3636204b73478ad8f55118a4df91548465892')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1151, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'01:35:17' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'77302b15ff4e6c960be3ae2679b78bba1ca3f87879fe28501b68a3897677ba73')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1152, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'01:35:31' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'05ead2c65870f4528701d2e07303855cb243dbba5b203c66442bc142e3ddadd6')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1153, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'01:36:17' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'138ae2b9242e6df72cc57ab5418ef0720d6064b869bc628f6e62b34ea7231b13')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1154, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'01:37:01' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'0d44c32da0ded36166cdd44becb078832e50020426583291c4ec0c67e6d68795')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1155, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:19:26' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'660adde8c8bfc270e81f0289b8f2ee6b4c93dc709df5072a02be1a99ede7347a')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1156, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:24:54' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'17e03c1ddc974669f3ed9bc1d47890b48414abb6b67d0e9acea5f162aaa20519')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1157, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:26:19' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'89d412f3096925318ec55c5ae900c9a3ad24b8bd564b5d85a62d1db9c076f39d')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1158, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:26:55' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'784e52ed53198fb7b5e9f455c67f226b2cc5454996189cdd7c8e77fb48c22230')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1159, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:31:54' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'646fc43257ca6582ac00a13ae4f3b449a7091a0bd891f5583e08640a2bb56ddb')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1160, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:32:18' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'71a6731a2ace979dc6560b168b4289f98926410f0c9bcd4702eff9e1ed4aa293')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1161, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:36:24' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'76a53e6ae8fee96529fce5bd989e1c28a7437215e2d415a1c734556fe89bf81b')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1162, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:36:57' AS Time), N'FormABM', N'Cierre de sesión', 1, N'31dbe7c8d557222931ae5cd16dca81e33605a0aa87452c47bce82eb558e4fd0f')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1163, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:37:13' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'9b5682a4517a46e44c1aa354b0bf7868599944678406e386e997ed4f50f7a476')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1164, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:37:17' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'e79cdc07019fd66247b057f85a46d7b2f7b4dd4b2560acf6768932906f4f927f')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1165, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:44:20' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'0d8404a9f3521ed49259306bc9950097b3f01d0235c54ad7d5d8f667b9925d87')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1166, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:44:42' AS Time), N'FormABM', N'Cierre de sesión', 1, N'714d963f46da0c6ae89a5d750484be682a6afa66887125ada78fa24ad6f60a30')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1167, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:45:41' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'114108812587cbd74b1a852b8d39a5cac9fc84fd3a2182ee2c437bf32ffff8ad')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1168, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:46:38' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'4b6d6ac2bdc8249f18401bfd5052fc52f3eb574758907204f03cffad091ecfb1')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1169, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:58:01' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'8f83246c0e707ce1419cfd3105463defd92a2dfceaa5ad5abdb4f7fde18b2e59')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1170, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'05:58:12' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'742ae998da5ad93068d924f74f38cddedd629dd90de6f82b52749c61ff64e0cf')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1171, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'14:52:02' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'8b9684b5589dbcc3169b34484c582c884f1966b5e0763cf2bdbeabfd9436a928')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1172, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'14:52:10' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'2fbf0f0a5774f92786e76c975f352113470d3607a9b9d9dee5d2efa6bdeec5e0')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1173, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'14:57:24' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'04a28f7c30b704ae9483947d940b3688195c8e948c55eca4e66c04bcdbfbdcf6')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1174, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'14:57:52' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'87f3912e6277eeb601796aea20797c0f9d7def9eb40b1e766ef8ed0bb25153f8')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1175, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:00:54' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'2923e15b2372cb91b1925cc25b92c06779f13637a54d29d1ce77cc30b47a320e')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1176, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:01:21' AS Time), N'FormABM', N'Cierre de sesión', 1, N'4475430782cc8b9ba8aa6d3a3b3fb297e8aa96c0a80a62a4be2927b6be5d876f')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1177, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:06:36' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'3d9804054777bee0fa7ac9a5fb1a849578a7616a839ac1a1199861d82720ac00')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1178, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:07:46' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'3c04b9ffc0ed4286081bbb79c1814ad45d19d7177c9a79a5e9c74c5f52ad6f05')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1179, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:08:00' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'b1510ea63264fce2b8533dde7e3062c923ff8d36fce24950e3f504ad692df944')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1180, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:08:04' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'591270ce9b7f8c06ae2c9ab44540ac783f691733fc424fe76ba3c148c0a5a727')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1181, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:09:34' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'baab17163f661c5d67b45eb2b3ba089958f7f30d0822da46849840372c10dc71')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1182, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:09:48' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'8074e3ebd2b39935ded819fbfabc07ef61b191967155c984130e307e0c5c4abb')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1183, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:22:40' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'0f60bc0b3400b294d39c707d20051ee474282a1de97e26d05f8de2fc385b3e03')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1184, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:22:42' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'95bbe09596fb13062f2aee47c7e7d92627b840a3fc40b968a6162dbfc92dcb79')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1185, N'gatik', CAST(N'2025-03-26' AS Date), CAST(N'15:22:45' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'88d08cf9308063579c5a33c0632773882a8f66d85a737b13cdb80c65728b6d94')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1186, N'gatik', CAST(N'2025-03-26' AS Date), CAST(N'15:22:46' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'e8b008a1f8f57f7262fed8198fedadd55d22053f3d84ee6c767ae29d1db6b43e')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1187, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:22:54' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'ef7a37f8beb8e7bc7853c908ba2b82a84d4a2c9dda167be35aa27fda1ac8caa5')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1188, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:23:12' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'6c414eeaa2f23fa2eee55512e83d1a81779c9f1977b2ab73784718247c50dc04')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1189, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:26:14' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'dfe34f93809e8c1989056592026fb6df4c4fc85d7cfa3b82bc6827b4c97d5052')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1190, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:26:28' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'fe57b697cacc03c8347429355e967300329cdaa14525d71010f26e1363568540')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1191, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:28:23' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'82ddacd3b1e93ff6bdbfd9b5b4ce745929cba33fff23eee0a496f03f9256477d')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1192, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:28:48' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'0b0700a6b6b295496a4f57ddfc8faf9144d1346e896ae44c7dccc7bc03cd14d5')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1193, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:31:05' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'592ded23476b1ee493a99cb6405df6c0cab3a4ae0e4ea7fff4b6a4f8f266a17f')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1194, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:31:07' AS Time), N'FormTraductor', N'Cambio Idioma', 1, N'61cbd452c0bf1fd1face3876aeeac027f40cf51dc8df7a81d6700bbb77a9ca28')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1195, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:31:15' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'ac3fe50be6e2a0cdd78ea20e279cc4f4f5a68d9d77dcc77e1b93706118838901')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1196, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:40:17' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'a5fc6b37e492e050d647847d1ab69c935f8029581c5616e69107232b6246e7b4')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1197, N'admin', CAST(N'2025-03-26' AS Date), CAST(N'15:41:40' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'5343c2dd68e442f6319f632c0ba64d0ea3ce6312f8b46ceea80e330dcf1ebb19')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1198, N'admin', CAST(N'2025-04-01' AS Date), CAST(N'09:12:58' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'c8957eab60b16228daca5ac9d29a7c16291aa4b128cd24cf8a992305770a3d00')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1199, N'admin', CAST(N'2025-04-01' AS Date), CAST(N'09:13:03' AS Time), N'FormTraductor', N'Cambio Idioma', 1, N'61d49c30d6fe7927b0cfe8cb92080b18fa97177ceff1d046cb7b257e2ad10be6')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1200, N'admin', CAST(N'2025-04-01' AS Date), CAST(N'09:13:11' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'd3de4308bacfa9a4b18e5431adcb628550ee0f4ee24a96839f56eb5584419535')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1201, N'admin', CAST(N'2025-04-01' AS Date), CAST(N'09:13:39' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'1dc124b2d95023125feb097dc0f5f3373784d905e1f46589e46910465d2ea5b5')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1202, N'admin', CAST(N'2025-04-01' AS Date), CAST(N'09:13:42' AS Time), N'FormTraductor', N'Cambio Idioma', 1, N'af2d2559b188c43a4f9003b0ed3cebcf0a52f60473b1906c5e8db509424e14a1')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1203, N'admin', CAST(N'2025-04-01' AS Date), CAST(N'09:13:49' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'7315d58c992fae91aee1f95686efdceebec56ee00f85ec68e12dc5bbbbc52719')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1204, N'admin', CAST(N'2025-04-02' AS Date), CAST(N'16:21:31' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'96775ae3b8a4af7e456df0f80151dadd758bce182785846178bab57f73bbbc9a')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1205, N'admin', CAST(N'2025-04-02' AS Date), CAST(N'16:21:42' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'b125b208be92034f35ab25b10d3d328341947c03672900a8bb9d583b30092c83')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1206, N'admin', CAST(N'2025-04-02' AS Date), CAST(N'16:23:09' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'e9ab9999958f44f1a1a8b60ca14c7190b0ba0a0f81435f65e199525c7d95c4e2')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1207, N'admin', CAST(N'2025-04-02' AS Date), CAST(N'16:23:15' AS Time), N'FormTraductor', N'Cambio Idioma', 1, N'ff3ea7bc85777b31b44aa28b04cabc9aa1022622efb19ac4626f9f4be86c2804')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1208, N'admin', CAST(N'2025-04-02' AS Date), CAST(N'16:23:19' AS Time), N'FormTraductor', N'Cambio Idioma', 1, N'3cd56b4f8f30b96bb7ffbbe568d47604bcd61be0fe010b5929128902f6c41a3c')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1209, N'admin', CAST(N'2025-04-02' AS Date), CAST(N'16:23:48' AS Time), N'FormMenu', N'Cierre de sesión', 1, N'2094b9e042d8f437ef9dbc918dc2fd6b447fe443627aab0ed124989d4e1949bb')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1210, N'admin', CAST(N'2025-04-02' AS Date), CAST(N'21:56:18' AS Time), N'FormLogin', N'Inicio de sesión', 1, N'27910e061e4a0158445108d3add426a15552cd3cd27465e2fc0f783e80907dd0')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1211, N'admin', CAST(N'2025-04-02' AS Date), CAST(N'21:56:33' AS Time), N'FormTraductor', N'Cambio Idioma', 1, N'9929e5b4223b6239d2758976f04d72853a66705442d80cbd4b9f7e69cd02751b')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1212, N'admin', CAST(N'2025-04-02' AS Date), CAST(N'21:57:05' AS Time), N'FormABM', N'Bloqueo de usuario', 4, N'643ca4722ea4c7a5078a6a738efa3324acf427c0c677b2d1f09d92c658ecff1f')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1213, N'admin', CAST(N'2025-04-02' AS Date), CAST(N'21:57:24' AS Time), N'FormABM', N'Baja Usuario', 4, N'065e4ac3ea5b424385b381dbb87482447de7cef130a80452718fa1278b084254')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [NombreUsuario], [Fecha], [Hora], [Modulo], [Descripcion], [Criticidad], [DVH]) VALUES (1214, N'admin', CAST(N'2025-04-02' AS Date), CAST(N'21:57:26' AS Time), N'FormABM', N'Cierre de sesión', 1, N'1ca15534a6da05c8538f96fad7a5d6ed4c130cd4dcdfad6b020f8eebb2ccbd7f')
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
GO
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'1', N'Buenos Aires', N'Miami', CAST(N'2025-06-25' AS Date), CAST(N'2025-06-30' AS Date), CAST(N'2025-07-10' AS Date), CAST(N'2025-07-20' AS Date), N'Primera Clase', 1, 45.6, 6316.194250983, N'11.111.111', NULL, CAST(N'2025-06-18T13:57:50.0000000' AS DateTime2), N'40%', N'4200fbf201d8731955cc7881af65f92267a86109ebb86cbda8dcda9cc13782ba')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'10', N'Glasgow', N'Budapest', CAST(N'2025-06-18' AS Date), CAST(N'2025-06-18' AS Date), CAST(N'2025-06-19' AS Date), CAST(N'2025-06-19' AS Date), N'Primera Clase', 1, 789, 9999.8997350931168, N'66.123.471', N'L333', CAST(N'2025-06-21T03:59:10.0000000' AS DateTime2), NULL, N'c734bdc3ad9a5e7080acf4213d956e50c6a64587afc1c718040931160ce8be99')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'12', N'Seattle', N'Lima', CAST(N'2025-06-28' AS Date), CAST(N'2025-06-29' AS Date), CAST(N'2025-07-03' AS Date), CAST(N'2025-07-06' AS Date), N'Primera Clase', 0, 45, 1000012, N'Sistema', N'K325', NULL, NULL, N'7dc9d26595004fee4ca4e85d15419bdbec511d4a7f26ce8d9f93f56408b71e62')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'13', N'Buenos Aires', N'Tokyo', CAST(N'2025-06-21' AS Date), CAST(N'2025-06-21' AS Date), NULL, NULL, N'Ejecutiva', 1, 10.199999809265137, 27.199982007343806, N'11.111.111', N'T777', CAST(N'2025-06-25T19:56:22.0000000' AS DateTime2), NULL, N'e3ebb9a54513843b9d1f92eacce1115ea10cc616c0230e37fa941a7efda6424a')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'14', N'Tokyo', N'Barquisimeto', CAST(N'2025-07-04' AS Date), CAST(N'2025-07-06' AS Date), NULL, NULL, N'Primera Clase', 0, 10.470000267028809, 15000.1396484375, N'Sistema', N'U888', NULL, NULL, N'd0031a5a830165bc4facada1fe87ca4986a33a0e82512f01a9041cb7d96ff94a')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'15', N'Hawaii', N'Caracas', CAST(N'2025-06-21' AS Date), CAST(N'2025-06-21' AS Date), NULL, NULL, N'Turista', 1, 14.5600004196167, 54000.234375, N'96.117.490', N'J333', CAST(N'2025-06-21T20:15:18.0000000' AS DateTime2), NULL, N'd6eb7cd5255bbbd8dc81051625f0ce6ad6155a4c57cb6a483f901ba173ea17fb')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'16', N'GFHGFH', N'FGHFGH', CAST(N'2025-06-25' AS Date), CAST(N'2025-06-25' AS Date), NULL, NULL, N'Turista', 1, 123, 0, N'11.111.111', N'G333', CAST(N'2025-06-25T19:43:24.0000000' AS DateTime2), N'80%', N'2b6a6cd587c121a0bb8ee8a4cbd2ed6b8a9865d0a82eb427cdc14e6d6b2029f1')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'19', N'Valencia', N'Barcelona', CAST(N'2025-06-30' AS Date), CAST(N'2025-07-01' AS Date), NULL, NULL, N'Primera Clase', 0, 100, 456513.09375, N'Sistema', N'L111', NULL, NULL, N'7c96a91400db0247d7dbc830bf3bb1b0590fa87be7c5b8a57939c9efe7fb9bc0')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'2', N'Barquisimeto', N'Buenos Aires', CAST(N'2025-05-24' AS Date), CAST(N'2025-06-01' AS Date), NULL, NULL, N'Turista', 1, 10.2, 316.65199460744861, N'99.123.123', NULL, CAST(N'2025-06-18T13:12:44.0000000' AS DateTime2), NULL, N'51dc1453c13a1d051f9f30ac19d74049b69c9d50f5458fd69f351d0a074bda8f')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'20', N'Porto Alegre', N'Munich', CAST(N'2025-06-28' AS Date), CAST(N'2025-07-03' AS Date), CAST(N'2025-08-07' AS Date), CAST(N'2025-08-09' AS Date), N'Primera Clase', 0, 123, 14444.1103515625, N'Sistema', N'R999', NULL, NULL, N'4770e47ce50298d699c1c88baa140bed15e15effabcd7fb560353041ea0a03ca')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'4', N'Buenos Aires', N'Moscow', CAST(N'2025-06-17' AS Date), CAST(N'2025-06-17' AS Date), CAST(N'2025-06-28' AS Date), CAST(N'2025-06-28' AS Date), N'Turista', 1, 20, 192.00000572204596, N'11.111.111', N'H456', CAST(N'2025-06-18T13:53:12.0000000' AS DateTime2), NULL, N'357353bb3445ba1f8f89005b37b6f952166b0e412132628b0ddef25626be62af')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'6', N'Buenos Aires', N'Manchester', CAST(N'2025-06-18' AS Date), CAST(N'2025-06-18' AS Date), NULL, NULL, N'Primera Clase', 1, 213.21000671386719, 98.66400293505194, N'96.117.490', N'R584', CAST(N'2025-06-18T14:33:19.0000000' AS DateTime2), N'20%', N'9c9d25f4fee4f3ae57f5bf2373d95574d27f10908395ca80c7a0f1649bec6627')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'7', N'Caseros', N'Caseros', CAST(N'2025-06-18' AS Date), CAST(N'2025-06-18' AS Date), CAST(N'2025-06-19' AS Date), CAST(N'2025-06-19' AS Date), N'Turista', 1, 54, 1, N'74.226.553', N'L444', CAST(N'2025-06-18T14:22:52.0000000' AS DateTime2), NULL, N'b47a8b991a48cd3179c3a68a144d8bb24501fc282c2f1d340776527bdef988a0')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'8', N'Miami', N'Moscow', CAST(N'2025-06-18' AS Date), CAST(N'2025-06-27' AS Date), NULL, NULL, N'Ejecutiva', 1, 12, 28424.159670569887, N'11.111.111', N'H999', CAST(N'2025-06-25T21:39:17.0000000' AS DateTime2), N'10%', N'a9fc83fb4d07cccefdcbe2d7a77ff936292620bab340e80059596e6e32d46ec6')
INSERT [dbo].[Boleto] ([ID], [Origen], [Destino], [FechaPartidaIDA], [FechaLlegadaIDA], [FechaPartidaVUELTA], [FechaLlegadaVUELTA], [ClaseBoleto], [IsVendido], [PesoEquipajePermitido], [Precio], [Titular], [NumeroAsiento], [FechaBoletoGenerado], [BeneficioAplicado], [DVH]) VALUES (N'9', N'Barquisimeto', N'Caracas', CAST(N'2025-06-18' AS Date), CAST(N'2025-06-18' AS Date), NULL, NULL, N'Ejecutiva', 1, 213, 0, N'96.117.490', N'T777', CAST(N'2025-06-21T17:26:09.0000000' AS DateTime2), N'100%', N'c69109775c11e6c0900db1c91b2aa7d6811f56b188d28cde3eebb11b0dd80683')
GO
INSERT [dbo].[DigitoVerificador] ([Tabla], [DVV], [CR]) VALUES (N'Beneficio', N'742e67b222ee91c3a3e3c7ccf024dc842787f7f1b7bf7e201c2d6cc30a0f61be', 10)
INSERT [dbo].[DigitoVerificador] ([Tabla], [DVV], [CR]) VALUES (N'Bitacora', N'cede3b5025148c842692c89ff62fe92b308bfdd27216e84e3ab6fb0e24a96231', 69)
INSERT [dbo].[DigitoVerificador] ([Tabla], [DVV], [CR]) VALUES (N'Boleto', N'17d7c8b645f9462168a6eb01346f6438b40589d08f11825c2296f86bb7d980c5', 15)
INSERT [dbo].[DigitoVerificador] ([Tabla], [DVV], [CR]) VALUES (N'Usuario', N'21396e0d96ca2bd5bb276031222c99fc62a5afc679522c3c7091fd5b542ab9dc', 2)
GO
INSERT [dbo].[Usuario] ([Username], [Nombre], [Apellido], [DNI], [Contraseña], [Email], [Rol], [EstrellasCliente], [DVH]) VALUES (N'gatik', N'Agustín', N'Gatica', N'44.714.502', N'5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', N'agustingatica710@gmail.com', N'Admin', 0, N'4dc9c51b1ab584876178a4aa93c375ad855f52e0fa76ef635f62625886f6f251')
INSERT [dbo].[Usuario] ([Username], [Nombre], [Apellido], [DNI], [Contraseña], [Email], [Rol], [EstrellasCliente], [DVH]) VALUES (N'Wilfedinho', N'William', N'Alejandro', N'96.117.490', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', N'william10fcb1@gmail.com', N'Admin', 0, N'd2bb8ba1ba0bc58e20ccd930f5250f80aa83af4e2646669662e72bdb25a2840e')
GO
USE [master]
GO
ALTER DATABASE [BD_PROYECTODAW] SET  READ_WRITE 
GO
