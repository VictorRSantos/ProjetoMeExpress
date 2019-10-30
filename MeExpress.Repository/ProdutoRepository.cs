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
        public List<Produto> ObterList()
        {
            return DbHelper.Query<Produto>("ProdutoObterList", null);
        }
    }
}
