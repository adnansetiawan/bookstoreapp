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
using BookStoreApp.Constans;

namespace BookStoreApp.Service
{
    public class WebApiService : IService
    {
        private IApiInvoker _apiInvoker;
        public WebApiService(IApiInvoker apiInvoker)
        {
            _apiInvoker = apiInvoker;
        }

        public void CreateNewBook(BookRequest newBook)
        {
            _apiInvoker.InvokePostApi<CreateNewBookResponse>(UrlEndPoint.CreateNewBook, newBook);
        }

        public async Task<GetAllBookResponse> GetAllBook()
        {
            return await _apiInvoker.InvokeGetApi<GetAllBookResponse>(UrlEndPoint.GetAllBook);
        }
        public async Task<GetAllCategoryResponse> GetAllCategory()
        {
            return await _apiInvoker.InvokeGetApi<GetAllCategoryResponse>(UrlEndPoint.GetAllCategory);
        }
        
        
    }
}
