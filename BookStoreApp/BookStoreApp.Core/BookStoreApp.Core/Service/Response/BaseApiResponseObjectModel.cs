using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Service.Response
{
    public abstract class BaseApiResponseObjectModel<T> : BaseApiResponse
    {
        public T Data { get; set; }
    }
}
