using ConsultorioOdontologico.util;
using ConversorMoeda.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMoeda.presentation
{
    public class ConversaoView
    {
        public string ReadOrigem() =>
            DataInput.ReadString("Origem: ", "ERRO: símbolo inválido", 0, 3).ToUpper();

        public string ReadDestino() =>
           DataInput.ReadString("Destino: ", "ERRO: símbolo inválido", 3, 3).ToUpper();

        public double ReadValor() => 
            DataInput.ReadRangeNumber("Valor: ", "ERRO: valor inválido", 0.01, double.MaxValue);

        public void ShowConversao(Conversao conversao)
        {
            DataOutput.WriteLine($"\n{conversao.Origem.Simbolo} {conversao.ValorOrigem, 0:N2} => {conversao.Destino.Simbolo} {conversao.ValorDestino, 0:N2}\nTaxa: {conversao.Taxa}\n");
        }
        public void ShowStatus(OperationStatus status)
        {
            switch (status)
            {
                case OperationStatus.INVALID_CURRENCY: DataOutput.WriteLine("Moeda inválida"); break;
                case OperationStatus.INVALID_CONVERTION: DataOutput.WriteLine("Conversão inválida"); break;
                case OperationStatus.CONVERTION_ERROR: DataOutput.WriteLine("Erro na conversão"); break;
            }
        }
    }
}
