using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMoeda.model
{
    public class Conversao
    {
        public Moeda Origem { get; private set; }

        public Moeda Destino { get; private set; }

        public double ValorOrigem { get; private set; }

        public double ValorDestino { get; private set; }

        public double Taxa { get; private set; }

        public Conversao(Moeda origem, Moeda destino, double valorOrigem, double valorDestino, double taxa)
        {
            Origem = origem;
            Destino = destino;
            ValorOrigem = valorOrigem;
            ValorDestino = valorDestino;
            Taxa = taxa;
        }
    }
}
