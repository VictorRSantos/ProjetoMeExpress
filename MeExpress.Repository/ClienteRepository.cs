using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeExpress.Domain;

namespace MeExpress.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private static List<Cliente> clientes = new List<Cliente>(); 

        public void Alterar(Cliente cliente)
        {

            var cli = clientes.Where(m => m.Id == cliente.Id).FirstOrDefault();
            if (cli == null) return;
            cli.Nome = cliente.Nome;
            cli.Email = cliente.Email;
            cli.CPF = cliente.CPF;
            cli.Bairro = cliente.Bairro;
            cli.Cidade = cliente.Cidade;
            cli.Complemento = cliente.Complemento;
            cli.Empresa = cliente.Empresa;
            cli.Endereco = cliente.Endereco;
            cli.Estado = cliente.Estado;
            cli.Numero = cliente.Numero;
        }

        public void Incluir(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            var cli = clientes.Where(m => m.CPF == cpf).FirstOrDefault();
            return cli;

        }
    }
}
