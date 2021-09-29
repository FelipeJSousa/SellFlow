using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace SellFlow.Model
{
    public class RetornoModel<T> where T : class
    {
        public bool status { get; set; }
        public T dados { get; set; }
        public string erro { get; set; }
        public string mensagem { get; set; }
    }
}
