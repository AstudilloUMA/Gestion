USE [master]
GO
DROP DATABASE [control2_Lunes]
GO
/****** Object:  Database [control2_Lunes]    Script Date: 01/01/2022 12:41:46 ******/
CREATE DATABASE [control2_Lunes]
GO
USE [control2_Lunes]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Lunes_tPaciente](
	[NIF] [varchar](50) NOT NULL,
	[NumSeguro] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Sexo] [varchar](10) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Direccion] [varchar](80) NULL,
	[Poblacion] [varchar](50) NULL,
	[Provincia] [varchar](3) NOT NULL,
	[CodigoPostal] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[e_mail] [varchar](50) NULL,
 CONSTRAINT [PK_tPaciente] PRIMARY KEY CLUSTERED 
(
	[NIF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Lunes_tProvincia]    Script Date: 01/01/2022 12:41:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Lunes_tProvincia](
	[Codigo] [varchar](3) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_tPais] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lunes_tPruebas]    Script Date: 01/01/2022 12:41:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lunes_tPruebas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NIF] [varchar](50) NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
	[valor_glucosa] [real] NULL,
 CONSTRAINT [PK_tPruebas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lunes_tReferenciasGlucosa]    Script Date: 01/01/2022 12:41:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lunes_tReferenciasGlucosa](
	[ID] [int] NOT NULL,
	[desde] [real] NOT NULL,
	[hasta] [real] NOT NULL,
	[categoria] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tReferenciasGlucosa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Lunes_tPaciente]  WITH CHECK ADD  CONSTRAINT [FK_tPaciente_tProvincia] FOREIGN KEY([Provincia])
REFERENCES [dbo].[Lunes_tProvincia] ([Codigo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lunes_tPaciente] CHECK CONSTRAINT [FK_tPaciente_tProvincia]
GO

ALTER TABLE [dbo].[Lunes_tPruebas]  WITH CHECK ADD  CONSTRAINT [FK_tPruebas_tPaciente] FOREIGN KEY([NIF])
REFERENCES [dbo].[Lunes_tPaciente] ([NIF])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lunes_tPruebas] CHECK CONSTRAINT [FK_tPruebas_tPaciente]
GO

DELETE Lunes_tProvincia;
GO
INSERT INTO Lunes_tProvincia VALUES('VI','Alava');
INSERT INTO Lunes_tProvincia VALUES('AB','Albacete');
INSERT INTO Lunes_tProvincia VALUES('A','Alicante');
INSERT INTO Lunes_tProvincia VALUES('AL','Almeria');
INSERT INTO Lunes_tProvincia VALUES('AV','Avila');
INSERT INTO Lunes_tProvincia VALUES('BA','Badajoz');
INSERT INTO Lunes_tProvincia VALUES('IB','Baleares');
INSERT INTO Lunes_tProvincia VALUES('B','Barcelona');
INSERT INTO Lunes_tProvincia VALUES('BU','Burgos');
INSERT INTO Lunes_tProvincia VALUES('CC','CAceres');
INSERT INTO Lunes_tProvincia VALUES('CA','CAdiz');
INSERT INTO Lunes_tProvincia VALUES('CE','Ceuta');
INSERT INTO Lunes_tProvincia VALUES('CS','Castellon');
INSERT INTO Lunes_tProvincia VALUES('CR','Ciudad Real');
INSERT INTO Lunes_tProvincia VALUES('CO','Cordoba');
INSERT INTO Lunes_tProvincia VALUES('C','La Coruña');
INSERT INTO Lunes_tProvincia VALUES('CU','Cuenca');
INSERT INTO Lunes_tProvincia VALUES('GI','Gerona');
INSERT INTO Lunes_tProvincia VALUES('GR','Granada');
INSERT INTO Lunes_tProvincia VALUES('GU','Guadalajara');
INSERT INTO Lunes_tProvincia VALUES('SS','Guipuzcoa');
INSERT INTO Lunes_tProvincia VALUES('H','Huelva');
INSERT INTO Lunes_tProvincia VALUES('HU','Huesca');
INSERT INTO Lunes_tProvincia VALUES('J','JaEn');
INSERT INTO Lunes_tProvincia VALUES('LE','Leon');
INSERT INTO Lunes_tProvincia VALUES('L','LErida');
INSERT INTO Lunes_tProvincia VALUES('LO','Logroño');
INSERT INTO Lunes_tProvincia VALUES('LU','Lugo');
INSERT INTO Lunes_tProvincia VALUES('M','Madrid');
INSERT INTO Lunes_tProvincia VALUES('MA','MAlaga');
INSERT INTO Lunes_tProvincia VALUES('ML','Melilla');
INSERT INTO Lunes_tProvincia VALUES('MU','Murcia');
INSERT INTO Lunes_tProvincia VALUES('NA','Navarra');
INSERT INTO Lunes_tProvincia VALUES('OU','Orense');
INSERT INTO Lunes_tProvincia VALUES('O','Oviedo');
INSERT INTO Lunes_tProvincia VALUES('P','Palencia');
INSERT INTO Lunes_tProvincia VALUES('GC','Las Palmas');
INSERT INTO Lunes_tProvincia VALUES('PO','Pontevedra');
INSERT INTO Lunes_tProvincia VALUES('SA','Salamanca');
INSERT INTO Lunes_tProvincia VALUES('TF','Tenerife');
INSERT INTO Lunes_tProvincia VALUES('S','Santander');
INSERT INTO Lunes_tProvincia VALUES('SG','Segovia');
INSERT INTO Lunes_tProvincia VALUES('SE','Sevilla');
INSERT INTO Lunes_tProvincia VALUES('SO','Soria');
INSERT INTO Lunes_tProvincia VALUES('T','Tarragona');
INSERT INTO Lunes_tProvincia VALUES('TE','Teruel');
INSERT INTO Lunes_tProvincia VALUES('TO','Toledo');
INSERT INTO Lunes_tProvincia VALUES('V','Valencia');
INSERT INTO Lunes_tProvincia VALUES('VA','Valladolid');
INSERT INTO Lunes_tProvincia VALUES('BI','Vizcaya');
INSERT INTO Lunes_tProvincia VALUES('Z','Zaragoza');
INSERT INTO Lunes_tProvincia VALUES('ZA','Zamora');
GO
DELETE Lunes_tPaciente;
GO

