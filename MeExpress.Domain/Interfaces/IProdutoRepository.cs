﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Domain
{
    public interface IProdutoRepository
    {
        List<Produto> ObterList();

    }
}
