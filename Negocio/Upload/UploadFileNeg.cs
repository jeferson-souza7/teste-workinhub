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

        public List<Dominio.Upload.UploadFile> NormalizarDados(List<string> dados)
        {
            var lstUpload = new List<Dominio.Upload.UploadFile>();
            int qtdColunas = ConfigurationManager.AppSettings["PathRelative.Conferencia.Cabecalho"].ToString().Split(',').ToList<string>().Count;
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

            return lstUpload;
        }

        public Dominio.Upload.UploadFile Inserir(List<string> dados)
        {
            var listaNormalizada = NormalizarDados(dados);
            var retorno = new Dominio.Upload.UploadFile();

            foreach (var upload in listaNormalizada)
            {
                upload.Validado = true;
                upload.DataCriacao = DateTime.Now;
                retorno = _uplodRep.Inserir(upload);
            }

            return retorno;
        }

        public ICollection<Dominio.Upload.UploadFile> ListarTodos()
        {
            return _uplodRep.ListarTodos();
        }
    }
}