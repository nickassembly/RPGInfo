using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using RPGInfo.Web.Services;
using System.Linq;
using System.Threading.Tasks;

// Clear DB tables
// Generate SQL script then delete DB and Test recreation with migration
// Deploy DB to azure
// Improve Main Add Form

namespace RPGInfo.Web.Pages
{
    public class CharacterDetailModel : PageModel
    {
        private readonly ILogger<CharacterDetailModel> _logger;
        private readonly INote _notes;
        private readonly INpc _npcs;

        public CharacterDetailModel(ILogger<CharacterDetailModel> logger, INote notes, INpc npcs)
        {
            _logger = logger;
            _notes = notes;
            _npcs = npcs;
        }

        public string LoggedInUser 
        {
            get
            {
              return  UserUtils.GetLoggedInUser(User);
            }

        }

        [BindProperty]
        public Character Character { get; set; }

        public void OnGet(int id)
        {

            //Character = _context.Characters.Where(x => x.Id == id && x.UserId == LoggedInUser).FirstOrDefault();

            //Character.CharacterNotes = _context.Notes.Where(note => note.CharacterId == id).ToList();

            //Character.RelatedNpcs = _context.RelatedNpcs.Where(npc => npc.CharacterId == id).ToList();
        }

        [BindProperty]
        public string[] CharacterNoteStrings { get; set; }

        public ActionResult OnPostAddNotes([FromBody] string[] noteStrings)
        {
            var newNotes = _notes.AddNotes(noteStrings, LoggedInUser, RpgEntityType.CharacterType, Character.Id);

            Character.CharacterNotes.AddRange(newNotes);

            return RedirectToPage();
        }

        public ActionResult OnPutEditNote(Note editedNote)
        {
            _notes.EditNote(editedNote, LoggedInUser);

            return RedirectToPage();
        }

        public ActionResult OnPutDeleteNote(Note noteToDelete)
        {
            _notes.DeleteNote(noteToDelete);

            return RedirectToPage();
        }

        public async Task<ActionResult> OnPostAddNpcs([FromForm] RelatedNpc npcToAdd)
        {
            _npcs.AddNpcs(npcToAdd, LoggedInUser, RpgEntityType.CharacterType, Character.Id);

            return RedirectToPage();
        }

        public ActionResult OnPutEditNpc(RelatedNpc editedNpc)
        {
            _npcs.EditNpc(editedNpc, LoggedInUser);

            return RedirectToPage();
        }

        public ActionResult OnPutDeleteNpc(RelatedNpc npcToDelete)
        {
            _npcs.DeleteNpc(npcToDelete);

            return RedirectToPage();
        }

        public ActionResult OnPost()
        {
            //if (ModelState.IsValid)
            //{
            //    var characterToEdit = _context.Characters.Where(x => x.Id == Character.Id).FirstOrDefault();

            //    if (characterToEdit != null)
            //    {
            //        characterToEdit.Name = Character.Name;
            //        characterToEdit.Race = Character.Race;
            //        characterToEdit.Class = Character.Class;
            //        characterToEdit.Backstory = Character.Backstory;
            //        characterToEdit.Description = Character.Description;
            //        characterToEdit.UserId = LoggedInUser;
            //    }

            //    _context.Characters.Update(characterToEdit);
            //    _context.SaveChanges();
            //}

            return RedirectToPage();
        }
    }
}
