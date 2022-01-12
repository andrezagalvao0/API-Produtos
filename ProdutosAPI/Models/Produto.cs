using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosAPI.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }

        public int quantidade { get; set; }
        public double valor { get; set; }
    }
}
