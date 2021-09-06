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

        //public List<SelectListItem> KnownCharacterOptions { get; set; }

        [NotMapped]
        [BindProperty]
        public IFormFile Portrait { get; set; }

        public List<Character> CharacterList { get; set; } = new List<Character>();
        public List<Character> KnownCharacterList { get; set; } = new List<Character>();

        [BindProperty]
        public Guid[] SelectedKnownCharacters { get; set; }
        public SelectList KnownCharacterOptions { get; set; }

        public void OnGet()
        {
            CharacterList = _context.Characters.ToList();

            KnownCharacterOptions = new SelectList(_context.Characters, nameof(Character.Id), nameof(Character.Name));

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

                // TODO: Add Character Campaign and Setting add functions


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
