USE [Cuarto]
GO
/****** Object:  Table [dbo].[Cargos]    Script Date: 12/12/2024 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargos](
	[idCargo] [int] IDENTITY(1,1) NOT NULL,
	[Detalle] [nvarchar](50) NULL,
 CONSTRAINT [PK_Cargos] PRIMARY KEY CLUSTERED 
(
	[idCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 12/12/2024 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](
	[IdPais] [int] IDENTITY(1,1) NOT NULL,
	[Cetalle] [nvarchar](50) NULL,
 CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED 
(
	[IdPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personales]    Script Date: 12/12/2024 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personales](
	[idPersonal] [int] NOT NULL,
	[Nombres] [nvarchar](50) NULL,
	[IdCargo] [int] NULL,
	[Sueldo] [decimal](18, 2) NULL,
	[Idpais] [int] NULL,
 CONSTRAINT [PK_Personales] PRIMARY KEY CLUSTERED 
(
	[idPersonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Personales]  WITH CHECK ADD  CONSTRAINT [FK_Personales_Cargos] FOREIGN KEY([IdCargo])
REFERENCES [dbo].[Cargos] ([idCargo])
GO
ALTER TABLE [dbo].[Personales] CHECK CONSTRAINT [FK_Personales_Cargos]
GO
ALTER TABLE [dbo].[Personales]  WITH CHECK ADD  CONSTRAINT [FK_Personales_Paises] FOREIGN KEY([Idpais])
REFERENCES [dbo].[Paises] ([IdPais])
GO
ALTER TABLE [dbo].[Personales] CHECK CONSTRAINT [FK_Personales_Paises]
GO
