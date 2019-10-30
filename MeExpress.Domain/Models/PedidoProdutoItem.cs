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

        public int Id { get; set; }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        //Propriedade somente leitura
        public decimal Total
        {
            get
            {
                return Produto.Preco * Quantidade;

            }
        }


    }
}
