﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellFlow.Model
{
    public class ProdutoModel
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string imagemDestaque { get; set; }
        public bool ativo { get; set; }
        private int _curtidas { get; set; } = 0;
        public int curtidas { get => _curtidas; }

        public long Categoria { get; set; }
        public long usuarioVendedor { get; set; }
        public void Curtir() => _curtidas++;
    }
}
