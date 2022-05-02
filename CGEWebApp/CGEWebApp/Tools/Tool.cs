using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using WebCore;
using WebCore.Enums;
using WebCore.Extensions;

namespace CGEWebApp.Tools
{
    public static class Tool
    {
        public static string Serialize(object obj, bool isIndented = true)
        {
            return JsonConvert.SerializeObject(obj, ((isIndented)
                                                     ? Formatting.Indented
                                                     : Formatting.None));
        }

        public static List<SelectListItem> GenSelYesNo(bool yesFirst = false)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(yesFirst ? new SelectListItem() { Text = "Yes", Value = "Y" } : new SelectListItem() { Text = "No", Value = "N" });
            list.Add(yesFirst ? new SelectListItem() { Text = "No", Value = "N" } : new SelectListItem() { Text = "Yes", Value = "Y" });
            return list;
        }

        public static string GetEnumText(Type value, decimal idx)
        {
            return Enum.Parse(value, idx.Str()).Str().Replace("_", " ");
        }

        public static List<SelectListItem> GenSelList(Type value, bool withDescript = false)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                var fields = value.GetFields();
                var ditems = new SortedDictionary<int, string>();
                for (int i = 0; i < fields.Length; i++)
                {
                    var item = fields[i];
                    if (!item.Name.Contains("value__"))
                    {
                        var desc = (DescriptionAttribute)fields[i].GetCustomAttributes().FirstOrDefault();
                        var text = item.Name + (withDescript && desc.IsNotNull() ? $" - {desc.Description}" : "");
                        var key = Enum.Parse(value, item.Name).ToInt();
                        ditems.Add(key, text);
                    }
                }   

                list = ditems.Select(x => new SelectListItem
                {
                    Text = x.Value.Replace("_", " "),
                    Value = x.Key.Str(),
                }).ToList();

                return list;
            }
            catch (Exception)
            {
            }
            return null;
        }

        public static List<SelectListItem> GenSelList(Type value, int? removefromval = null)
        {
            try
            {
                List<SelectListItem> list = GenSelList(value, true);
                if (removefromval.IsNotNull())
                {
                    int i = 0;
                    while (i < list.Count)
                    {
                        if (list[i].Value.AsInt() >= removefromval)
                            list.RemoveAt(i);
                        else i++;
                    }
                }
                return list;
            }
            catch (Exception)
            {
            }
            return null;
        }


        public static List<SelectListItem> GetListTipoEmpresas(int? hidefrom = null)
        {
            if (hidefrom.IsNotNull())
            {
                return Tool.GenSelList(typeof(EnumTipoEmpresa), hidefrom);
            }
            else return Tool.GenSelList(typeof(EnumTipoEmpresa),true);
        }

        public static List<SelectListItem> GetListPorteEmpresas(int? hidefrom = null)
        {
            if (hidefrom.IsNotNull())
            {
                return Tool.GenSelList(typeof(EnumPorteEmpresa), hidefrom);
            }
            else return Tool.GenSelList(typeof(EnumPorteEmpresa),true);
        }

        public static List<SelectListItem> GetListTipoCapital(int? hidefrom = null)
        {
            if (hidefrom.IsNotNull())
            {
                return Tool.GenSelList(typeof(EnumTipoCapital), hidefrom);
            }
            else return Tool.GenSelList(typeof(EnumTipoCapital), true);
        }

    }
}