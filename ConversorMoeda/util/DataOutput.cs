using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.util
{
    public class DataOutput
    {
        private static IOutput? device;

        public static IOutput Device { 
            set => device = value;  
        }

        public static void Write(string str) => device?.Write(str);
        public static void WriteLine(string str) => device?.WriteLine(str);
    }
}
