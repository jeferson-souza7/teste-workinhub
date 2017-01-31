/*********************************************************************
* Teste TaxWeb
* Nome Arquivo  : sp_Site_InserirUploadFile
* Objetivo(s)   :                                                                                                    
* Data Criação  : 29/01/2017
* Autor         : Jeferson de Souza
* Projeto       : JefersonDeSouza.UploadFile
-----------------------------------------------------------------------
* Historico de Modificações:
* Data      Autor           TarefaID  Descricao                                                                                                 
*--------------------------------------------------------------------*/                              
CREATE PROC sp_Site_InserirUploadFile(
    @Comprador		VARCHAR(255),
	@Descricao		VARCHAR(255),
	@PrecoUnitario	DECIMAL(5,2),
	@Quantidade		INT,
	@Endereco		VARCHAR(255),
	@Fornecedor		VARCHAR(255),
	@Validado		BIT,
	@DataCriacao	DATETIME
)
AS
	
SET NOCOUNT ON	

DECLARE @UploadFileIdNovo INT

BEGIN TRY
	INSERT UploadFile
		(
			Comprador
		  , Descricao
		  , PrecoUnitario
		  , Quantidade
		  , Endereco
		  , Fornecedor
		  , Validado
		  , DataCriacao
		)
	VALUES
		(
			@Comprador
		  , @Descricao
		  , @PrecoUnitario
		  , @Quantidade
		  , @Endereco
		  , @Fornecedor
		  , @Validado
		  , @DataCriacao
		)
		
	SET @UploadFileIdNovo = SCOPE_IDENTITY()

	GOTO FIM

	FIM:
		SELECT DISTINCT
			uplodaFile.UploadFileId
		  , ISNULL(uplodaFile.Comprador, '') AS Comprador
		  , ISNULL(uplodaFile.Descricao, '') AS Descricao
		  , ISNULL(uplodaFile.PrecoUnitario, 0) AS PrecoUnitario
		  , ISNULL(uplodaFile.Quantidade, 0) AS Quantidade
		  , ISNULL(uplodaFile.Endereco, '') AS Endereco
		  , ISNULL(uplodaFile.Fornecedor, '') AS Fornecedor
		  , ISNULL(uplodaFile.Validado, 0) AS Validado
		  , ISNULL(uplodaFile.DataCriacao, '') AS DataCriacao
		  , ISNULL(uplodaFile.DataAtualizacao, '') AS DataAtualizacao
		FROM
			UploadFile uplodaFile WITH(NOLOCK,NOWAIT)
		WHERE
			uplodaFile.UploadFileId = @UploadFileIdNovo

END TRY
BEGIN CATCH
	INSERT INTO ErroProcedures(Data, ProcName, ErrorLine, ErrorNumber, ErrorMessage, ErrorSeverity, Obs)                                            
    VALUES (GETDATE(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_NUMBER(),ERROR_MESSAGE(),ERROR_SEVERITY(),'UploadFileId = ' + CAST(@UploadFileIdNovo AS VARCHAR(10)))                  
                                  
    DECLARE @ErrorMessage   NVARCHAR(2048) = ERROR_MESSAGE();                                            
    DECLARE @ErrorSeverity  INT            = ERROR_SEVERITY();                                            
    DECLARE @ErrorState     INT            = ERROR_STATE();                                            
                                            
    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);                                            
END CATCH

