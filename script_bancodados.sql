USE [db_Cliente]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 18/08/2019 20:39:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[cpf] [nvarchar](50) NOT NULL,
	[telefone] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO