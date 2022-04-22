using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using RPGInfo.Web.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;

namespace RPGInfo.Web.Pages
{
    [Authorize]
    public class CharacterListModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CharacterListModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Character Character { get; set; }

        [NotMapped]
        [BindProperty]
        public IFormFile Portrait { get; set; }

        public string LoggedInUser { get; set; }

        public List<Character> CharacterList { get; set; } = new List<Character>();

        public void OnGet()
        {
            string loggedInUserId = UserUtils.GetLoggedInUser(User);

            CharacterList = _context.Characters.Where(u => u.UserId == loggedInUserId).ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();

            _context.Remove(character);
            _context.SaveChanges();

            return RedirectToAction("Get");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            string loggedInUserId = UserUtils.GetLoggedInUser(User);

            var character = Character;
            character.Name = Character.Name;
            character.Race = Character.Race;
            character.Class = Character.Class;
            character.UserId = loggedInUserId;

            if (Portrait != null)
            {
                var file = Path.Combine(_environment.ContentRootPath, "portraits", Portrait.FileName);
                using (var fileStream = new MemoryStream())
                {
                    Portrait.CopyTo(fileStream);
                    var fileBytes = fileStream.ToArray();

                    character.Portrait = fileBytes;

                    if (!ModelState.IsValid)
                    {
                        return Page();
                    }
                }
            }

            _context.Add(character);
            _context.SaveChanges();

            return RedirectToAction("/Get");
        }


    }
}
