CREATE TABLE UploadFile
(
	UploadFileId INT NOT NULL IDENTITY(1, 1),
	Comprador VARCHAR(255),
	Descricao VARCHAR(255),
	PrecoUnitario Decimal(5,2),
	Quantidade INT,
	Endereco VARCHAR(255),
	Fornecedor VARCHAR(255),
	Validado BIT,
	DataCriacao DATETIME DEFAULT GETDATE(),
	DataAtualizacao DATETIME,
	CONSTRAINT PK_UploadFile PRIMARY KEY(UploadFileId)
)