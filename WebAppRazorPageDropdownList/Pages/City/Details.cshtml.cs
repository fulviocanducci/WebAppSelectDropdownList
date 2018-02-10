using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebAppRazorPageDropdownList.Pages.City
{
    public class DetailsModel : PageModel
    {
        private readonly Web.Data.DatabaseContext _context;

        public DetailsModel(Web.Data.DatabaseContext context)
        {
            _context = context;
        }

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
    }
}
