using BookStoreApp.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Service.Contract
{
    public interface IApiInvoker
    {
        Task<T> InvokeGetApi<T>(string url) where T : BaseApiResponse;
        Task<T> InvokePostApi<T>(string url, object data) where T : BaseApiResponse;
    }
}
