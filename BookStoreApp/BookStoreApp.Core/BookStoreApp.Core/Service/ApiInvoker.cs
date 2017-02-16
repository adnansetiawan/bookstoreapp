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
        public Task<T> InvokeApi<T>(string url) where T : BaseApiResponse
        {
            return new ResponseReader<T>().InvokeApi(url);
        }
    }
}
