using BookStoreApp.Service.Contract;
using BookStoreApp.Service.Response;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Service
{
   
    public class ResponseReader<T>  where T : BaseApiResponse
    {
        protected const string BASE_URL = "http://192.168.60.133:8181/";

        protected async Task<T> DeserializeResponse(HttpResponseMessage httpResponseMessage)
        {
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<T>(content);
            return response;
        }

        protected HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(BASE_URL)
            };


            httpClient.DefaultRequestHeaders.Accept.Clear();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        private HttpContent CreateHttpContent(HttpClient httpClient, object data)
        {
            var jsonData = JsonConvert.SerializeObject(data);

            var httpContent = new StringContent(jsonData);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpContent;
        }

        public async Task<T> InvokeGetApi(string ApiGetUrl)
        {
            using (var httpClient = GetHttpClient())
            {
                HttpResponseMessage result = null;
                try
                {
                    result = httpClient.GetAsync(ApiGetUrl).Result;
                    
                }
                catch (Exception ex)
                {
                    var errorInstance = (T)Activator.CreateInstance(typeof(T));
                    errorInstance.Messages = ex.Message;
                    errorInstance.Success = false;
                    return errorInstance;
                }
                return await DeserializeResponse(result);
            }
        }
        public async Task<T> InvokePostApi(string ApiGetUrl, object data)
        {
            using (var httpClient = GetHttpClient())
            {
                HttpResponseMessage result = null;
                try
                {
                    var httpContent = CreateHttpContent(httpClient, data);
                    result = httpClient.PostAsync(ApiGetUrl, httpContent).Result;

                }
                catch (Exception ex)
                {
                    var errorInstance = (T)Activator.CreateInstance(typeof(T));
                    errorInstance.Messages = ex.Message;
                    errorInstance.Success = false;
                    return errorInstance;
                }
                return await DeserializeResponse(result);
            }
        }

      
    }
    
}
