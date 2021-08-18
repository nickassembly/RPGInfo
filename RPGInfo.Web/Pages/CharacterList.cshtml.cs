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

        // TODO: Add Interface to get logged in user
        // Add Created By and Created Date to post logic

        public IActionResult OnPost()
        {
            var character = Character;

            character.Name = Character.Name;
            character.Race = Character.Race;
            character.Class = Character.Class;
            character.CurrentLocation = Character.CurrentLocation;
            character.Campaign = Character.Campaign;
            character.Setting = Character.Setting;
            character.CharacterNotes = Character.CharacterNotes;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Add(character);
            _context.SaveChanges();

            return RedirectToPage("/CharacterList");
        }
    }
}
