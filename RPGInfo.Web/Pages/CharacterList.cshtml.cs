using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace RPGInfo.Web.Pages
{
    public class Characters : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public Characters(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty] 
        public Character Character { get; set; }

        [NotMapped]
        [BindProperty]
        public IFormFile Portrait { get; set; }

        // TODO: Saving as bytearray. Need a way to convert byte array back to Ifileformat to display on detail page

        public List<Character> CharacterList { get; set; } = new List<Character>();

        public void OnGet()
        {
            CharacterList = _context.Characters.ToList();
        }

        public IActionResult OnPost()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            DateTimeOffset createdDate = DateTime.Now;

            var file = Path.Combine(_environment.ContentRootPath, "portraits", Portrait.FileName);

            using (var fileStream = new MemoryStream(/*file, FileMode.Create*/))
            {
                Portrait.CopyTo(fileStream);
                var fileBytes = fileStream.ToArray();

                var character = Character;
                character.Portrait = fileBytes;

                character.Name = Character.Name;
                character.Race = Character.Race;
                character.Class = Character.Class;
                character.CurrentLocation = Character.CurrentLocation;
                character.Campaign = Character.Campaign;
                character.Setting = Character.Setting;
                character.CharacterNotes = Character.CharacterNotes;
                character.KnownCharacters = Character.KnownCharacters;

                character.CreatedBy = new Guid(userId);
                character.CreatedDate = createdDate;


                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.Add(character);
                _context.SaveChanges();
            }

            return RedirectToPage("/CharacterList");
        }
    }
}
