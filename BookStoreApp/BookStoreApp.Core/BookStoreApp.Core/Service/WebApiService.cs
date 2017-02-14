using BookStoreApp.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreApp.Service.Response;
using Newtonsoft.Json;
using ModernHttpClient;
using System.Net.Http.Headers;
using System.Net.Http;


namespace BookStoreApp.Service
{
    public class WebApiService : IService
    {
        protected const string BASE_URL = "http://192.168.60.133:8181/";

        public async Task<GetAllBookResponse> GetAllBook()
        {
            var client = GetHttpClient();
            
                HttpResponseMessage result = null;
                try
                {
                    result =  client.GetAsync(@"api/book/getall").Result;
                }
                catch (Exception ex)
                {
                    return new GetAllBookResponse { Success = false, Messages = ex.Message };
                }
                var content = await result.Content.ReadAsStringAsync();
                var bookResponse = JsonConvert.DeserializeObject<GetAllBookResponse>(content);
                return bookResponse;
            
        }
        public async Task<GetAllCategoryResponse> GetAllCategory()
        {
            var client = GetHttpClient();

            HttpResponseMessage result = null;
            try
            {
                result = client.GetAsync(@"api/category/getall").Result;
            }
            catch (Exception ex)
            {
                return new GetAllCategoryResponse { Success = false, Messages = ex.Message };
            }
            var content = await result.Content.ReadAsStringAsync();
            var categoryResponse = JsonConvert.DeserializeObject<GetAllCategoryResponse>(content);
            return categoryResponse;

        }
        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(BASE_URL)
            };


            httpClient.DefaultRequestHeaders.Accept.Clear();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }


    }
}
