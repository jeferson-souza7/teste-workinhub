using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contratos.Base
{
    /// <summary>
    /// Interface genérica
    /// Suportando qualquer objeto que seja uma classe, e/ou uma instância.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRep<T>
        where T : class, new()
    {
        /// <summary>
        /// Assinatura de método responsável por inserir
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Inserir(T entity);

        /// <summary>
        /// Assinatura de método responsável por listar todos os registros
        /// </summary>
        /// <returns></returns>
        ICollection<T> ListarTodos();
    }
}
