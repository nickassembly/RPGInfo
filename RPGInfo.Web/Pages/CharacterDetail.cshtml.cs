using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using RPGInfo.Web.ViewModels;
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
        public NoteViewModel NoteViewModel { get; set; }

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

            // add db call to get character notes here
            NoteViewModel = new NoteViewModel
            {
                NoteTitle = "Test NoteVM Title",
                NoteContent = "Test Note VM Content"
            };

        }

        public IActionResult OnGetAddNote(int id)
        {
            Character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();

            return RedirectToPage("Note", new { id = id }); 
        }

        public IActionResult OnPost()
        {
            // TODO: Add Logic to update Character Notes and list them here. 
            // Submit button on partial view comes here
            return null;
        }

    }
}
