using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCore
{
    public static class ObjectExtensions
    {
        public static int ToInt(this object value)
        {
            if (value is Enum)
                return (int)value;
            else
            {
                int.TryParse(value.Str(), out int result);
                return result;
            }
        }

        public static long ToLong(this object value)
        {
            return Convert.ToInt64(value);
        }

        public static T To<T>(this object obj)
        {
            return (T)obj;
        }

        public static string GetName(this object obj)
        {
            return obj.ToString();
        }

        public static decimal ToDecimal(this object value, string numberDecimalSeparator = "")
        {
            if (value == null || value.ToString().ToLower() == "null")
                return 0;

            if (string.IsNullOrEmpty(numberDecimalSeparator))
                return Convert.ToDecimal(value.ToString());
            else
            {
                value = value.ToString().Replace(".", numberDecimalSeparator)
                                        .Replace(",", numberDecimalSeparator);

                return Convert.ToDecimal(value);
            }
        }

        public static string Serialize(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static bool IsNotNull(this object obj)
        {
            return !IsNull(obj);
        }

        public static bool IsNull(this object obj)
        {
            return (obj == null);
        }

        public static bool IsFalse(this bool obj)
        {
            return (obj == false);
        }

        public static bool IsSuccess(this bool obj)
        {
            return (obj == true);
        }

        public static bool IsNullOrEmpty(this ICollection obj)
        {
            return IsNull(obj) || obj.Count == 0;
        }

        public static bool IsListNotNull(this ICollection obj)
        {
            return !IsNull(obj) && obj.Count > 0;
        }
        
        public static bool IsListNull(this ICollection obj)
        {
            return IsNull(obj) || obj.Count == 0;
        }

        public static string JoinStr(this ICollection<string> obj)
        {
            return string.Join("", obj);
        }       

        public static string Str(this object value)
        {
            if (value == null)
                return string.Empty;

            return value.ToString();
        }

        public static bool In(this decimal value, IEnumerable<decimal> source)
        {
            return source.Contains(value);
        }

        public static bool In(this string value, IEnumerable<string> source)
        {
            return source.Contains(value);
        }

        public static bool NotIn(this decimal value, IEnumerable<decimal> source)
        {
            return !value.In(source);
        }

        public static bool NotIn(this string value, IEnumerable<string> source)
        {
            return !value.In(source);
        }

        public static bool In(this int value, IEnumerable<int> source)
        {
            return source.Contains(value);
        }

        public static bool NotIn(this int value, IEnumerable<int> source)
        {
            return !value.In(source);
        }
        public static string BiteArrayToStr(this byte[] obj)
        {
            return Encoding.ASCII.GetString(obj);
        }
    }
}