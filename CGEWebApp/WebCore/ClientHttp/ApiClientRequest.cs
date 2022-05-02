using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebCore.ClientHttp
{
    public class ApiClientRequest
    {        
        private string _urlApi = string.Empty;
        private string _pingRoute = string.Empty;
        private Dictionary<string, string> _headers { get; set; }
        private Dictionary<string, string> _values { get; set; }

        private const int TIMEOUT_MINUTES = 5;
        // * PING
        private string PING_SERVER = string.Empty;

        public Task<bool> OnLine => IsServerAlive();

        public ApiClientRequest()
        {
            this._urlApi = Utils.Get("ApiUrl").ToString();
            this._pingRoute = Utils.Get("Ping");

            // * Verifica se o servidor da API está ativo.
            if (!OnLine.Result)
                throw new Exception("O Servidor RestAPI(CGE.Api) está Off-Line!");

            //InitializeApiClientRequest(this._urlApi);
            InitializeApiClientRequest();
        }
               
        //private void InitializeApiClientRequest(string url)
        private void InitializeApiClientRequest()
        {
            //this._url = new UriBuilder(url).Uri;
            _headers = new Dictionary<string, string>();
            _values = new Dictionary<string, string>();            
        }

        private async Task<bool> IsServerAlive()
        {
            try
            {
                var ping = await DoGet(this._pingRoute);                
                if (ping.IsNotNull())
                    return ping.Contains("Pong!");
            }
            catch(Exception ex) 
            {
                var erro = ex.Message;
            }
            return false;
        }

        #region Headers

        public void AddHeader(string key, string value)
        {
            if (_headers.IsNotNull())
            {
                if (!_headers.ContainsKey(key))
                    _headers.Add(key, value);
            }
        }

        public string GetHeader(string key)
        {
            string val = string.Empty;
            if (_headers.IsNotNull())
                _headers.TryGetValue(key, out val);
            return val;
        }

        public void RemoveHeader(string key)
        {            
            if (_headers.IsNotNull())
            {
                if (_headers.ContainsKey(key))
                    _headers.Remove(key);
            }
        }
        
        #endregion

        #region Values

        public void AddValue(string key, string value)
        {
            if (_values.IsNotNull())
            {
                if (!_values.ContainsKey(key))
                    _values.Add(key, value);
            }
        }

        public string GetValue(string key)
        {
            string val = string.Empty;
            if (_values.IsNotNull())
                _values.TryGetValue(key, out val);
            return val;
        }

        public void RemoveValue(string key)
        {
            if (_values.IsNotNull())
            {
                if (_values.ContainsKey(key))
                    _values.Remove(key);
            }
        }
               

        #endregion

        #region HttpRequest

        public async Task<string> DoGet(string routeUrl)
        {
            try
            {
                //var content = new FormUrlEncodedContent(_values);
                
                if (routeUrl.IsNotNull())
                {
                    var strURL = string.Concat(_urlApi, "/", routeUrl);
                    using (var client = new HttpClient())
                        return client.GetStringAsync(strURL).Result;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return string.Empty;
        }
        public async Task<string> DoPost(string routeUrl)
        {
            try
            {
                if (routeUrl.IsNotNull())
                {
                    var strURL = string.Concat(_urlApi, "/", routeUrl);
                    var content = new FormUrlEncodedContent(_values);
                    using (var client = new HttpClient())
                    {
                        var resp = await client.PostAsync(strURL, content);
                        if (resp.IsSuccessStatusCode)
                        {
                            var strResp = await resp.Content.ReadAsStringAsync();
                            return strResp;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return string.Empty;
        }

        public async Task<string> DoPut(string routeUrl)
        {
            try
            {
                if (routeUrl.IsNotNull())
                {
                    var strURL = string.Concat(_urlApi, "/", routeUrl);

                    var content = new FormUrlEncodedContent(_values);
                    using (var client = new HttpClient())
                    {
                        var resp = await client.PutAsync(strURL, content);
                        if (resp.IsSuccessStatusCode)
                        {
                            var strResp = await resp.Content.ReadAsStringAsync();
                            return strResp;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return string.Empty;
        }
                
        public async Task<string> DoDelete(string routeUrl)
        {
            try
            {
                if (routeUrl.IsNotNull())
                {
                    var strURL = string.Concat(_urlApi, "/", routeUrl);
                    using (var client = new HttpClient())
                    {
                        var resp = await client.DeleteAsync(strURL);
                        if (resp.IsSuccessStatusCode)
                        {
                            var strResp = await resp.Content.ReadAsStringAsync();
                            return strResp;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return string.Empty;
        }


        //public async Task<string> DoGetAsync()
        //{
        //    try
        //    {                
        //        var strResp = await _request.GetStringAsync(_url);
        //        return strResp;
        //    }
        //    catch (Exception ex)
        //    {
        //        string erro = ex.Message;
        //    }
        //    return string.Empty;
        //}

        //public async Task<string> DoPostAsync()
        //{
        //    try
        //    {                
        //        var content = new FormUrlEncodedContent(_values);

        //        var resp = await _request.PostAsync(_url, content);
        //        if (resp.IsSuccessStatusCode)
        //        {
        //            var strResp = await resp.Content.ReadAsStringAsync();
        //            return strResp;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string erro = ex.Message;
        //    }
        //    return string.Empty;
        //}

        //public async Task<HttpResponseMessage> DoGetHttpResp()
        //{
        //    try
        //    {                
        //        var strResp = await _request.GetAsync(_url);
        //        return strResp;
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return null;
        //}

        //public async Task<HttpResponseMessage> DoPostHttpResp()
        //{
        //    try
        //    {                
        //        //var content = new FormUrlEncodedContent(_values);
        //        JObject parameters = JObject.FromObject(_values);
        //        var jContent = new StringContent(parameters.ToString(), Encoding.UTF8, "application/json");
        //        _request.Timeout = TimeSpan.FromMinutes(TIMEOUT_MINUTES);
        //        var response = await _request.PostAsync(_url, jContent);

        //        if (response.IsNotNull())
        //            return response;
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return null;
        //}

        #endregion
    }
}
