using Dominio.Contratos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Upload;
using System.Linq.Expressions;
using Repositorio.Base;
using System.Data.SqlClient;
using Dominio.Contratos.Upload;
using System.Data;

namespace Repositorio.Upload
{
    public class UploadFileRep : IRep<Dominio.Upload.UploadFile>, IUploadFileRep
    {
        public int CountTotalCadastrado()
        {
            throw new NotImplementedException();
        }

        public Dominio.Upload.UploadFile Inserir(Dominio.Upload.UploadFile entity)
        {
            var retorno = new Dominio.Upload.UploadFile();

            try
            {
                using (Connection con = new Connection())
                {
                    con.Abrir();

                    using (var comando = con.Buscar().CreateCommand())
                    {
                        comando.Connection = con.Buscar();

                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        comando.CommandText = "sp_Site_InserirUploadFile";

                        comando.Parameters.Add(new SqlParameter("@Comprador", entity.Comprador));
                        comando.Parameters.Add(new SqlParameter("@Descricao", entity.Descricao));
                        comando.Parameters.Add(new SqlParameter("@PrecoUnitario", entity.PrecoUnitario));
                        comando.Parameters.Add(new SqlParameter("@Quantidade", entity.Quantidade));
                        comando.Parameters.Add(new SqlParameter("@Endereco", entity.Endereco));
                        comando.Parameters.Add(new SqlParameter("@Fornecedor", entity.Fornecedor));
                        comando.Parameters.Add(new SqlParameter("@Validado", entity.Validado));
                        comando.Parameters.Add(new SqlParameter("@DataCriacao", entity.DataCriacao));

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                retorno.Id = int.Parse(reader["UploadFileId"].ToString());
                                retorno.Comprador = reader["Comprador"].ToString();
                                retorno.Descricao = reader["Descricao"].ToString();
                                retorno.PrecoUnitario = decimal.Parse(reader["PrecoUnitario"].ToString());
                                retorno.Quantidade = int.Parse(reader["Quantidade"].ToString());
                                retorno.Endereco = reader["Endereco"].ToString();
                                retorno.Fornecedor = reader["Fornecedor"].ToString();
                                retorno.Validado = bool.Parse(reader["Validado"].ToString());
                                retorno.DataCriacao = DateTime.Parse(reader["DataCriacao"].ToString());
                                retorno.DataAtualizacao = DateTime.Parse(reader["DataAtualizacao"].ToString());
                            }
                        }
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ICollection<Dominio.Upload.UploadFile> ListarTodos()
        {
            var retorno = new List<Dominio.Upload.UploadFile>();

            try
            {
                using (Connection con = new Connection())
                {
                    con.Abrir();

                    using (var comando = con.Buscar().CreateCommand())
                    {
                        comando.Connection = con.Buscar();

                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        comando.CommandText = "sp_Site_ListarTodosUploadsFiles";

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                retorno.Add(new Dominio.Upload.UploadFile()
                                {
                                    Id = int.Parse(reader["UploadFileId"].ToString()),
                                    Comprador = reader["Comprador"].ToString(),
                                    Descricao = reader["Descricao"].ToString(),
                                    PrecoUnitario = decimal.Parse(reader["PrecoUnitario"].ToString()),
                                    Quantidade = int.Parse(reader["Quantidade"].ToString()),
                                    Endereco = reader["Endereco"].ToString(),
                                    Fornecedor = reader["Fornecedor"].ToString(),
                                    Validado = bool.Parse(reader["Validado"].ToString()),
                                    DataCriacao = DateTime.Parse(reader["DataCriacao"].ToString()),
                                    DataAtualizacao = DateTime.Parse(reader["DataAtualizacao"].ToString())
                                });

                                //var upload = new Dominio.Upload.Upload();

                                //upload.Id = int.Parse(reader["UploadId"].ToString());
                                //upload.Descricao = reader["Descricao"].ToString();
                                //upload.PrecoUnitario = decimal.Parse(reader["PrecoUnitario"].ToString());
                                //upload.Quantidade = int.Parse(reader["Quantidade"].ToString());
                                //upload.Endereco = reader["Endereco"].ToString();
                                //upload.Fornecedor = reader["Fornecedor"].ToString();

                                //retorno.Add(upload);
                            }
                        }
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}