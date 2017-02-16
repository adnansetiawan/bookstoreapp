using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using BookStoreApp.ViewModel;
using Acr.UserDialogs;

namespace BookStoreApp.Droid.View
{
    [Activity(Label = "Add Book")]
    public class BookFormView : MvxActivity<BookFormViewModel>
    {

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.BookForm);
            UserDialogs.Init(this);

        }

    }
}