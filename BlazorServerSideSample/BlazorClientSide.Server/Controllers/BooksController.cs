using BlazorClientSide.Shared;
using BlazorServerSideSample.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClientSide.Server.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private BooksContext _booksContext;
        public BooksController(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        [HttpGet()]
        public IEnumerable<Book> GetBooks()
        {
            return _booksContext.Books.ToList();
        }
    }
}
