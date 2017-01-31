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
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(LogConnection.ConnectionString("StringDeConexaoLog"));

                conexao.Open();

                comando = new SqlCommand("sp_InserirLogDeErro", conexao) { CommandType = CommandType.StoredProcedure };

                comando.Parameters.AddWithValue("@pedidoId", log.PedidoId);
                comando.Parameters.AddWithValue("@participanteId", log.ParticipanteId);
                comando.Parameters.AddWithValue("@sku", log.Sku);
                comando.Parameters.AddWithValue("@xmlEnviado", log.XmlEnviado);
                comando.Parameters.AddWithValue("@xmlRecebido", log.XmlRecebido);
                comando.Parameters.AddWithValue("@protocolo", log.Protocolo);
                comando.Parameters.AddWithValue("@codigoDoErro", log.CodigoDoErro);
                comando.Parameters.AddWithValue("@mensagemDeErro", log.MensagemDeErro);
                comando.Parameters.AddWithValue("@tipoDeErro", log.TipoDeErro);
                comando.Parameters.AddWithValue("@metodoDeChamadaInterno", log.MetodoDeChamadaInterno);
                comando.Parameters.AddWithValue("@urlWs", log.UrlWs);

                comando.ExecuteNonQuery();
            }
            finally
            {
                if (comando != null) comando.Dispose();

                if (conexao != null)
                {
                    if (conexao.State != ConnectionState.Closed)
                        conexao.Close();

                    conexao.Dispose();
                }
            }
        }
    }
}
