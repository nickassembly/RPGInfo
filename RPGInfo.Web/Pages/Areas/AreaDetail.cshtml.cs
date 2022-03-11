using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages
{
    public class AreaDetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AreaDetailModel> _logger;

        public AreaDetailModel(ApplicationDbContext context, ILogger<AreaDetailModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Area Area { get; set; }

        public void OnGet(int id)
        {
            Area = _context.AreasOfInterest.Where(x => x.Id == id).FirstOrDefault();

            Area.AreaNotes = _context.Notes.Where(note => note.AreaId == id).ToList();
        }

        [BindProperty]
        public string[] AreaNoteStrings { get; set; }

        public ActionResult OnPostAddNotes([FromBody] string[] noteStrings)
        {
            List<Note> newNotes = ConvertStringsToNotes(noteStrings);

            _context.Notes.AddRange(newNotes);
            _context.SaveChanges();

            Area.AreaNotes.AddRange(newNotes);

            return RedirectToPage();
        }

        public ActionResult OnPutEditNote(Note editedNote)
        {
            var noteToEdit = _context.Notes.Where(note => note.Id == editedNote.Id).FirstOrDefault();

            noteToEdit.NoteContent = editedNote.NoteContent != null ? editedNote.NoteContent : noteToEdit.NoteContent;
            noteToEdit.NoteTitle = editedNote.NoteTitle != null ? editedNote.NoteTitle : noteToEdit.NoteTitle;
            noteToEdit.NoteDate = editedNote.NoteDate;
            _context.SaveChanges();

            return RedirectToPage();
        }

        public ActionResult OnPutDeleteNote(Note noteToDelete)
        {
            var noteToRemove = _context.Notes.Where(note => note.Id == noteToDelete.Id).FirstOrDefault();

            if (noteToRemove != null)
            {
                _context.Notes.Remove(noteToRemove);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }

        private List<Note> ConvertStringsToNotes(string[] stringsToConvert)
        {
            List<Note> newNotes = new List<Note>();

            for (int i = 0; i < stringsToConvert.Length; i++)
            {
                Note note = new Note();

                string titleKey = "Title:";
                string dateKey = "Date:";
                string contentKey = "Note:";
                int stringLength = stringsToConvert[i].Length;

                int titleIndex = stringsToConvert[i].IndexOf(titleKey);
                int dateIndex = stringsToConvert[i].IndexOf(dateKey);
                int contentIndex = stringsToConvert[i].IndexOf(contentKey);

                string extractedTitle = stringsToConvert[i][titleIndex..dateIndex];
                string extractedDate = stringsToConvert[i][dateIndex..contentIndex];
                string extractedContent = stringsToConvert[i][contentIndex..stringLength];

                note.NoteTitle = extractedTitle.Substring(6);

                DateTime noteDate;
                if (DateTime.TryParse(extractedDate.Substring(5), out noteDate))
                    note.NoteDate = noteDate;
                else
                    note.NoteDate = DateTime.MinValue;

                note.NoteContent = extractedContent.Substring(5);

                note.AreaId = Area.Id;

                newNotes.Add(note);
            }

            return newNotes;
        }

    }
}
