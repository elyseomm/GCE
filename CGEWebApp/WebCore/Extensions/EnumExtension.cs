using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum @enum)
        {
            return @enum
            ?.GetType()
            .GetMember(@enum.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description;
        }

        public static T ToEnum<T>(this int value)
        {
            return (T)Enum.Parse(typeof(T), value.ToString(), true);
        }

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
