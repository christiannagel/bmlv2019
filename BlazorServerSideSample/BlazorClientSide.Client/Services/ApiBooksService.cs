using BlazorServerSideSample.Data;
using BooksLib;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorClientSide.Client.Services
{
    public class ApiBooksService : IBooksService
    {
        private HttpClient _httpClient;
        public ApiBooksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var books = await _httpClient.GetJsonAsync<IEnumerable<Book>>("api/Books");
            return books;
        }
    }
}
