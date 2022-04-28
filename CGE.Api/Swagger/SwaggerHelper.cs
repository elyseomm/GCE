using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
using CGE.Core.Paging;

namespace CGE.Api.Swagger
{
    internal static class SwaggerHelper
    {
        internal static void ConfigurarSwagger(SwaggerGenOptions c)
        {
            c.SwaggerDoc("v1",
                         new OpenApiInfo { Title = "Gestão de Compras do Estado API", Version = "v1" });

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
            var commentsFile = Path.Combine(baseDirectory, commentsFileName);

            c.IncludeXmlComments(commentsFile);


            c.CustomSchemaIds(t =>
            {
                /*if (t.Namespace == typeof(EntityBase).Namespace)
                    return $"{t.ToString()}$ENTITY";

                if (TipoIsPagedResult(t))
                {
                    return GetTypeNamePagedResult(t);
                }

                if (t.Name == typeof(ValueTuple<,>).Name)
                {
                    var tipo = (t.GenericTypeArguments[0].Name == nameof(MessageWrapper)) ? t.GenericTypeArguments[1] : t.GenericTypeArguments[0];
                    var nameTp = TipoIsPagedResult(tipo) ? GetTypeNamePagedResult(tipo) : tipo.Name.Replace("Dto", string.Empty);

                    var nameMs = (t.GenericTypeArguments[0].Name == nameof(MessageWrapper)) ? t.GenericTypeArguments[0].Name : t.GenericTypeArguments[1].Name;

                    return $"ValueTuple<{nameTp},{nameMs}>";
                }

                return t
                .ToString()
                .Replace($"{t.FullName}.", string.Empty)
                .Replace("Dto", string.Empty);*/

                return t.FullName;
            });
        }

        private static bool TipoIsPagedResult(Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(PagedResult<>);
        }

        private static string GetTypeNamePagedResult(Type t)
        {
            var namePR = typeof(PagedResult<>).Name.Substring(0, typeof(PagedResult<>).Name.Length - 2);
            var nameType = t.GenericTypeArguments[0].Name.Replace("Dto", string.Empty);
            return $"{namePR}<{nameType}>";
        }
    }
}
