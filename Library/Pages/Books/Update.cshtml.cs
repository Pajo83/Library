using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Library.Core;
using Library.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Pages.Books
{
    public class UpdateModel : PageModel
    {
        private readonly ILibraryData libraryData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Book Book { get; set; }

        public IEnumerable<SelectListItem> CategoryType { get; set; }

        public UpdateModel(ILibraryData libraryData, IHtmlHelper htmlHelper)
        {
            this.libraryData = libraryData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int bookId)
        {
            Book = libraryData.GetBookById(bookId);
            CategoryType = htmlHelper.GetEnumSelectList<Categories>();
            if (Book == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                libraryData.Update(Book);
                libraryData.Commit();
                return RedirectToPage("./Detail", new { bookId = Book.Id });
            }

            CategoryType = htmlHelper.GetEnumSelectList<Categories>();
            return Page();
        }
    }
}