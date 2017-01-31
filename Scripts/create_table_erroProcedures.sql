CREATE TABLE [ErroProcedures] (
    [ErroProceduresID] INT            IDENTITY (1, 1) NOT NULL,
    [Data]             DATETIME       DEFAULT (getdate()) NULL,
    [ProcName]         VARCHAR (256)  NULL,
    [ErrorLine]        INT            NULL,
    [ErrorNumber]      INT            NULL,
    [ErrorMessage]     VARCHAR (2048) NULL,
    [ErrorSeverity]    INT            NULL,
    [Obs]              VARCHAR (500)  NULL,
    PRIMARY KEY CLUSTERED ([ErroProceduresID] ASC)
);

