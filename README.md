# Instruções para instalação e execução
First evaluation of project Upload Files

CONFIGURAÇÃO DO BANCO DE DADOS

Dentro da pasta "Scripts" contém os arquivos necessários para efetuar a criação do banco, tabelas, e procedures.
A ordem de execução tem que ser a seguinte:

1 - create_database.sql

2 - create_table_erroProcedures.sql

3 - create_table_upload.sql

4 - create_logErroAplicacao.sql

5 - sp_Site_InserirLogErroAplicacao.sql

6 - sp_Site_InserirUploadFile.sql

7 - sp_Site_ListarTodosUploadsFiles.sql


Após executar esses scripts será necessário atualizar o arquivo "Web.Config" nas connectionStrings, informando o nome da máquina e a instancia do servidor SQL,
como por exemplo: 

< add name="strConexao" connectionString="Data Source=Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=teste_taxweb;Data Source=JEFERSON-PC\SQLEXPRESS" />


< add name="StringDeConexaoLog" connectionString="Data Source=Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=teste_taxweb;Data Source=JEFERSON-PC\SQLEXPRESS" />

É essencialmente fundamental que você atualize as duas connectionStrings.

CONFIGURAÇÃO DA APLICAÇÃO

Requisitos: 


1 - .NET 4.5.2

2 - IIS

3 - Visual Studio 2015

Funcionalidade:

1 - Apenas arquivos com extensão .txt

2 - Seguir o mesmo modelo disponibilizado no diretório: https://github.com/taxweb/avaliacao_desenvolvedor
