using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using bookApp.Models;
using bookApp.Models.ViewModels;

namespace bookApp.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private BookCtxt _bookCtxt { get; set; }

        public HomeController(ILogger<HomeController> logger, BookCtxt bookCtxt) {
            _logger = logger;
            _bookCtxt = bookCtxt;
        }

        public IActionResult Index(int pageNum = 1) {
            int pageSize = 10;
            var x = new BooksViewModel {
                books = _bookCtxt.books
                    .Include(b => b.category)
                    .Include(b => b.classification)
                    .OrderBy(b => b.title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),

                pagesInfo = new PagesInfoModel {
                    totalBooks = _bookCtxt.books.Count(),
                    booksPerPage = pageSize,
                    currentPage = pageNum
                }
            };
            return View(x);
        }

        [HttpGet]
        public IActionResult Add() {
            ViewBag.categories = _bookCtxt.categories.ToList();
            ViewBag.classifications = _bookCtxt.classifications.ToList();
            ViewBag.bookFormCtxt = "Add";
            return View("Book");
        }

        [HttpPost]
        public IActionResult Add(Book book) {
            if (ModelState.IsValid) {
                _bookCtxt.Add(book);
                _bookCtxt.SaveChanges();
                return RedirectToAction("Index");
            }
            else { return RedirectToAction("Add"); }
        }

        [HttpGet]
        public IActionResult Edit(int bookID) {
            var book = _bookCtxt.books.Single(b => b.bookID == bookID);
            return View("Book", book);
        }

        [HttpPost]
        public IActionResult Edit(Book book) {
            if (ModelState.IsValid) {
                return RedirectToAction("Index");
            }
            else { return View("Book", book); }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
