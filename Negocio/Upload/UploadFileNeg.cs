using Biblioteca.Helpers;
using Dominio.Contratos.Upload;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Negocio.Upload
{
    public class UploadFileNeg
    {
        private IUploadFileRep _uplodRep;

        public UploadFileNeg(IUploadFileRep uplodRep)
        {
            _uplodRep = uplodRep;
        }

        public void NormalizarDados(List<string> dados)
        {
            var lstUpload = new List<Dominio.Upload.UploadFile>();
            //int qtdLinhas = dados.Count(linha => linha.Equals("NOVA LINHA"));
            int qtdColunas = 6;
            int count = 0;

            for (int i = 1; i <= (dados.Count / qtdColunas); i++)
            {
                var upload = new Dominio.Upload.UploadFile();

                upload.Comprador = dados[count].ToString();
                count++;

                upload.Descricao = dados[count].ToString();
                count++;

                upload.PrecoUnitario = decimal.Parse(dados[count].ToString());
                count++;

                upload.Quantidade = int.Parse(dados[count].ToString());
                count++;

                upload.Endereco = dados[count].ToString();
                count++;

                upload.Fornecedor = dados[count].ToString();
                count++;

                lstUpload.Add(upload);
            }
        }

        public Dominio.Upload.UploadFile Inserir(List<string> dados)
        {
            NormalizarDados(dados);

            if (true)
            {
                var upload = new Dominio.Upload.UploadFile();
                return _uplodRep.Inserir(upload);
            }
            else
            {
                return null;
            }
        }

        public ICollection<Dominio.Upload.UploadFile> ListarTodos()
        {
            return _uplodRep.ListarTodos();
        }
    }
}
