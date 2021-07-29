using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext dbContext; //Getting DB Context

        public IndexModel(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public IEnumerable<Book> Books { get; set; } // // Book Model Class Property

        public async Task OnGet()
        {
            Books = await dbContext.Book.ToListAsync();
        }


        public async Task<IActionResult> OnPostDelete(int id)
        {
            var gettingBook = await dbContext.Book.FindAsync(id);

            if(gettingBook == null)
            {
                return NotFound();
            }

            dbContext.
                Remove(gettingBook);
            await 
                dbContext.SaveChangesAsync();

            return RedirectToPage("Index");

        }
    }
}