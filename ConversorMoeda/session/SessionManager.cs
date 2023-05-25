using ConversorMoeda.factory;
using ConversorMoeda.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.session
{
    internal class SessionManager
    {
        private static SessionManager? session = null;

        public MoedaList Moedas { get; private set; }

        private SessionManager() => Moedas = MoedaFactory.GetAll();

        public static SessionManager GetSession()
        {
            session ??= new();

            return session;
        }
    }
}
