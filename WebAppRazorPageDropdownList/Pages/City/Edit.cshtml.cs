using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebAppRazorPageDropdownList.Pages.City
{
    public class EditModel : PageModel
    {
        private readonly Web.Data.DatabaseContext _context;

        public EditModel(Web.Data.DatabaseContext context)
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
           ViewData["UfId"] = new SelectList(_context.Uf, "Id", "Initials");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(City).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(City.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.Id == id);
        }
    }
}
