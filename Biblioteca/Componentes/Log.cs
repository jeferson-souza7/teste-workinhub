using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Componentes
{
    public class Log
    {
        public void Salvar(dynamic log)
        {
            #region modo 1
            //SqlConnection conexao = null;
            //SqlCommand comando = null;

            //try
            //{
            //    conexao = new SqlConnection(LogConnection.ConnectionString("StringDeConexaoLog"));

            //    conexao.Open();

            //    comando = new SqlCommand("sp_Site_InserirLogErroAplicacao", conexao) { CommandType = CommandType.StoredProcedure };

            //    comando.Parameters.AddWithValue("@XmlEnviado", log.XmlEnviado);
            //    comando.Parameters.AddWithValue("@XmlRecebido", log.XmlRecebido);
            //    comando.Parameters.AddWithValue("@Protocolo", log.Protocolo);
            //    comando.Parameters.AddWithValue("@CodigoDoErro", log.CodigoDoErro);
            //    comando.Parameters.AddWithValue("@MensagemDeErro", log.MensagemDeErro);
            //    comando.Parameters.AddWithValue("@TipoDeErro", log.TipoDeErro);
            //    comando.Parameters.AddWithValue("@MetodoDeChamadaInterno", log.MetodoDeChamadaInterno);

            //    comando.ExecuteNonQuery();
            //}

            //finally
            //{
            //    if (comando != null) comando.Dispose();

            //    if (conexao != null)
            //    {
            //        if (conexao.State != ConnectionState.Closed)
            //            conexao.Close();

            //        conexao.Dispose();
            //    }
            //}
            #endregion

            using (SqlConnection con = new SqlConnection(LogConnection.ConnectionString("StringDeConexaoLog")))
            {
                con.Open();

                using (var comando = con.CreateCommand())
                {
                    comando.Connection = con;

                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "sp_Site_InserirUploadFile";

                    comando.Parameters.Add(new SqlParameter("@XmlEnviado", log.XmlEnviado));
                    comando.Parameters.Add(new SqlParameter("@XmlRecebido", log.XmlRecebido));
                    comando.Parameters.Add(new SqlParameter("@Protocolo", log.Protocolo));
                    comando.Parameters.Add(new SqlParameter("@CodigoDoErro", log.CodigoDoErro));
                    comando.Parameters.Add(new SqlParameter("@MensagemDeErro", log.MensagemDeErro));
                    comando.Parameters.Add(new SqlParameter("@TipoDeErro", log.TipoDeErro));
                    comando.Parameters.Add(new SqlParameter("@MetodoDeChamadaInterno", log.MetodoDeChamadaInterno));

                    try
                    {
                        var result = comando.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
    }
}