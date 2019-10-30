using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeExpress.Domain;

namespace MeExpress.ApplicationServices
{
    public class ClienteAppService : IClienteAppService
    {
        //Chama o repositorio
        private IClienteRepository clienteRepository;

        //Construtor vai receber uma instancia do cliente repository
        public ClienteAppService(IClienteRepository clienteRepositoryInstance)
        {
            this.clienteRepository = clienteRepositoryInstance;
        }



        public void Alterar(Cliente cliente)
        {
            clienteRepository.Alterar(cliente);
        }

        public void Incluir(Cliente cliente)
        {
            clienteRepository.Incluir(cliente);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return clienteRepository.ObterPorCpf(cpf);
        }

        public Cliente ObterPorId(string id)
        {
            return clienteRepository.ObterPorId(id);
        }
    }
}
