using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Request
{
    public abstract class BaseRequest : Http
    {
        private HttpClient client { get; set; }
        public List<Header> Headers { get; set; }

        public async virtual Task<HttpResponseMessage> doRequest(methods method, string endPoint, StringContent body = null)
        {
            client = new HttpClient();
            AddHeaders();

            string uri = $"{baseUrl}/{endPoint}";
            switch (method)
            {
                case methods.GET:
                    return await client.GetAsync(uri);
                case methods.POST:
                    return await client.PostAsync(uri, body);
                case methods.PUT:
                    return await client.PutAsync(uri, body);
                case methods.DELETE:
                    return await client.DeleteAsync(uri);
                default:
                    return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            }
        }

        private void AddHeaders()
        {
            if(Headers != null)
            {
                foreach (Header header in Headers)
                {
                    client.DefaultRequestHeaders.Add(header.chave, header.valor);
                }
            }
        }
    }
}
