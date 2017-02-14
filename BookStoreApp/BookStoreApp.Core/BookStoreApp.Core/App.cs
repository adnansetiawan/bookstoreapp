using BookStoreApp.Service;
using BookStoreApp.Service.Contract;
using BookStoreApp.ViewModel;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp
{
    public class App : MvxApplication
    {
        public App()
        {
            Mvx.RegisterType<IService, WebApiService>();
            //Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<BookViewModel>());
            //Mvx.RegisterSingleton<IUserDialogs>(UserDialogs.Instance);
        }
    }
}
