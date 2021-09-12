using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public List<Character> CharacterList { get; set; } = new List<Character>();

        public void OnGet()
        {
            CharacterList = _context.Characters.ToList();

        }

        public IActionResult OnPost()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            DateTimeOffset createdDate = DateTime.Now;

            // TODO: Add Relationships, Setting, etc. 
            // TODO: link known characters to characters in db
            // TODO: Fix view when no portrait exists

            var character = Character;
            character.Name = Character.Name;
            character.Race = Character.Race;
            character.Class = Character.Class;
            character.CurrentLocation = Character.CurrentLocation;

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

            character.CreatedBy = new Guid(userId);
            character.CreatedDate = createdDate;

            _context.Add(character);
            _context.SaveChanges();

            return RedirectToPage("/CharacterList");
        }
    }
}
