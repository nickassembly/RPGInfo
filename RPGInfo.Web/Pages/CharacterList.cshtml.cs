using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace RPGInfo.Web.Pages
{
    public class Characters : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Characters(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty] 
        public Character Character { get; set; }

        public List<Character> CharacterList { get; set; } = new List<Character>();

        public void OnGet()
        {
            CharacterList = _context.Characters.ToList();
        }

        public IActionResult OnPost()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var character = Character;

            character.Name = Character.Name;
            character.Race = Character.Race;
            character.Class = Character.Class;
            character.CurrentLocation = Character.CurrentLocation;
            character.Campaign = Character.Campaign;
            character.Setting = Character.Setting;
            character.CharacterNotes = Character.CharacterNotes;

            // TODO: Verify proper values are being saved and add Created Date, etc. 
            // Also need to only allow menus when logged in properly
            character.CreatedBy = new System.Guid(userId);

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
