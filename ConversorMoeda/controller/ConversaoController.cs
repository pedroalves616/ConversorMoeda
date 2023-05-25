using ConsultorioOdontologico.session;
using ConsultorioOdontologico.util;
using ConversorMoeda.factory;
using ConversorMoeda.model;
using ConversorMoeda.presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMoeda.controller
{
    public class ConversaoController
    {
        public void Start()
        {
            string simboloOrigem, simboloDestino;
            Moeda? moedaOrigem, moedaDestino;

            var view = new ConversaoView();

            for (; ;)
            {
                simboloOrigem = view.ReadOrigem();

                if (simboloOrigem.Length == 0)
                    break;

                moedaOrigem = MoedaFactory.Create(simboloOrigem);

                if (moedaOrigem == null)
                {
                    view.ShowStatus(OperationStatus.INVALID_CURRENCY);
                    continue;
                }

                do
                {
                    simboloDestino = view.ReadDestino();
                    moedaDestino = MoedaFactory.Create(simboloDestino);

                    if (moedaDestino == null)
                        view.ShowStatus(OperationStatus.INVALID_CURRENCY);

                } while (moedaDestino == null);

                if (moedaOrigem.Equals(moedaDestino))
                {
                    view.ShowStatus(OperationStatus.INVALID_CONVERTION);
                    continue;
                }

                var valor = view.ReadValor();


                var conversao = ConversaoFactory.Create(moedaOrigem, moedaDestino, valor);

                if (conversao != null)
                    view.ShowConversao(conversao);
                else
                    view.ShowStatus(OperationStatus.CONVERTION_ERROR);
            }

            
        }
    }
}
