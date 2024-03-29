USE [MeExpressDB]
GO
/****** Object:  User [DESKTOP\Victor Rodrigues]    Script Date: 03/11/2019 01:34:22 ******/
CREATE USER [DESKTOP\Victor Rodrigues] FOR LOGIN [DESKTOP\Victor Rodrigues] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [varchar](36) NOT NULL,
	[Nome] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[CPF] [varchar](18) NULL,
	[Empresa] [varchar](100) NULL,
	[Endereco] [varchar](100) NULL,
	[Numero] [varchar](20) NULL,
	[Complemento] [varchar](20) NULL,
	[Bairro] [varchar](100) NULL,
	[Cidade] [varchar](100) NULL,
	[Estado] [varchar](2) NULL,
	[CEP] [varchar](9) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [varchar](36) NOT NULL,
	[Numero] [int] IDENTITY(1,1) NOT NULL,
	[DataSolicitado] [datetime] NOT NULL,
	[DataEmProducao] [datetime] NULL,
	[DataProduzido] [datetime] NULL,
	[DataEmTransporte] [datetime] NULL,
	[DataEntregue] [datetime] NULL,
	[PedidoStatusId] [int] NULL,
	[ClienteId] [varchar](36) NULL,
	[ClienteNome] [varchar](100) NULL,
	[ClienteEmail] [varchar](100) NULL,
	[ClienteCPF] [varchar](18) NULL,
	[ClienteEmpresa] [varchar](100) NULL,
	[ClienteEndereco] [varchar](100) NULL,
	[ClienteNumero] [varchar](20) NULL,
	[ClienteComplemento] [varchar](20) NULL,
	[ClienteBairro] [varchar](100) NULL,
	[ClienteCidade] [varchar](100) NULL,
	[ClienteEstado] [varchar](2) NULL,
	[ClienteCep] [varchar](9) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoProdutoItem]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoProdutoItem](
	[Id] [varchar](36) NOT NULL,
	[PedidoId] [varchar](36) NULL,
	[ProdutoId] [varchar](36) NULL,
	[ProdutoNome] [varchar](100) NULL,
	[ProdutoPreco] [money] NULL,
	[Quantidade] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoStatus]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoStatus](
	[Id] [int] NOT NULL,
	[Nome] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[Id] [varchar](36) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Preco] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD FOREIGN KEY([PedidoStatusId])
REFERENCES [dbo].[PedidoStatus] ([Id])
GO
ALTER TABLE [dbo].[PedidoProdutoItem]  WITH CHECK ADD FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[PedidoProdutoItem]  WITH CHECK ADD FOREIGN KEY([ProdutoId])
REFERENCES [dbo].[Produto] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[ClienteAlterar]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- STORED Procedures: ClienteAlterar
------------------------------------------------------
CREATE PROCEDURE [dbo].[ClienteAlterar]

@Id varchar(36),
@Nome varchar(100),
@Email varchar(100),
@Empresa varchar(100),
@Endereco varchar(100),
@Numero varchar(20),
@Complemento varchar(20),
@Bairro varchar(100),
@Cidade varchar(100),
@Estado varchar(2),
@CEP varchar(9),
@CPF varchar(14)

AS

UPDATE Cliente 
SET Nome=@Nome,Email=@Email, Empresa=@Empresa,Endereco=@Endereco, Numero=@Numero, Complemento=@Complemento, Bairro=@Bairro,Cidade=@Cidade,Estado=@Estado,CEP=@Cep, Cpf=@Cpf
WHERE Id=@Id

