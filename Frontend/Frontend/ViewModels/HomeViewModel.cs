using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Frontend.Models;

namespace Frontend.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BookViewModel> Books;

        public IEnumerable<Set> Sets;

        public IEnumerable<Category> Categories;

        public HomeViewModel(IEnumerable<BookViewModel> books, IEnumerable<Set> sets, IEnumerable<Category> categories)
        {
            Books = books;
            Categories = categories;
            Sets = sets;
        }
    }
}