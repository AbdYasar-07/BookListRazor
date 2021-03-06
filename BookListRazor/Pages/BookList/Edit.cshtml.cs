using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;

        [BindProperty]
        public Book Book { get; set;}

        public EditModel(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public async Task OnGet(int id)
        {
           Book = await dbContext.Book.FindAsync(id);
        }


        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var gettingBookDetails = await dbContext.Book.FindAsync(Book.Id);
                gettingBookDetails.Name = Book.Name;
                gettingBookDetails.Author = Book.Author;
                gettingBookDetails.ISBN = Book.ISBN;

                await 
                    dbContext
                             .SaveChangesAsync();
                return RedirectToPage("Index");

            }
            return RedirectToPage();
        }

    }
}
