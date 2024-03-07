using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageProject.DAL;
using RazorPageProject.Models;

namespace RazorPageProject.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly MyAppDbContext _appDbContext;
        public EditModel(MyAppDbContext appDbContext)
        {
                _appDbContext = appDbContext;
        }
        [BindProperty]
        public Product Products { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _appDbContext.Products == null)
            {
                return NotFound();
            }
            var product = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
				return NotFound();
            }
            Products = product;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _appDbContext.Products.Update(Products);
			await _appDbContext.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }
    }
}
