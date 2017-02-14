using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Service.Response
{
    public abstract class BaseApiResponse
    {
        public bool Success { get; set; }
        public string Messages { get; set; }

    }
}
