using BookStoreApp.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Service.Contract
{
    public interface IService
    {
        Task<GetAllBookResponse> GetAllBook();
        Task<GetAllCategoryResponse> GetAllCategory();
        Task<CreateNewBookResponse> CreateNewBook(BookRequest newBook);
        
    }


}
