using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LataPrzestepneDB.Models;
using Newtonsoft.Json;
using LataPrzestepneDB.Data;

namespace LataPrzestepneDB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _context;

        [BindProperty]
        public Person Person { get; set; }
        public IList<Person> People { get; set; }
        public IndexModel(ILogger<IndexModel> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                People = _context.Person.ToList();
                TempData["Message"] = Person.AlertMessage();

                var Data = HttpContext.Session.GetString("Data");
                List<Person>? Persons;
                if (Data != null)
                {
                    Persons = JsonConvert.DeserializeObject<List<Person>>(Data);
                    Persons.Add(Person);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Persons));
                }
                else
                {
                    Persons = new List<Person>();
                    Persons.Add(Person);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Persons));
                }
                _context.Person.Add(Person);
                _context.SaveChanges();
            }
            return Page();
        }
    }
}