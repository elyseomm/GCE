using Newtonsoft.Json.Linq;
using System;
using System.Configuration;

namespace WebCore
{
    public class Utils
    {
        public static string Get(string key) => ConfigurationManager.AppSettings.Get(key).ToString();

        public static JObject ToJObj(string values)
        {
            try
            {
                JObject jObj = JObject.Parse(values);
                if (jObj.IsNotNull())
                    return jObj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static JArray ToJArray(string values)
        {
            try
            {
                var jObj = JArray.Parse(values);
                if (jObj.IsNotNull())
                    return jObj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static decimal? FrmDec(string value)
        {
            if (value.IsSet())
                return value.Replace("R$ ", "").Replace(",", "").ToDec();
            return null;
        }

    }
}
