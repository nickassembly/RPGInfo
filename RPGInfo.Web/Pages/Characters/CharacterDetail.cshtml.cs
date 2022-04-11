﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using RPGInfo.Web.Services;
using System.Linq;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages
{
    public class CharacterDetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CharacterDetailModel> _logger;
        private readonly INote _notes;
        private readonly INpc _npcs;

        public CharacterDetailModel(ApplicationDbContext context, ILogger<CharacterDetailModel> logger, INote notes, INpc npcs)
        {
            _context = context;
            _logger = logger;
            _notes = notes;
            _npcs = npcs;
        }

        [BindProperty]
        public Character Character { get; set; }

        public void OnGet(int id)
        {
            string loggedInUserId = UserUtils.GetLoggedInUser(User);

            Character = _context.Characters.Where(x => x.Id == id && x.UserId == loggedInUserId).FirstOrDefault();

            Character.CharacterNotes = _context.Notes.Where(note => note.CharacterId == id).ToList();

            Character.RelatedNpcs = _context.RelatedNpcs.Where(npc => npc.CharacterId == id).ToList();
        }

        [BindProperty]
        public string[] CharacterNoteStrings { get; set; }

        public ActionResult OnPostAddNotes([FromBody] string[] noteStrings)
        {
            string loggedInUserId = UserUtils.GetLoggedInUser(User);

            var newNotes = _notes.AddNotes(noteStrings, loggedInUserId, RpgEntityType.CharacterType, Character.Id);

            Character.CharacterNotes.AddRange(newNotes);

            return RedirectToPage();
        }

        public ActionResult OnPutEditNote(Note editedNote)
        {
            string loggedInUserId = UserUtils.GetLoggedInUser(User);

            _notes.EditNote(editedNote, loggedInUserId);

            return RedirectToPage();
        }

        public ActionResult OnPutDeleteNote(Note noteToDelete)
        {
            _notes.DeleteNote(noteToDelete);

            return RedirectToPage();
        }

        public async Task<ActionResult> OnPostAddNpcs([FromForm] RelatedNpc npcToAdd)
        {
            string loggedInUserId = UserUtils.GetLoggedInUser(User);

            _npcs.AddNpcs(npcToAdd, loggedInUserId, RpgEntityType.CharacterType, Character.Id);

            return RedirectToPage();
        }

        public ActionResult OnPutEditNpc(RelatedNpc editedNpc)
        {
            string loggedInUserId = UserUtils.GetLoggedInUser(User);

            _npcs.EditNpc(editedNpc, loggedInUserId);

            return RedirectToPage();
        }

        public ActionResult OnPutDeleteNpc(RelatedNpc npcToDelete)
        {
            _npcs.DeleteNpc(npcToDelete);

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
