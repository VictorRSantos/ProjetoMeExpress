using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Domain
{
    public interface ICliente
    {

        Cliente ObterPorCpf(string cpf);

        void Incluir(Cliente cliente);

        void Alterar(Cliente cliente);
        

    }
}
