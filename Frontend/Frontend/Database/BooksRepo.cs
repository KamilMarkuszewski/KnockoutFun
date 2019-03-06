using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Frontend.Database;
using Frontend.Models;

namespace FrontendApp.Database
{
    public class BooksRepo
    {
        public List<Book> GetAllBooks()
        {
            using (var context = new BooksEntities())
            {
                return context.Books.ToList().Select(b => Mapper.Map<Book>(b)).ToList();
            }
        }

        public List<Set> GetAllSets()
        {
            using (var context = new BooksEntities())
            {
                var res = context.Sets.Include(s => s.BooksSetsBindings.Select(b => b.Books)).ToList();

                return res.Select(s => Mapper.Map<SetDb, Set>(s)).ToList();
            }
        }

        public void Update(Book book)
        {
            using (var context = new BooksEntities())
            {
                var bookToUpdate = context.Books.SingleOrDefault(b => b.ID == book.Id);
                if (bookToUpdate != null)
                {
                    Mapper.Map(book, bookToUpdate);
                    context.SaveChanges();
                }
                else
                {
                    throw new DBConcurrencyException();
                }
            }
        }

        public bool IsAdmin()
        {
            return true;
        }

        public void Remove(int id)
        {
            using (var context = new BooksEntities())
            {
                var bookToRemove = context.Books.SingleOrDefault(b => b.ID == id);
                if (bookToRemove != null)
                {
                    context.Entry(bookToRemove).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                else
                {
                    throw new DBConcurrencyException();
                }
            }
        }

        public void Add(Book book)
        {
            using (var context = new BooksEntities())
            {
                var newEnt = Mapper.Map<BookDb>(book);
                context.Books.Add(newEnt);

                context.SaveChanges();
            }
        }

        public List<Category> GetAllCategories()
        {
            using (var context = new BooksEntities())
            {
                var res = context.Categories.Include(s => s.BooksCategoriesBindings.Select(b => b.Books)).ToList();

                return res.Select(s => Mapper.Map<CategoryDb, Category>(s)).ToList();
            }
        }
    }
}