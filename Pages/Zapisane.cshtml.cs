using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LataPrzestepneDB.Models;
using Newtonsoft.Json;

namespace LataPrzestepneDB.Pages
{
    public class ZapisaneModel : PageModel
    {
        public List<Person>? Persons { get; set; }
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (!string.IsNullOrEmpty(Data))
            {
                Persons = JsonConvert.DeserializeObject<List<Person>>(Data);
            }
        }
    }
}
