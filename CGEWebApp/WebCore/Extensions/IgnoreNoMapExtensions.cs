using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Extensions
{
    public static class IgnoreNoMapExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreNoMap<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            foreach (var item in sourceType.GetProperties())
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[item.Name];
                NoMapAttribute attr = (NoMapAttribute)descriptor
                    .Attributes[typeof(NoMapAttribute)];
                try
                {
                    if (attr != null)
                    {
                        expression.ForSourceMember(item.Name, opt => opt.DoNotValidate());
                    }
                }
                catch (Exception ex)
                {
                    string erro = ex.Message;
                }
            }
            return expression;
        }
    }
}
