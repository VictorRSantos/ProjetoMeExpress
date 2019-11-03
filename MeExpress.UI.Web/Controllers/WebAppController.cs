using MeExpress.ApplicationServices;
using MeExpress.Domain;
using MeExpress.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeExpress.UI.Web.Controllers
{
    public class WebAppController : Controller
    {
        private IClienteAppService clienteApp;
        private IPedidoAppService pedidoApp;

        public WebAppController(IClienteAppService clienteAppInstance, IPedidoAppService pedidoAppInstance)
        {
            this.clienteApp = clienteAppInstance;
            this.pedidoApp = pedidoAppInstance;
        }



        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult PedidoNovo()
        {
            return View();
        }

        public ActionResult PedidoNovoConfirmarCliente(string CPF)
        {
            var cliente = clienteApp.ObterPorCpf(CPF);
            if (cliente == null)
            {
                cliente = new Cliente()
                {
                    CPF = CPF
                };

            }
            return View(cliente);
        }


        [HttpPost]
        public ActionResult PedidoNovoConfirmarCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Id))
            {
                cliente.Id = Guid.NewGuid().ToString();
                clienteApp.Incluir(cliente);
            }
            else
            {
                clienteApp.Alterar(cliente);
            }
            return RedirectToAction("PedidoIncluir", "WebApp", new { clienteId = cliente.Id });
        }

        public ActionResult PedidoIncluir(string clienteId)
        {
            var pedido = pedidoApp.ObterNovoPedido(clienteId);
            return View(pedido);
        }

        [HttpPost]
        public ActionResult PedidoIncluir(Pedido pedido)
        {
            if (Request.Form["submitButton"] != null)
            {
                pedido.Status = PedidoStatus.Solicitado;                
                pedidoApp.Incluir(pedido);
                return RedirectToAction("Inicio");
            }
            return View(pedido);

        }

        public ActionResult PedidoPorStatus(PedidoStatus status)
        {
            List<Pedido> pedidos = null;
            switch (status)
            {
                case PedidoStatus.Solicitado:
                    pedidos = pedidoApp.ObterPedidosSolicitados();
                    break;
                case PedidoStatus.EmProducao:
                    pedidos = pedidoApp.ObterPedidosEmProducao();
                    break;
                case PedidoStatus.Produzido:
                    pedidos = pedidoApp.ObterPedidosProduzidos();
                    break;
                case PedidoStatus.EmTransporte:
                    pedidos = pedidoApp.ObterPedidosEmTransporte();
                    break;
                case PedidoStatus.Entregue:
                    pedidos = pedidoApp.ObterPedidosEntregues();
                    break;

            }

            if (pedidos == null)
            {
                return RedirectToAction("Inicio");
            }

            var lista = new PedidoListViewModel();
            lista.PedidoList = pedidos;
            lista.Status = status;


            return View(lista);
        }
              



        public ActionResult PedidoAlterarStatus(string pedidoId, PedidoStatus status)
        {
            pedidoApp.AlterarStatusPedido(pedidoId, status);
            return RedirectToAction("Inicio");

        }

    }
}
