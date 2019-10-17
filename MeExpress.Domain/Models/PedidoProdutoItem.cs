using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Domain
{
    public class PedidoProdutoItem
    {
        //Essa classe vai como um histórico do Pedido
        public Produto Produto { get; set; }

        public int  Quantidade { get; set; }


        

    }
}
