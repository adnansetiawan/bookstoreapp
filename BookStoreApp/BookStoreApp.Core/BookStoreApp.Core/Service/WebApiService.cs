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
        private IApiInvoker _apiInvoker;
        public WebApiService(IApiInvoker apiInvoker)
        {
            _apiInvoker = apiInvoker;
        }
       
        //public void CreateNewBook(BookRequest newBook)
        //{
        //    var client = GetHttpClient();
        //    HttpResponseMessage result = null;
        //    try
        //    {
        //        result = client.PostAsync(@"api/Book/Create", newBook).Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new GetAllBookResponse { Success = false, Messages = ex.Message };
        //    }
        //    var content = result.Content.ReadAsStringAsync().Result;

        //}

        public async Task<GetAllBookResponse> GetAllBook()
        {
            return await _apiInvoker.InvokeApi<GetAllBookResponse>(@"api/book/getall");
        }
        public async Task<GetAllCategoryResponse> GetAllCategory()
        {
            return await _apiInvoker.InvokeApi<GetAllCategoryResponse>(@"api/category/getall");
        }
        
        
    }
}
