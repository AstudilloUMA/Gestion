USE [master]
GO

DROP DATABASE [IMPERIAL]
GO

CREATE DATABASE [IMPERIAL]
GO

USE [IMPERIAL]
GO

CREATE TABLE [dbo].[Nave](
	[Nombre] [varchar](50) NOT NULL,
	[Capitan] [varchar](50) NULL,
	[PlanetaFabricacion] [varchar](50) NULL,
	[TipoNaveCodigo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[TipoNave](
	[Codigo] [int] NOT NULL,
	[Denominacion] [varchar](50) NULL,
	[Longitud] [float] NULL,
	[NumTripulantes] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Denominacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Nave]  WITH CHECK ADD FOREIGN KEY([TipoNaveCodigo])
REFERENCES [dbo].[TipoNave] ([Codigo])
GO

INSERT [dbo].[TipoNave] ([Codigo], [Denominacion], [Longitud], [NumTripulantes]) VALUES (1, N'Destructor Estelar Imperial', 1600, 47000)
INSERT [dbo].[TipoNave] ([Codigo], [Denominacion], [Longitud], [NumTripulantes]) VALUES (2, N'Caza TIE', 6.4, 1)
INSERT [dbo].[TipoNave] ([Codigo], [Denominacion], [Longitud], [NumTripulantes]) VALUES (3, N'Fragata de Asalto Imperial', 1200, 7500)
INSERT [dbo].[TipoNave] ([Codigo], [Denominacion], [Longitud], [NumTripulantes]) VALUES (4, N'Lanzadera Imperial', 20, 6)
INSERT [dbo].[TipoNave] ([Codigo], [Denominacion], [Longitud], [NumTripulantes]) VALUES (5, N'Transporte de Asalto Blindado Todo Terreno', 22.5, 5)
INSERT [dbo].[Nave] ([Nombre], [Capitan], [PlanetaFabricacion], [TipoNaveCodigo]) VALUES (N'Devastador', N'Darth Vader', N'Kuat', 1)
INSERT [dbo].[Nave] ([Nombre], [Capitan], [PlanetaFabricacion], [TipoNaveCodigo]) VALUES (N'Discover', N'Lorth Needa', N'Lothal', 3)
INSERT [dbo].[Nave] ([Nombre], [Capitan], [PlanetaFabricacion], [TipoNaveCodigo]) VALUES (N'Eclipse', N'Sedriss QL', N'Byss', 1)
INSERT [dbo].[Nave] ([Nombre], [Capitan], [PlanetaFabricacion], [TipoNaveCodigo]) VALUES (N'Ejecutor', N'Lorth Needa', N'Kuat', 1)
INSERT [dbo].[Nave] ([Nombre], [Capitan], [PlanetaFabricacion], [TipoNaveCodigo]) VALUES (N'Executor', N'Darth Vader', N'Kuat', 1)
INSERT [dbo].[Nave] ([Nombre], [Capitan], [PlanetaFabricacion], [TipoNaveCodigo]) VALUES (N'Mandator III', N'Gideon Hask', N'Kuat', 1)
INSERT [dbo].[Nave] ([Nombre], [Capitan], [PlanetaFabricacion], [TipoNaveCodigo]) VALUES (N'TIE Advanced', N'Darth Vader', N'Lothal', 2)
INSERT [dbo].[Nave] ([Nombre], [Capitan], [PlanetaFabricacion], [TipoNaveCodigo]) VALUES (N'TIE Defender', N'Gideon Hask', N'Endor', 2)
INSERT [dbo].[Nave] ([Nombre], [Capitan], [PlanetaFabricacion], [TipoNaveCodigo]) VALUES (N'TIE Falcon', N'Del Meeko', N'Endor', 2)
INSERT [dbo].[Nave] ([Nombre], [Capitan], [PlanetaFabricacion], [TipoNaveCodigo]) VALUES (N'Tiger', N'Tycho Celchu', N'Lothal', 4)
