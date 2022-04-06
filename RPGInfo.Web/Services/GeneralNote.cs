using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPGInfo.Web.Services
{
    public class GeneralNote : INote
    {
        private readonly ApplicationDbContext _context;

        public GeneralNote(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Note> AddNotes([FromBody] string[] stringsToConvert, RpgEntityType noteType, int id)
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

                if (noteType == RpgEntityType.CharacterType)
                    note.CharacterId = id;
                else if (noteType == RpgEntityType.AreaType)
                    note.AreaId = id;
                else
                    note.WorldEventId = id;

                newNotes.Add(note);
            }

            _context.Notes.AddRange(newNotes);
            _context.SaveChanges();

            return newNotes;
        }

        public void EditNote(Note editedNote)
        {
            var noteToEdit = _context.Notes.Where(n => n.Id == editedNote.Id).FirstOrDefault();

            noteToEdit.NoteContent = editedNote.NoteContent != null ? editedNote.NoteContent : noteToEdit.NoteContent;
            noteToEdit.NoteTitle = editedNote.NoteTitle != null ? editedNote.NoteTitle : noteToEdit.NoteTitle;
            noteToEdit.NoteDate = editedNote.NoteDate;
            _context.SaveChanges();
        }

        public void DeleteNote(Note deletedNote)
        {
            var noteToRemove = _context.Notes.AsNoTracking().Where(n => n.Id == deletedNote.Id).FirstOrDefault();

            if (noteToRemove != null)
            {
                _context.Notes.Remove(noteToRemove);
                _context.SaveChanges();
            }
        }
    }
}
