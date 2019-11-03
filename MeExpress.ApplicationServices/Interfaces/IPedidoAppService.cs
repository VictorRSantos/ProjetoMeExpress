using MeExpress.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.ApplicationServices
{
    public interface IPedidoAppService : IPedidoRepository
    {

        Pedido ObterNovoPedido(string clienteId);

    }
}
