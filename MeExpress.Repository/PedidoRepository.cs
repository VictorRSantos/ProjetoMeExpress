using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeExpress.Domain;

namespace MeExpress.Repository
{
    public class PedidoRepository : IPedidoRepository
    {

        private static List<Pedido> pedidos = new List<Pedido>();

        public void AlterarStatusPedido(string PedidoId, PedidoStatus status)
        {
            var pedido = pedidos.Where(m => m.Id == PedidoId).FirstOrDefault();
            pedido.Status = status;


        }

        public void Incluir(Pedido pedido)
        {
            pedidos.Add(pedido);
        }

        public List<Pedido> ObterPedidos()
        {
            return pedidos;
        }

        public List<Pedido> ObterPedidosEmProducao()
        {
            return pedidos.Where(m => m.Status == PedidoStatus.EmProducao).ToList();
        }

        public List<Pedido> ObterPedidosEmTransporte()
        {
            return pedidos.Where(m => m.Status == PedidoStatus.EmTransporte).ToList();
        }

        public List<Pedido> ObterPedidosEntregue()
        {
            return pedidos.Where(m => m.Status == PedidoStatus.Entregue).ToList();
        }

        public List<Pedido> ObterPedidosProduzidos()
        {
            return pedidos.Where(m => m.Status == PedidoStatus.Produzido).ToList();
        }

        public List<Pedido> ObterPedidosSolicitados()
        {
            return pedidos.Where(m => m.Status == PedidoStatus.Solicitado).ToList();
        }
    }
}
