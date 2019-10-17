using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Domain
{
    //Essa classe serve para verificar status do pedido tem.
    public enum PedidoStatus
    {
        Solicitado = 1,
        EmProducao = 2,
        Produzido = 3,
        EmTransporte = 4,
        Entregue = 5

    }
}
