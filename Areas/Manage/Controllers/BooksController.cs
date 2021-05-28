using jhoncedricromano.window.Areas.Manage.Models;
using jhoncedricromano.window.Infrastructure.Domain;
using jhoncedricromano.window.Infrastructure.Domain.model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jhoncedricromano.window.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BooksController : Controller
    {
        private readonly DefaultDbContext _context;

        public BooksController(DefaultDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("manage/Books")]
        public IActionResult Index(int pageIndex = 1,
                                    int pageSize = 10,
                                    string sortBy = "",
                                    string sortOrder = "asc",
                                    string keyword = "")
        {
            IQueryable<Book> allProducts = _context.Books.AsQueryable();
            Paged<Book> Books = new Paged<Book>();

            if (!string.IsNullOrEmpty(keyword))
            {
                allProducts = allProducts.Where(f => f.bktitle.Contains(keyword) || f.bkpublisher.Contains(keyword) || f.bkauthor
                .Contains(keyword));
            }
            Books.Items = allProducts.ToList();
            var queryCount = allProducts.Count();
            var skip = pageSize * (pageIndex - 1);

            long pageCount = (long)Math.Ceiling((decimal)(queryCount / pageSize));

            /*if (sortBy.ToLower() == "brand" && sortOrder.ToLower() == "asc")
            {
                Products.Items = allProducts.OrderBy(e => e.Brand).Skip(skip).Take(pageSize).ToList();
            }

            if (sortBy.ToLower() == "firstname" && sortOrder.ToLower() == "desc")
            {
               Products.Items = allProducts.OrderByDescending(e => e.Brand).Skip(skip).Take(pageSize).ToList();
            }

            if (sortBy.ToLower() == "lastname" && sortOrder.ToLower() == "asc")
            {
                Products.Items = allProducts.OrderBy(e => e.Name).Skip(skip).Take(pageSize).ToList();
            }

            if (sortBy.ToLower() == "lastname" && sortOrder.ToLower() == "desc")
            {
                Products.Items = allProducts.OrderByDescending(e => e.Name).Skip(skip).Take(pageSize).ToList();
            }*/


            var result = new BookSearchViewModel();
            result.Books = new Paged<BookViewModel>();
            result.Books.Keyword = keyword;
            result.Books.PageCount = pageCount;
            result.Books.PageIndex = pageIndex;
            result.Books.PageSize = pageSize;
            result.Books.QueryCount = queryCount;

            result.Books.Items = new List<BookViewModel>();

            foreach (var Book in Books.Items)
            {
                result.Books.Items.Add(new BookViewModel()
                {

                    bktitle = Book.bktitle,
                    bkauthor = Book.bkauthor,
                    bkpublisher = Book.bkpublisher,
                    BookID = Book.BookID
                });
            }



            return View(result);
        }
        [HttpGet("manage/product/AddProduct")]
        public IActionResult AddProduct()
        {
            return View();
        }


        [HttpPost, Route("~/Create")]
        public IActionResult Create(Models.BookViewModel model)
        {
            Infrastructure.Domain.model.Book product = new Infrastructure.Domain.model.Book()
            {


                bktitle = model.bktitle,
                bkauthor = model.bkauthor,
                bkpublisher = model.bkpublisher,
                BookID = model.BookID


            };
            _context.Books.Add(product);
            _context.SaveChanges();
            return Redirect("~/");
        }
    }
}