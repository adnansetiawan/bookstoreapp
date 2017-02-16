using BookStoreApp.Service.Contract;
using BookStoreApp.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Service
{
    public class ApiInvoker : IApiInvoker
    {
        
        public Task<T> InvokeGetApi<T>(string url) where T : BaseApiResponse
        {
            return new ResponseReader<T>().InvokeGetApi(url);
        }

        public Task<T> InvokePostApi<T>(string url, object data) where T : BaseApiResponse
        {
            return new ResponseReader<T>().InvokePostApi(url, data);
        }
    }
}
