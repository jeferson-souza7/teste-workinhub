using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Upload
{
    public class UploadFile
    {
        public int Id { get; set; }
        public string Comprador { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public string Endereco { get; set; }
        public string Fornecedor { get; set; }
        public bool Validado { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Length { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
