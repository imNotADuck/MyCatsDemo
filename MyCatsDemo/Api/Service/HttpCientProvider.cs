using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MyCatsDemo.Api.Service
{
    public interface IHttpClientProvider
    {
        HttpClient GetHttpClient(string key);
        void SetHttpClient(string key, HttpClient httpClient);
    }

    public class HttpClientProvider : IHttpClientProvider
    {
        private readonly Dictionary<string, HttpClient> _pool = new Dictionary<string, HttpClient>();

        public HttpClient GetHttpClient(string key)
        {
            lock (_pool)
            {
                return _pool[key];
            }
        }

        public void SetHttpClient(string key, HttpClient httpClient)
        {
            lock (_pool)
            {
                _pool[key] = httpClient;
            }
        }
    }
}
