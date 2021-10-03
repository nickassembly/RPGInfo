using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages
{
    public class CharacterDetail : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CharacterDetail(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Character Character { get; set; }
        public List<Character> KnownCharacterList { get; set; } = new List<Character>();

        [BindProperty]
        public int[] SelectedKnownCharacters { get; set; }
        public SelectList KnownCharacterOptions { get; set; }

        [BindProperty]
        public List<Note> CharacterNotes { get; set; } = new List<Note>();


        public void OnGet(int id)
        {
            Character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();
          
            KnownCharacterOptions = new SelectList(_context.Characters, nameof(Character.Id), nameof(Character.Name));

            CharacterNotes = _context.Notes.ToList();

        }

        // TODO: How to add /CharacterDetail/id/Notes
        //                  /CharacterDetail/id/KnownCharacters
        // ................... etc
        public IActionResult OnGetAddNote(int id)
        {
            Character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();

            return RedirectToPage("Note"); 
        }

    }
}
