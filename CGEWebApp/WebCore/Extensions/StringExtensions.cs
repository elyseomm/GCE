using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Text;

namespace WebCore
{
    public static class StringExtensions
    {
        public static int ToInt(this string value)
        {
            if (value.IsEmpty())
                return 0;

            return Convert.ToInt32(value);
        }

        public static decimal ToDecimal(this string value)
        { 
            return Convert.ToDecimal(value);
        }

        public static decimal ToDec(this string value)
        {
            if (value.Contains("."))
                value = value.Replace(".",",");

            return Convert.ToDecimal(value, new CultureInfo("pt-BR"));
        }

        public static DateTime ToDateTime(this string value)
        {
            if (!value.IsSet())
                return default(DateTime);

            return DateTime.Parse(value);
        }

        public static DateTime ToDateTime_EnUS(this string value)
        {
            if (!value.IsSet())
                return default(DateTime);

            int dd, mm, yyyy;

            var datePart = value.Split('-');

            yyyy = datePart[0].ToInt();
            mm   = datePart[1].ToInt();
            dd   = datePart[2].ToInt();

            var dateTime = new DateTime(yyyy, mm, dd);

            return dateTime;
        }

        public static DateTime ToDateTimeAndHour(this string value, char sep = '-')
        {
            if (!value.IsSet())
                return default(DateTime);

            int dd, mm, yyyy;
            int hour = 0, min = 0, sec = 0;

            var valueSp = value.Split(' ');

            var datePart = valueSp[0].Split(sep);

            mm = datePart[1].ToInt();
            var idxDay = 2;     // Day US padrao
            var idxYear = 0;    // Year US padrao
            
            if (sep.Equals('/'))
            {
                idxDay = 0;
                idxYear = 2;
            }

            dd = datePart[idxDay].ToInt();
            yyyy = datePart[idxYear].ToInt();

            if (valueSp.Length > 1 && valueSp[1].IsNotNull())
            {
                var timePart = valueSp[1].Split(':');

                hour = timePart[0].ToInt();
                min = timePart.Length > 1 ? timePart[1].ToInt() : 0;
            }
            var dateTime = new DateTime(yyyy, mm, dd, hour, min, sec);

            return dateTime;
        }

        public static DateTime ToDateTimeAndHour_EnUS(this string value)
        {
            return ToDateTimeAndHour(value);
        }

        public static DateTime ToDateTimeAndHour_PtBR(this string value)
        {
            return ToDateTimeAndHour(value, '/');
        }

        public static bool IsSet(this string value)
        {
            if (value == null)
                return false;

            if (value == "null")
                return false;

            return !(string.IsNullOrEmpty(value.Trim()));
        }

        public static bool IsEmpty(this string value)
        {
            return !value.IsSet();
        }

        public static string Str(this object value)
        {
            if (value == null)
                return string.Empty;

            return value.ToString();
        }

        public static string _F(this string value, params object[] args)
        {
            return string.Format(value, args);
        }


        public static string[] SplitNoEmpty(this string value, char c)
        {
            return value.Split(new char[] { c }, StringSplitOptions.RemoveEmptyEntries );
        }

        public static byte[] ToByteArray(this string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }

        public static string ToBase64(this string value)
        {
            byte[] byt = ToByteArray(value);
            return Convert.ToBase64String(byt);
        }

        public static string FromBase64(this string value)
        {
            string base64Encoded = value;
            string base64Decoded;
            byte[] data = Convert.FromBase64String(base64Encoded);
            base64Decoded = ASCIIEncoding.ASCII.GetString(data);

            return base64Decoded;
        }

        public static string ZeroLeft(this string value, int size)
        {
            return value.PadLeft(size,'0');
        }

             

        public static T Deserialize<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }        

    }
}