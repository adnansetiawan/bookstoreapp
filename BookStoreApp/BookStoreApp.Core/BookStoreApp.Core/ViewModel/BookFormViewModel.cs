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
    public class BookFormViewModel : MvxViewModel
    {
        private IService _service;
        public ObservableCollection<CategoryResponse> Categories { get; set; }
        public BookFormViewModel(IService service)
        {
            _service = service;
            Categories = new ObservableCollection<CategoryResponse>();
            LoadCategories();
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged(() => Price);
            }
        }
        private void LoadCategories()
        {
            var response = _service.GetAllCategory().Result;
            if (response.Success)
            {
                foreach (var book in response.Data)
                {
                    Categories.Add(book);
                }
            }

        }

        public ICommand Reset
        {
            get
            {
                return new MvxCommand(() => Clear());
            }
        }

        private void Clear()
        {
            Title = string.Empty;
            Description = string.Empty;
            
        }

        public ICommand Save
        {
            get
            {
                return new MvxCommand(() => AddNewBook());
            }
        }

        private void AddNewBook()
        {
            var bookRequest = new BookRequest
            {
                Title = this.Title,
                Price = this.Price,
                Description = this.Description,
                CategoryId = SelectedCategory.Id
            };
           var response = _service.CreateNewBook(bookRequest).Result;
            if (!response.Success)
            {
                Mvx.Resolve<IUserDialogs>().ShowError(response.Messages);
            }
        }

        private CategoryResponse _selectedCategory;
        public CategoryResponse SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                RaisePropertyChanged(() => SelectedCategory);
            }
        }

        public ICommand BackToList
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<BookListViewModel>());
            }
        }
    }
}
