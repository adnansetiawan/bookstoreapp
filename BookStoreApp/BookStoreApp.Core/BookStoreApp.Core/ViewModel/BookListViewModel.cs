using Acr.UserDialogs;
using BookStoreApp.Service.Contract;
using BookStoreApp.Service.Response;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
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
        private List<BookResponse> _books;
        public List<BookResponse> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                RaisePropertyChanged(() => Books);
            }
        }
        public BookListViewModel(IService service)
        {
            _service = service;
            //Books = new List<BookResponse>();


        }

        public void Init()
        {
            LoadBooks();
        }

        private async void LoadBooks()
        {
            var response = await _service.GetAllBook();
            if (response.Success)
            {
                Books = response.Data;

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
