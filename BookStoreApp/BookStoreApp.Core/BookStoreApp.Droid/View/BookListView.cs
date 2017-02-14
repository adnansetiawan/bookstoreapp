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

namespace BookStoreApp.Droid.View
{
    [Activity(Label = "Book List", MainLauncher = true)]
    public class BookListView : MvxActivity<BookListViewModel>
    {

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.BookItemList);
            
        }

    }
}