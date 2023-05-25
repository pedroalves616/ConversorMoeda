using ConversorMoeda.model;
using ConversorMoeda.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMoeda.factory
{
    public class ConversaoFactory
    {
        public static Conversao? Create(Moeda origem, Moeda destino, double valor)
        {
            var convertion = ServicoConversao.Convert(origem.Simbolo, destino.Simbolo, valor);

            return convertion != null && convertion.Info != null ? new Conversao(origem, destino, valor, convertion.Result, convertion.Info.Rate) : null;
        }
    }
}
