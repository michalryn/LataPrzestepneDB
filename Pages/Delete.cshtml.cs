using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LataPrzestepneDB.Data;
using LataPrzestepneDB.Models;
using Microsoft.EntityFrameworkCore;

namespace LataPrzestepneDB.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly PeopleContext _context;
        public DeleteModel(PeopleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Person { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FirstOrDefaultAsync(m => m.Id == id);

            if (Person == null)
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

            Person = await _context.Person.FindAsync(id);

            if (Person != null)
            {
                _context.Person.Remove(Person);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./OstanioSzukane");
        }
    }
}
