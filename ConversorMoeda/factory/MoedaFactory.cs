using ConsultorioOdontologico.session;
using ConversorMoeda.model;
using ConversorMoeda.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMoeda.factory
{
    public class MoedaFactory
    {
        public static Moeda? Create(string simbolo) =>
            SessionManager.GetSession().Moedas.Get(simbolo);

        public static MoedaList GetAll()
        {
            var moedas = new MoedaList();

            ServicoConversao.GetAllCurrencies()?.ForEach(c => moedas.Add(new Moeda(c.Code, c.Description)));

            return moedas;
        }
    }
}
