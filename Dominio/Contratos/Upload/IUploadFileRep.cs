using Dominio.Contratos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contratos.Upload
{
   public  interface IUploadFileRep : IRep<Dominio.Upload.UploadFile>
    {
        /// <summary>
        /// Método responsável por retornar o total de registros
        /// </summary>
        /// <returns></returns>
        int CountTotalCadastrado();
    }
}
