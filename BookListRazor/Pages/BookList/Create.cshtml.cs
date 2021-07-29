using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;

        public CreateModel(ApplicationDbContext db)
        {
            dbContext = db;
        }
        [BindProperty]  //BindProperty is used to avoid by instanciate the class object 
        public Book Book { get; set;}

        public void OnGet()
        {

        }

        //Post Handler Method

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid) // if the input will be empty it will validate those fields
            {
                await dbContext.Book.AddAsync(Book);
                await dbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
