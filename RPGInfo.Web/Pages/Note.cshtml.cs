using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using System;
using System.Linq;

namespace RPGInfo.Web.Pages
{
    public class NoteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Note Note { get; set; }

        [BindProperty]
        public Character Character { get; set; }

        public NoteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Possibly Add view component for note instead of having a full page? 

        public void OnGet(int id)
        {
            Character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();

            Note = new Note
            {
                NoteAuthor = Character.Name
            };
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Note noteToAdd = new Note
                {
                    NoteAuthor = Character.Name,
                    NoteDate = DateTime.Now,
                    NoteType = NoteType.CharacterNote,
                    NoteTitle = Note.NoteTitle,
                    NoteContent = Note.NoteContent
                };

                _context.Notes.Add(noteToAdd);
                _context.SaveChanges();

                Character.CharacterNotes.Add(noteToAdd);

                RedirectToPage($"/CharacterDetail");
            }
        }
    }
}
