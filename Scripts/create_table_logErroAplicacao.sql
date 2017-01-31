CREATE TABLE [LogErroAplicacao] (
    [LogErroAplicacaoID]	 INT			IDENTITY (1, 1) NOT NULL,
    [Data]					 DATETIME		DEFAULT (getdate()) NULL,
    [XmlEnviado]			 VARCHAR (2048) NULL,
    [XmlRecebido]			 VARCHAR (2048) NULL,
    [Protocolo]				 VARCHAR (255)	NULL,
    [CodigoDoErro]			 VARCHAR (255)	NULL,
    [MensagemDeErro]		 VARCHAR (2048)	NULL,
    [TipoDeErro]			 VARCHAR (255)	NULL,
    [MetodoDeChamadaInterno] VARCHAR (255)	NULL,
    [Obs]					 VARCHAR (500)	NULL,
    PRIMARY KEY CLUSTERED ([LogErroAplicacaoID] ASC)
);

