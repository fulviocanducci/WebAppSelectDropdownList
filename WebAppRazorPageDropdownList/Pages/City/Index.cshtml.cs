using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebAppRazorPageDropdownList.Pages.City
{
    public class IndexModel : PageModel
    {
        private readonly Web.Data.DatabaseContext _context;

        public IndexModel(Web.Data.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Web.Data.City> City { get;set; }

        public async Task OnGetAsync()
        {
            City = await _context.City
                .Include(c => c.Uf).ToListAsync();
        }
    }
}
