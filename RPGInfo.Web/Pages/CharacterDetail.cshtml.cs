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
    public class CharacterDetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CharacterDetailModel(ApplicationDbContext context)
        {
            _context = context;
        }
        // for character details (this page)
        [BindProperty]
        public Character Character { get; set; }


        // properties for add note / model
        [BindProperty]
        public NoteViewModel NoteViewModel { get; set; }

        [BindProperty]
        public List<Note> CharacterNotes { get; set; } = new();

        // properties for add other characters / model
        public List<Character> KnownCharacterList { get; set; } = new List<Character>();

        [BindProperty]
        public int[] SelectedKnownCharacters { get; set; }
        public SelectList KnownCharacterOptions { get; set; }



        public void OnGet(int id)
        {
            Character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();


            KnownCharacterOptions = new SelectList(_context.Characters, nameof(Character.Id), nameof(Character.Name));



        }

        public IActionResult OnGetAddNote(int id)
        {
            Character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();

            return RedirectToPage("Note", new { id = id });
        }

        public IActionResult OnPostAddNote(int id, Note note)
        {
            // TODO: Refer to Demo app, How to pass input note above into this method?
            string noteAuthor = _context.Characters.Where(x => x.Id == id).Select(n => n.Name).FirstOrDefault();

            var newNote = _context.Notes.Add(new Note { NoteAuthor = noteAuthor, NoteTitle = "Placeholder title", NoteContent = "Place holder" });
            _context.SaveChanges();

            return RedirectToPage();
        }

        public void OnPostAddKnownCharacter()
        {
            // TODO: Enter details for adding character (connected to character models)
        }



    }
}
