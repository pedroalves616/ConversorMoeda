using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.util
{
    public class DataInput
    {
        private static IInput device;

        public static IInput Device { set { device = value;  } }

        public static string ReadNonEmptyString(string label, string errorMsg)
        {
            for ( ; ; )
            {
                DataOutput.Write(label);
                var data = device.ReadLine().Trim();

                if (data.Length == 0)
                    DataOutput.WriteLine(errorMsg);
                else
                    return data;
            }
        }

        public static string ReadString(string label, string errorMsg, int minLength, int maxLength)
        {
            for (; ; )
            {
                DataOutput.Write(label);
                var data = device.ReadLine().Trim();

                if (data.Length < minLength || data.Length > maxLength)
                    DataOutput.WriteLine(errorMsg);
                else
                    return data;
            }
        }

        public static long ReadInteger(string label, string errorMsg)
        {
            for ( ; ; )
            {
                DataOutput.Write(label);
                var data = device.ReadLine().Trim();

                try
                {
                    return long.Parse(data);
                }
                catch (Exception)
                {
                    DataOutput.WriteLine(errorMsg);
                }
            }
        }

        public static long ReadRangeInteger(string label, string errorMsg, long min, long max)
        {
            for (; ; )
            {
                var number = ReadInteger(label, errorMsg);

                if (number < min || number > max)
                    DataOutput.WriteLine(errorMsg);
                else
                    return number;
            }
        }

        public static double ReadNumber(string label, string errorMsg)
        {
            for (; ; )
            {
                DataOutput.Write(label);
                var data = device.ReadLine().Trim();

                try
                {
                    return double.Parse(data);
                }
                catch (Exception)
                {
                    DataOutput.WriteLine(errorMsg);
                }
            }
        }

        public static double ReadRangeNumber(string label, string errorMsg, double min, double max)
        {
            for (; ; )
            {
                var number = ReadNumber(label, errorMsg);

                if (number < min || number > max)
                    DataOutput.WriteLine(errorMsg);
                else
                    return number;
            }
        }

        public static DateTime ReadDate(string label, string errorMsg, string dataFormat = "dd/MM/yyyy")
        {
            for ( ; ; )
            {
                DataOutput.Write(label);
                var data = device.ReadLine().Trim();

                try
                {
                    return DateTime.ParseExact(data, dataFormat, System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    DataOutput.WriteLine(errorMsg);
                }
            }
        }

        public static int ReadTime(string label, string errorMsg)
        {
            for (; ; )
            {
                DataOutput.Write(label);
                var data = device.ReadLine().Trim();

                var regex = new Regex(@"^([0-1][0-9]|2[0-3])[0-5][0-9]$");

                if (regex.IsMatch(data))
                    return int.Parse(data);
                else
                    DataOutput.WriteLine(errorMsg);
            }
        }

        public static char ReadChar(string label, string errorMsg, bool capitalize)
        {
            for (; ; )
            {
                DataOutput.Write(label);
                var data = device.ReadLine().Trim();

                if (data.Length == 1)
                    return capitalize ? data.ToUpper()[0] : data[0];
                else
                    DataOutput.WriteLine(errorMsg);
            }
        }

        public static char ReadChar(string label, string errorMsg, bool capitalize, string allowedChars)
        {
            for (; ; )
            {
                var data = ReadChar(label, errorMsg, capitalize);

                if (allowedChars.IndexOf(data) != -1)
                    return data;
                else
                    DataOutput.WriteLine(errorMsg);
            }
        }
    }
}
