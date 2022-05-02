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

        public static IEnumerable<string> GetDescriptions<T>()
        {
            var attributes = typeof(T).GetMembers()
                .SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>())
                .ToList();

            return attributes.Select(x => x.Description);
        }

        public static string GetDescriptionVal<T>(this T enumValue)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }

        public static T ToEnum<T>(this int value)
        {
            return (T)Enum.Parse(typeof(T), value.ToString(), true);
        }
                

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static int AsInt(this Enum value)
        {
            return (int)Enum.Parse(value.GetType(), value.ToString());
        }

        public static string StrValue(this Enum value)
        {
            return value.AsInt().ToString();
        }
    }
}
