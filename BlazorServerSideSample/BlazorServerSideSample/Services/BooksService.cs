using BlazorServerSideSample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib
{
    public class BooksService : IBooksService
    {
        private BooksContext _booksContext;

        public BooksService(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }
        public Task<IEnumerable<Book>> GetBooksAsync()
        {
            return Task.FromResult<IEnumerable<Book>>(_booksContext.Books.ToList());
        }
    }
}
