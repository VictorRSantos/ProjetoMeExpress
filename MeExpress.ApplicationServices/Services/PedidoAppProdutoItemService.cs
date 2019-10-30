using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeExpress.Domain;

namespace MeExpress.ApplicationServices.Services
{
    public class PedidoAppProdutoItemService : IPedidoAppProdutoItemService
    {
        private IPedidoProdutoItemRepository pedidoProdutoItemRepository;


        public PedidoAppProdutoItemService(IPedidoProdutoItemRepository pedidoProdutoItemInstance)
        {
            this.pedidoProdutoItemRepository = pedidoProdutoItemInstance;
        }



        public List<PedidoProdutoItem> ObterPedidoProdutoItem()
        {
            throw new NotImplementedException();
        }
    }
}
