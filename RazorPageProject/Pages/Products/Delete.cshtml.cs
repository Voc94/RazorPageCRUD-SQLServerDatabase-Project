using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageProject.DAL;
using RazorPageProject.Models;

namespace RazorPageProject.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly MyAppDbContext _appDbContext;

        [BindProperty]
        public Product Products { get; set; }

        public DeleteModel(MyAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Products = await _appDbContext.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (Products == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Products = await _appDbContext.Products.FindAsync(id);

            if (Products != null)
            {
                _appDbContext.Products.Remove(Products);
                await _appDbContext.SaveChangesAsync();
                return RedirectToPage(nameof(Index)); // Redirect to the listing page upon successful deletion.
            }

            return NotFound(); // If no product is found with the given ID, return NotFound.
        }
    }
}
