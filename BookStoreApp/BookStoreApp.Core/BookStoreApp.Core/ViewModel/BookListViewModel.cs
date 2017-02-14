using BookStoreApp.Service.Contract;
using BookStoreApp.Service.Response;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookStoreApp.ViewModel
{
    public class BookListViewModel : MvxViewModel
    {
        private IService _service;
        public ObservableCollection<BookResponse> Books { get; set; }
        public BookListViewModel(IService service)
        {
            _service = service;
            Books = new ObservableCollection<BookResponse>();
            LoadBooks();
        }

        private void LoadBooks()
        {
            var response = _service.GetAllBook().Result;
            if (response.Success)
            {
                foreach (var book in response.Data)
                {
                    Books.Add(book);
                }
            }
            
        }

        public ICommand Add
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<BookFormViewModel>());
            }
        }

    }
}
