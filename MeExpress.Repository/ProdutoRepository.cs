using MeExpress.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {


        public List<Produto> ObterProdutoList()
        {

            var lista = new List<Produto>();

            lista.Add(new Produto() { Id = "abc", Nome = "Bloco de 500 folhas Papel A4", Preco = 20 });
            lista.Add(new Produto() { Id = "xyz", Nome = "Tinta para Impressora", Preco = 70 });
            return lista;

        }
    }
}
