using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;
        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(int? categoryId)
        {
            if (categoryId == null || _context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(categoryId);

            if (product != null)
            {
                Product = product;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}