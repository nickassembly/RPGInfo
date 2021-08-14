using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace RPGInfo.Web.Pages
{
    public class Characters : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Characters(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] 
        public Character Character { get; set; }

        public List<Character> CharacterList { get; set; } = new List<Character>();

        public void OnGet()
        {
            CharacterList = _context.Characters.ToList();
        }

        // TODO: Add method for new characters

        public IActionResult OnPost()
        {
            var character = Character;

            if (!ModelState.IsValid)
            {
                return Page();
            }




            return RedirectToPage("/CharacterList");
        }
    }
}
