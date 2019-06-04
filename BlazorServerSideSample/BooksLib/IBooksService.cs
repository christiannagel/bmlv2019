using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorServerSideSample.Data;

namespace BooksLib
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
    }
}