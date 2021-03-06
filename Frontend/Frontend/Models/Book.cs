﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frontend.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }

        public Book()
        {

        }

        public Book(int id, string title, string author, string description, string isbn)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
            Isbn = isbn;
        }
    }
}