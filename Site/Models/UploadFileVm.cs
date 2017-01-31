using Dominio.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class UploadFileVm
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

        public static UploadFileVm ParaViewModel(UploadFile file)
        {
            var uploadFileVm = new UploadFileVm
            {
                Id = file.Id,
                Comprador = file.Comprador,
                Descricao = file.Descricao,
                Endereco = file.Endereco,
                Fornecedor = file.Fornecedor,
                PrecoUnitario = file.PrecoUnitario,
                Quantidade = file.Quantidade,
                Name = file.Name,
                Type = file.Type,
                Length = file.Length,
                Validado = file.Validado,
                DataCriacao = file.DataCriacao,
                DataAtualizacao = file.DataAtualizacao
            };

            return uploadFileVm;
        }

        public static UploadFile ParaRepository(UploadFileVm fileVm)
        {
            var file = new UploadFile
            {
                Id = fileVm.Id,
                Comprador = fileVm.Comprador,
                Descricao = fileVm.Descricao,
                Endereco = fileVm.Endereco,
                Fornecedor = fileVm.Fornecedor,
                PrecoUnitario = fileVm.PrecoUnitario,
                Quantidade = fileVm.Quantidade,
                Name = fileVm.Name,
                Type = fileVm.Type,
                Length = fileVm.Length,
                Validado = fileVm.Validado,
                DataCriacao = fileVm.DataCriacao,
                DataAtualizacao = fileVm.DataAtualizacao
            };

            return file;
        }

        public static ICollection<UploadFileVm> ParaViewModel(ICollection<UploadFile> lstFile)
        {
            return lstFile.Select(file => ParaViewModel(file)).ToList();
        }
    }
}