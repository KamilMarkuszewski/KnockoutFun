using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using AutoMapper;
using Frontend.Models;
using Frontend.ViewModels;
using FrontendApp.Database;
using NServiceBus;


namespace FrontendApp.Controllers
{
    public class HomeController : Controller
    {
        BooksRepo repo = new BooksRepo();

        public ActionResult Index()
        {
            List<BookViewModel> books = new List<BookViewModel>();
            books.AddRange(repo.GetAllBooks().Select(b => Mapper.Map<BookViewModel>(b)));
            ViewBag.IsAdmin = repo.IsAdmin();

            var sets = repo.GetAllSets();
            var categories = repo.GetAllCategories();

            return View(new HomeViewModel(books, sets, categories));
        }

        [HttpPost]
        public JsonResult GetBooks()
        {
            List<BookViewModel> books = new List<BookViewModel>();
            books.AddRange(repo.GetAllBooks().Select(b => Mapper.Map<BookViewModel>(b)));
            return Json(books);
        }

        [HttpPost]
        public void Edit(BookViewModel bookViewModel)
        {
            if (repo.IsAdmin())
            {
                repo.Update(Mapper.Map<Book>(bookViewModel));
            }
            else
            {
                throw new AccessViolationException();
            }
        }

        [HttpPost]
        public void Remove(int id)
        {
            if (repo.IsAdmin())
            {
                repo.Remove(id);
            }
            else
            {
                throw new AccessViolationException();
            }

        }

        [HttpPost]
        public void Add(BookViewModel bookViewModel)
        {
            repo.Add(Mapper.Map<Book>(bookViewModel));
        }
    }
}