using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageProject.DAL;
using RazorPageProject.Models;

namespace RazorPageProject.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly MyAppDbContext _context;
        public CreateModel(MyAppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
		public Product Products { get; set; }

        public async Task<IActionResult> OnPost() 
        {
            if(!ModelState.IsValid || _context.Products == null || Products == null)
            {
                return Page();
            }
            else
            {
                _context.Products.Add(Products);
                await _context.SaveChangesAsync();
                return RedirectToPage(nameof(Index));
            }
        }
	}
}
