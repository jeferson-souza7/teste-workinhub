using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contratos.Base
{
    public interface IConnection
    {
        SqlConnection Abrir();
        SqlConnection Buscar();
        void Fechar();
    }
}
