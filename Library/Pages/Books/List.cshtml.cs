using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Library.Data;
using Library.Core;

namespace Library.Pages.Books
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration Config;
        private readonly ILibraryData libraryData;
        public string Message { get; set; }

        public IEnumerable<Book> Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config, ILibraryData libraryData)
        {
            this.Config = config;
            this.libraryData = libraryData;
        }

        public void OnGet()
        {
            Message = $" {Config["Message"]} {DateTime.Now} !";
            Books = libraryData.GetBooks(SearchTerm);

        }
    }
}