using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebAppRazorPageDropdownList.Pages.City
{
    public class DeleteModel : PageModel
    {
        private readonly Web.Data.DatabaseContext _context;

        public DeleteModel(Web.Data.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Web.Data.City City { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.City
                .Include(c => c.Uf).SingleOrDefaultAsync(m => m.Id == id);

            if (City == null)
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

            City = await _context.City.FindAsync(id);

            if (City != null)
            {
                _context.City.Remove(City);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
