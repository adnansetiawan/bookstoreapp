using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Service.Response
{
    public class CategoryResponse : MvxViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
