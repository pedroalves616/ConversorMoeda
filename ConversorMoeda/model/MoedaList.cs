using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMoeda.model
{
    public class MoedaList
    {
        private readonly List<Moeda> moedas = new();

        public void Add(Moeda moeda) => moedas.Add(moeda);

        public Moeda? Get(string simbolo) => moedas.Find(m => m.Simbolo == simbolo);
    }
}
