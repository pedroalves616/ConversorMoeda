using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMoeda.model
{
    public class Moeda
    {
        public string Simbolo { private set; get; }

        public string Descricao { private set; get; }

        public Moeda(string simbolo, string descricao)
        {
            Simbolo = simbolo;
            Descricao = descricao;
        }

        public override bool Equals(object? obj)
        {
            return obj is Moeda moeda &&
                   Simbolo == moeda.Simbolo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Simbolo);
        }
    }
}
