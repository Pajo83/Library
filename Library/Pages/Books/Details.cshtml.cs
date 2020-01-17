using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Library.Core;
using Library.Data;

namespace Library.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly ILibraryData library;
        
        public Book Book { get; set; }

        public DetailsModel(ILibraryData libraryData)
        {
            this.library = libraryData;
        }
        public IActionResult OnGet(int libraryId)
        {
            Book = library.GetBookById(libraryId);
            if (Book == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}