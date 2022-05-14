using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using RPGInfo.Web.Services;
using System.Linq;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages.WorldEvents
{
    public class WorldEventDetailModel : PageModel
    {
        private readonly ILogger<CharacterDetailModel> _logger;
        private readonly INote _notes;
        private readonly INpc _npcs;

        public WorldEventDetailModel(ILogger<CharacterDetailModel> logger, INote notes, INpc npcs)
        {
            _logger = logger;
            _notes = notes;
            _npcs = npcs;
        }

        public string LoggedInUser
        {
            get
            {
                return UserUtils.GetLoggedInUser(User);
            }
        }

        [BindProperty]
        public WorldEvent WorldEvent { get; set; }

        public void OnGet(int id)
        {
            //WorldEvent = _context.WorldEvents.Where(x => x.Id == id && x.UserId == LoggedInUser).FirstOrDefault();

            //WorldEvent.EventNotes = _context.Notes.Where(note => note.WorldEventId == id).ToList();

            //WorldEvent.RelatedNpcs = _context.RelatedNpcs.Where(npc => npc.WorldEventId == id).ToList();
        }

        [BindProperty]
        public string[] EventNoteStrings { get; set; }

        public ActionResult OnPostAddNotes([FromBody] string[] noteStrings)
        {
            var newNotes = _notes.AddNotes(noteStrings, LoggedInUser, RpgEntityType.EventType, WorldEvent.Id);

            WorldEvent.EventNotes.AddRange(newNotes);

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
            _npcs.AddNpcs(npcToAdd, LoggedInUser, RpgEntityType.EventType, WorldEvent.Id);

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
            //    var eventToEdit = _context.WorldEvents.Where(x => x.Id == WorldEvent.Id).FirstOrDefault();

            //    if (eventToEdit != null)
            //    {
            //        eventToEdit.EventName = WorldEvent.EventName;
            //        eventToEdit.EventDescription = WorldEvent.EventDescription;
            //        eventToEdit.EventDate = WorldEvent.EventDate;
            //        eventToEdit.UserId = LoggedInUser;
            //    }

            //    _context.WorldEvents.Update(eventToEdit);
            //    _context.SaveChanges();
           // }
            return RedirectToPage();
        }
    }
}
