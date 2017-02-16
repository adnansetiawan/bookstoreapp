using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Constans
{
    public class UrlEndPoint
    {
        public static readonly string GetAllBook = @"api/book/getall";
        public static readonly string GetAllCategory = @"api/category/getall";
        public static readonly string CreateNewBook = @"api/book/create";
    }
}
