using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LataPrzestepneDB.Data;
using LataPrzestepneDB.Models;
using Microsoft.EntityFrameworkCore;

namespace LataPrzestepneDB.Pages
{
    public class OstanioSzukaneModel : PageModel
    {
        private readonly PeopleContext _context;
        public OstanioSzukaneModel(PeopleContext context)
        {
            _context = context;
        }
        public IList<Person> Person { get; set; }
        public async Task OnGetAsync()
        {
            Person = await _context.Person.OrderByDescending(t => t.Data).Take(20).ToListAsync();
        }
    }
}
