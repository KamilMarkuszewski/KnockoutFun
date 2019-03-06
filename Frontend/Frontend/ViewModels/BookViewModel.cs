using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Frontend.ViewModels
{
    public class BookViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "isbn")]
        public string Isbn { get; set; }

        public BookViewModel(int id, string title, string author, string description, string isbn)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
            Isbn = isbn;
        }

        public BookViewModel()
        {

        }
    }
}