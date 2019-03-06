using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Frontend.Models
{
    public class Category
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Collection<Book> Books
        {
            get;
            set;
        }
    }
}