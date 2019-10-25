using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeExpress.Domain;
using MeExpress.Repository;
namespace Repository.UnitTestProject
{
    [TestClass]
    public class ClienteUnitTest
    {
        [TestMethod]
        public void ClienteNovoTeste()
        {

            var clienteRep = new ClienteRepository();


            var cli = new Cliente();
            cli.Id = Guid.NewGuid().ToString();
            cli.Nome = "Maria Exemplo da Silva";
            cli.CPF = "213.234.444-22";
            cli.Email = "exemplo@teste.com.br";
            cli.Empresa = "Empresa Acme";
            cli.Endereco = "Avenida Etc e Tal";
            cli.Numero = "234";
            cli.Complemento = "Sala 23";
            cli.Bairro = "Vila Exemplo";

            clienteRep.Incluir(cli);

            var clienteGravado = clienteRep.ObterPorCpf("213.234.444-22");

            if (clienteGravado != null)
            {

                Console.WriteLine(clienteGravado.Id);
                Console.WriteLine(clienteGravado.Nome);
                Console.WriteLine(clienteGravado.CPF);
                Console.WriteLine(clienteGravado.Email);
                Console.WriteLine(clienteGravado.Empresa);
                Console.WriteLine(clienteGravado.Endereco);
                Console.WriteLine(clienteGravado.Numero);
                Console.WriteLine(clienteGravado.Complemento);
                Console.WriteLine(clienteGravado.Bairro);
                Console.WriteLine(clienteGravado.Cidade);
                Console.WriteLine(clienteGravado.Estado);

            }

            Assert.IsNotNull(clienteGravado, "Deveria ter localizado o cliente com este CPF");

        }


    }
}
