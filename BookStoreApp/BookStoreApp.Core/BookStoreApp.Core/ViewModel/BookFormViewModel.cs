using Acr.UserDialogs;
using BookStoreApp.Core.Validation;
using BookStoreApp.Service.Contract;
using BookStoreApp.Service.Response;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmValidation;
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
        public List<CategoryResponse> Categories { get; set; }
        public BookFormViewModel(IService service)
        {
            _service = service;
            Categories = new List<CategoryResponse>();
           

        }
        public void Init()
        {
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
        private string _author;
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                RaisePropertyChanged(() => Author);
            }
        }
        private decimal? _price;
        public decimal? Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged(() => Price);
            }
        }
        private async void LoadCategories()
        {
            
            var response = await _service.GetAllCategory();
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
            Author = string.Empty;
            Price = null;
            
            
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
            if (!IsValid())
                return;
            var bookRequest = new BookRequest
            {
                Title = this.Title,
                Price = this.Price.HasValue ? this.Price.Value : 0,
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

        public ObservableDictionary<string, string> Errors { get; set; }
        private bool IsValid()
        {
            ValidationHelper validator = new ValidationHelper();
            validator.AddRequiredRule(() => Title, "Title is required.");
            
            var result = validator.ValidateAll();
            Errors = result.AsObservableDictionary();
            RaisePropertyChanged(() => Errors);
            return result.IsValid;
        }

        
    }
}
