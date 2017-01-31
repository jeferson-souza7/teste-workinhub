/*********************************************************************
* Teste TaxWeb
* Nome Arquivo  : sp_Site_InserirLogErroAplicacao
* Objetivo(s)   :                                                                                                    
* Data Criação  : 29/01/2017
* Autor         : Jeferson de Souza
* Projeto       : JefersonDeSouza.UploadFile
-----------------------------------------------------------------------
* Historico de Modificações:
* Data      Autor           TarefaID  Descricao                                                                                                 
*--------------------------------------------------------------------*/                              
CREATE PROC sp_Site_InserirLogErroAplicacao(
    @XmlEnviado				VARCHAR(2048)	=	NULL,
	@XmlRecebido			VARCHAR(2048)	=	NULL,
	@Protocolo				VARCHAR(255)	=	NULL,
	@CodigoDoErro			VARCHAR(255),
	@MensagemDeErro			VARCHAR(2048),
	@TipoDeErro				VARCHAR(255),
	@MetodoDeChamadaInterno VARCHAR(255)	=	NULL,
    @Obs					VARCHAR(500)	=	NULL
)
AS
	
SET NOCOUNT ON	

BEGIN TRY
	INSERT LogErroAplicacao
		(
			XmlEnviado
		  , XmlRecebido
		  , Protocolo
		  , CodigoDoErro
		  , MensagemDeErro
		  , TipoDeErro
		  , MetodoDeChamadaInterno
		  , Obs
		)
	VALUES
		(
			@XmlEnviado
		  , @XmlRecebido
		  , @Protocolo
		  , @CodigoDoErro
		  , @MensagemDeErro
		  , @TipoDeErro
		  , @MetodoDeChamadaInterno
		  , @Obs
		)

END TRY
BEGIN CATCH
	INSERT INTO ErroProcedures(Data, ProcName, ErrorLine, ErrorNumber, ErrorMessage, ErrorSeverity, Obs)                                            
    VALUES (GETDATE(),ERROR_PROCEDURE(),ERROR_LINE(),ERROR_NUMBER(),ERROR_MESSAGE(),ERROR_SEVERITY(),'Erro de aplicação')                  
                                  
    DECLARE @ErrorMessage   NVARCHAR(2048) = ERROR_MESSAGE();                                            
    DECLARE @ErrorSeverity  INT            = ERROR_SEVERITY();                                            
    DECLARE @ErrorState     INT            = ERROR_STATE();                                            
                                            
    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);                                            
END CATCH