INSERT INTO Lunes_tPaciente VALUES('1', 1,'N1', 'AP1', 'HOMBRE', '1971-03-10', 'CASA 1', 'MALAGA', 'MA', '29001', '111111111', '1@MAIL.COM');
INSERT INTO Lunes_tPaciente VALUES('2', 2,'N2', 'AP2', 'HOMBRE', '1998-05-05', 'CASA 2', 'MALAGA', 'MA', '29002', '222222222', '2@MAIL.COM');
INSERT INTO Lunes_tPaciente VALUES('3', 3,'N3', 'AP3', 'MUJER', '2003-03-03', 'CASA 3', 'TORREMOLINOS', 'MA', '29160', '3333333333', '3@MAIL.COM');
INSERT INTO Lunes_tPaciente VALUES('4', 4,'N4', 'AP4', 'MUJER', '2004-04-04', 'CASA 4', 'ALCOBENDAS', 'M', '28131', '444444444', '4@MAIL.COM');
INSERT INTO Lunes_tPaciente VALUES('5', 5,'N5', 'AP5', 'MUJER', '2005-05-05', 'CASA 5', 'MALAGA', 'MA', '29005', '555555555', '5@MAIL.COM');

GO
DELETE Lunes_tReferenciasGlucosa;
GO
INSERT INTO Lunes_tReferenciasGlucosa VALUES(1,0,70,'Hipoglucemia');
INSERT INTO Lunes_tReferenciasGlucosa VALUES(2,70,120,'Normal');
INSERT INTO Lunes_tReferenciasGlucosa VALUES(3,120,999,'Hiperlucemia');
GO

DELETE Lunes_tPruebas;
GO
INSERT INTO Lunes_tPruebas VALUES('1','2022-01-03 10:00:00.000',110);
INSERT INTO Lunes_tPruebas VALUES('1','2022-01-04 10:00:00.000',90);
INSERT INTO Lunes_tPruebas VALUES('1','2022-01-05 10:00:00.000',121);
INSERT INTO Lunes_tPruebas VALUES('1','2022-01-10 11:00:00.000',65);
INSERT INTO Lunes_tPruebas VALUES('1','2022-01-11 11:00:00.000',101);
GO