GO
/****** Object:  StoredProcedure [dbo].[ClienteIncluir]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


------------------------------------------------------
-- STORED Procedures: ClienteIncluir
------------------------------------------------------
CREATE PROCEDURE [dbo].[ClienteIncluir]

@Id varchar(36),
@Nome varchar(100),
@Email varchar(100),
@Empresa varchar(100),
@Endereco varchar(100),
@Numero varchar(20),
@Complemento varchar(20),
@Bairro varchar(100),
@Cidade varchar(100),
@Estado varchar(2),
@CPF varchar(14),
@CEP varchar(9)

AS

INSERT INTO Cliente(Id,Email, Nome,Empresa,Endereco,Numero,Complemento,Bairro,Cidade,Estado,CPF, CEP)
VALUES (@Id,@Email,@Nome,@Empresa,@Endereco,@Numero,@Complemento,@Bairro,@Cidade,@Estado,@CPF,@CEP );
GO
/****** Object:  StoredProcedure [dbo].[ClienteObterPorCPF]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- STORED Procedures: ClienteObterPorCPF
------------------------------------------------------
CREATE PROCEDURE [dbo].[ClienteObterPorCPF]

@CPF varchar(14)

AS

SELECT Id,Email, Nome,Empresa,Endereco,Numero,Complemento,Bairro,Cidade,Estado,CEP, CPF
FROM Cliente
WHERE CPF=@CPF

GO
/****** Object:  StoredProcedure [dbo].[ClienteObterPorId]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- STORED Procedures: ClienteObterPorId
------------------------------------------------------
CREATE PROCEDURE [dbo].[ClienteObterPorId]

@Id varchar(100)

AS

SELECT Id,Email, Nome,Empresa,Endereco,Numero,Complemento,Bairro,Cidade,Estado,CEP, CPF
FROM Cliente
WHERE Id=@Id

GO
/****** Object:  StoredProcedure [dbo].[PedidoIncluir]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




------------------------------------------------------
-- STORED Procedures: PedidoIncluir
------------------------------------------------------
CREATE PROCEDURE [dbo].[PedidoIncluir]

@Id varchar(36),
@DataSolicitado DateTime,
@ClienteId varchar(36),
@ClienteNome varchar(100),
@ClienteEmail varchar(100),
@ClienteEmpresa varchar(100),
@ClienteEndereco varchar(100),
@ClienteNumero varchar(20),
@ClienteComplemento varchar(20),
@ClienteBairro varchar(100),
@ClienteCidade varchar(100),
@ClienteEstado varchar(2),
@ClienteCPF varchar(14),
@ClienteCEP varchar(9),
@PedidoStatusId int
AS

INSERT INTO Pedido(Id,DataSolicitado,ClienteId,ClienteNome,ClienteEmail,ClienteEmpresa,ClienteEndereco,ClienteNumero,ClienteComplemento,ClienteBairro,ClienteCidade,ClienteEstado,ClienteCPF,ClienteCEP,PedidoStatusId)
VALUES (@Id, @DataSolicitado, @ClienteId, @ClienteNome, @ClienteEmail, @ClienteEmpresa, @ClienteEndereco, @ClienteNumero, @ClienteComplemento, @ClienteBairro, @ClienteCidade, @ClienteEstado, @ClienteCPF,@ClienteCEP, @PedidoStatusId);

GO
/****** Object:  StoredProcedure [dbo].[PedidoObterPorId]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


------------------------------------------------------
-- STORED Procedures: PedidoObterPorPedidoStatus
------------------------------------------------------
CREATE PROCEDURE [dbo].[PedidoObterPorId]

@id varchar(36)

AS

Select Id, Numero, DataSolicitado, DataEmProducao,DataProduzido,DataEmTransporte,DataEntregue,
ClienteId,ClienteNome,ClienteEmpresa,ClienteEndereco,ClienteNumero,ClienteComplemento,ClienteBairro,ClienteCidade,ClienteEstado,ClienteCPF,ClienteCep
FROM Pedido
WHERE Pedido.Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[PedidoObterPorPedidoStatus]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



------------------------------------------------------
-- STORED Procedures: PedidoObterPorPedidoStatus
------------------------------------------------------
CREATE PROCEDURE [dbo].[PedidoObterPorPedidoStatus]

@PedidoStatusId int

AS

Select Id, Numero, DataSolicitado, DataEmProducao,DataProduzido,DataEmTransporte,DataEntregue,
ClienteId,ClienteNome,ClienteEmpresa,ClienteEndereco,ClienteNumero,ClienteComplemento,ClienteBairro,ClienteCidade,ClienteEstado,ClienteCPF,ClienteCep
FROM Pedido
WHERE Pedido.PedidoStatusId=@PedidoStatusId
GO
/****** Object:  StoredProcedure [dbo].[PedidoProdutoIncluir]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- STORED Procedures: PedidoProdutoIncluir
------------------------------------------------------
CREATE PROCEDURE [dbo].[PedidoProdutoIncluir]

@Id varchar(36),
@PedidoId varchar(36),
@ProdutoId varchar(36),
@ProdutoNome varchar(100),
@ProdutoPreco money,
@Quantidade int
AS

INSERT INTO PedidoProdutoItem(Id,PedidoId,ProdutoId,ProdutoNome,ProdutoPreco,Quantidade)
VALUES (@Id,@PedidoId,@ProdutoId,@ProdutoNome,@ProdutoPreco,@Quantidade);

GO
/****** Object:  StoredProcedure [dbo].[PedidoProdutoItemObterPorPedidoId]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



------------------------------------------------------
-- STORED Procedures: PedidoProdutoObterPorPedidoId
------------------------------------------------------
CREATE PROCEDURE [dbo].[PedidoProdutoItemObterPorPedidoId]

@PedidoId varchar(36)

AS

SELECT Id, PedidoId, ProdutoId, ProdutoNome, ProdutoPreco, Quantidade
FROM PedidoProdutoItem
WHERE PedidoId=@PedidoId
GO
/****** Object:  StoredProcedure [dbo].[PedidoStatusAlterar]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



------------------------------------------------------
-- STORED Procedures: PedidoStatusAlterar
------------------------------------------------------
CREATE PROCEDURE [dbo].[PedidoStatusAlterar]

@PedidoId varchar(36),
@PedidoStatusId int

as 

UPDATE Pedido SET PedidoStatusId=@PedidoStatusId WHERE Id=@PedidoId

GO
/****** Object:  StoredProcedure [dbo].[ProdutoObterList]    Script Date: 03/11/2019 01:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



------------------------------------------------------
-- STORED Procedures: ClienteObterPorCPF
------------------------------------------------------
CREATE PROCEDURE [dbo].[ProdutoObterList]

AS

SELECT Id,Nome,Preco
FROM Produto

GO
