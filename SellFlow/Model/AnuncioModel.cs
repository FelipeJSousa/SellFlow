﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellFlow.Model
{
    public class AnuncioModel
    {
        public long id { get; set; }
        public string nome { get; set; }
        public int qtdeDisponivel { get; set; } = 0;
        public string descricao { get; set; }
        public DateTime dataCriacao { get; set; } = DateTime.Now;
        public DateTime dataEncerramento { get; set; }
        public bool ativo { get; set; }
        public long? produto { get; set; }
        public long? anuncioSituacao { get; set; }
        public double valor { get; set; }

        public ProdutoModel produtoObj { get; set; }
        public AnuncioSituacaoModel anuncioSituacaoObj { get; set; }

        public string percentPromocao => $"{(valor / produtoObj.valor) * 100}%";
    }
}
