using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.util
{
    public class MyConsole : IInput, IOutput
    {
        public string ReadLine() => Console.ReadLine();

        public void WriteLine(string value) => Console.WriteLine(value);

        public void Write(string value) => Console.Write(value);
    }
}
