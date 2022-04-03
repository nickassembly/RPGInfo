using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using RPGInfo.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages
{
    public class CharacterDetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CharacterDetailModel> _logger;
        private readonly INote _notes;

        public CharacterDetailModel(ApplicationDbContext context, ILogger<CharacterDetailModel> logger, INote notes)
        {
            _context = context;
            _logger = logger;
            _notes = notes;
        }

        [BindProperty]
        public Character Character { get; set; }

        public void OnGet(int id)
        {
            Character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();

            Character.CharacterNotes = _context.Notes.Where(note => note.CharacterId == id).ToList();

            Character.RelatedNpcs = _context.RelatedNpcs.Where(npc => npc.CharacterId == id).ToList();
        }

        [BindProperty]
        public string[] CharacterNoteStrings { get; set; }

        // TODO: Refactor Area and Event to use Note Interface
        // Create methods for INpc and refactor

        public ActionResult OnPostAddNotes([FromBody] string[] noteStrings)
        {
            var newNotes = _notes.AddNotes(noteStrings, NoteType.CharacterNote, Character.Id);

            Character.CharacterNotes.AddRange(newNotes);

            return RedirectToPage();
        }

        public ActionResult OnPutEditNote(Note editedNote)
        {
            _notes.EditNote(editedNote);

            return RedirectToPage();
        }

        public ActionResult OnPutDeleteNote(Note noteToDelete)
        {
            _notes.DeleteNote(noteToDelete);

            return RedirectToPage();
        }

        public async Task<ActionResult> OnPostAddNpcs([FromForm] RelatedNpc npcToAdd)
        {
            RelatedNpc newNpc = new RelatedNpc
            {
                CharacterId = Character.Id,
                Name = npcToAdd.Name,
                Relationship = npcToAdd.Relationship,
                Background = npcToAdd.Background,
                Race = npcToAdd.Race,
                Class = npcToAdd.Class
            };

            _context.RelatedNpcs.Add(newNpc);
            _context.SaveChanges();

            return RedirectToPage();
        }

        public ActionResult OnPutEditNpc(RelatedNpc editedNpc)
        {

            var npcToEdit = _context.RelatedNpcs.Where(npc => npc.Id == editedNpc.Id).FirstOrDefault();

            npcToEdit.Name = editedNpc.Name != null ? editedNpc.Name : npcToEdit.Name;
            npcToEdit.Relationship = editedNpc.Relationship != null ? editedNpc.Relationship : npcToEdit.Relationship;
            npcToEdit.Background = editedNpc.Background != null ? editedNpc.Background : npcToEdit.Background;
            npcToEdit.Race = editedNpc.Race != null ? editedNpc.Race : npcToEdit.Race;
            npcToEdit.Class = editedNpc.Class != null ? editedNpc.Class : npcToEdit.Class;
            _context.SaveChanges();

            return RedirectToPage();
        }

        public ActionResult OnPutDeleteNpc(RelatedNpc npcToDelete)
        {
            var npcToRemove = _context.RelatedNpcs.AsNoTracking().Where(npc => npc.Id == npcToDelete.Id).FirstOrDefault();

            if (npcToRemove != null)
            {
                _context.RelatedNpcs.Remove(npcToRemove);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var characterToEdit = _context.Characters.Where(x => x.Id == Character.Id).FirstOrDefault();

                if (characterToEdit != null)
                {
                    characterToEdit.Name = Character.Name;
                    characterToEdit.Race = Character.Race;
                    characterToEdit.Class = Character.Class;
                    characterToEdit.Backstory = Character.Backstory;
                    characterToEdit.Description = Character.Description;
                }

                _context.Characters.Update(characterToEdit);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
