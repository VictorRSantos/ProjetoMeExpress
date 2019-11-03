using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeExpress.Domain;

namespace MeExpress.ApplicationServices
{
    public class PedidoAppService : IPedidoAppService
    {

        private IPedidoRepository pedidoRepository;
        private IProdutoRepository produtoRepository;
        private IClienteRepository clienteRepository;

        public PedidoAppService(IPedidoRepository pedidoRepositoryInstance, IProdutoRepository produtoRepositoryInstance, IClienteRepository clienteRepositoryInstance)
        {
            this.pedidoRepository = pedidoRepositoryInstance;
            this.produtoRepository = produtoRepositoryInstance;
            this.clienteRepository = clienteRepositoryInstance;
        }

        public void AlterarStatusPedido(string pedidoId, PedidoStatus status)
        {
            pedidoRepository.AlterarStatusPedido(pedidoId, status);
        }

        public void Incluir(Pedido pedido)
        {
            pedidoRepository.Incluir(pedido);
        }

        public Pedido ObterNovoPedido(string clienteId)
        {

            var pedido = new Pedido();//Novo Pedido
            pedido.Cliente = clienteRepository.ObterPorId(clienteId);//Vai pegar o cliente pelo ID

            var produtos = produtoRepository.ObterList();//Carrega lista de produto do Repository
            pedido.ProdutoList = new List<PedidoProdutoItem>();//Cria uma lista de produto


            foreach (var produto in produtos)   //Vai percorrer cada um da lista de produto
            {

                pedido.ProdutoList.Add(new PedidoProdutoItem()
                {

                    Id = Guid.NewGuid().ToString(),
                    Produto = new Produto()
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Preco = produto.Preco
                    },

                    Quantidade = 0

                });
            }
            pedido.Id = Guid.NewGuid().ToString();//Criar um pedido com Id Novo
            return pedido;

        }

        public List<Pedido> ObterPedidosEmProducao()
        {
            return pedidoRepository.ObterPedidosEmProducao();
        }

        public List<Pedido> ObterPedidosEmTransporte()
        {
            return pedidoRepository.ObterPedidosEmTransporte();
        }

       
        public List<Pedido> ObterPedidosProduzidos()
        {
            return pedidoRepository.ObterPedidosProduzidos();
        }

        public List<Pedido> ObterPedidosSolicitados()
        {
            return pedidoRepository.ObterPedidosSolicitados();
        }

        public List<Pedido> ObterPedidos()
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ObterPedidosEntregues()
        {
            return pedidoRepository.ObterPedidosEntregues();
        }
    }
}

