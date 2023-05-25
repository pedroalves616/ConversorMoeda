using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.util
{
    public interface IOutput
    {
        void WriteLine(string value);

        void Write(string value);
    }
}
