using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppRazorPageDropdownList.Pages.City
{
    public class CreateModel : PageModel
    {
        private readonly Web.Data.DatabaseContext _context;

        public CreateModel(Web.Data.DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["UfId"] = new SelectList(_context.Uf, "Id", "Initials");
            return Page();
        }

        [BindProperty]
        public Web.Data.City City { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.City.Add(City);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}