using FiapSmartCity.Models;
using FiapSmartCity.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace FiapSmartCity.Repository
{
    public class ProdutoRepository
    {
        private readonly DataBaseContext context;

        public ProdutoRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        //public IList<Produto> Consultar(int id)
        //{
        //    TipoProdutoEF tipoProduto = context.TipoProdutoEF
        //        .FirstOrDefault(t => t.IdTipo == id);
        //    return tipoProduto.Produto;
        //}


        public IList<Produto> Consultar(int idTipo)
        {
            // Consulta a lista de produtos de um determinado tipo.
            var tipoProduto =
                context.TipoProdutoEF
                    .Include(t => t.Produto)
                    .FirstOrDefault(t => t.IdTipo == idTipo);

            return tipoProduto.Produto;
        }
    }
}