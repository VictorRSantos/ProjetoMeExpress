using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Domain
{
    public class Pedido
    {
        public string Id { get; set; }

        public Cliente Cliente { get; set; }

        public PedidoStatus Status { get; set; }

        public DateTime DataSolicitado { get; set; }

        // ? = Nullable - Pode Sem um valor NULL
        public DateTime? DataEmProducao { get; set; }

        public DateTime? DataProduzido { get; set; }

        public DateTime? DataEmTransporte { get; set; }

        public DateTime? DataEntregue { get; set; }

        public List<PedidoProdutoItem> ProdutoList { get; set; }

    }
}
