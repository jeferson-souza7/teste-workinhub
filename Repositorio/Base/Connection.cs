using Dominio.Contratos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Repositorio.Base
{
    public class Connection : IConnection, IDisposable
    {
        private SqlConnection _connection;
        private string ConnectionString { get { return ConfigurationManager.ConnectionStrings["strConexao"].ToString(); } }

        public Connection()
        {
            _connection = new SqlConnection(this.ConnectionString);
        }

        public SqlConnection Abrir()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }

            return _connection;
        }

        public SqlConnection Buscar()
        {
            return this.Abrir();
        }

        public void Fechar()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public void Dispose()
        {
            this.Fechar();
            GC.SuppressFinalize(this);
        }
    }
}
