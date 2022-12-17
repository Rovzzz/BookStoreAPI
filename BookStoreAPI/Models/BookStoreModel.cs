using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreAPI.Entities;

namespace BookStoreAPI.Models
{
    public class BookStoreModel
    {
        public BookStoreModel(BookStore bookStore)
        {
            id = bookStore.id;
            name_book = bookStore.name_book;
            price = (int)bookStore.price;
            picture = bookStore.picture;
        }
        public int id { get; set; }
        public string name_book { get; set; }
        public int price { get; set; }
        public string picture { get; set; }

    }
}