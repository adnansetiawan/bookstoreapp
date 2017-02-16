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
        Task<T> InvokeApi<T>(string url) where T : BaseApiResponse;
    }
}
