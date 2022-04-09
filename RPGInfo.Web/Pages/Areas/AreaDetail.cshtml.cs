using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using RPGInfo.Web.Services;
using System.Linq;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages
{
    public class AreaDetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AreaDetailModel> _logger;
        private readonly INote _notes;
        private readonly INpc _npcs;

        public AreaDetailModel(ApplicationDbContext context, ILogger<AreaDetailModel> logger, INote notes, INpc npcs)
        {
            _context = context;
            _logger = logger;
            _notes = notes;
            _npcs = npcs;
        }

        [BindProperty]
        public Area Area { get; set; }

        // TODO: Change ALL methods to only retrive logged in user
        // need to wire up UserManager<LoggedInUser>
        public void OnGet(int id)
        {
            string loggedInUserId = UserUtils.GetLoggedInUser(User);

            Area = _context.AreasOfInterest.Where(x => x.Id == id && x.UserId == loggedInUserId).FirstOrDefault();

            Area.AreaNotes = _context.Notes.Where(note => note.AreaId == id).ToList();

            Area.RelatedNpcs = _context.RelatedNpcs.Where(npc => npc.AreaId == id).ToList();
        }

        [BindProperty]
        public string[] AreaNoteStrings { get; set; }

        public ActionResult OnPostAddNotes([FromBody] string[] noteStrings)
        {
            var newNotes = _notes.AddNotes(noteStrings, RpgEntityType.AreaType, Area.Id);

            Area.AreaNotes.AddRange(newNotes);

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
            _npcs.AddNpcs(npcToAdd, RpgEntityType.AreaType, Area.Id);

            return RedirectToPage();
        }

        public ActionResult OnPutEditNpc(RelatedNpc editedNpc)
        {
            _npcs.EditNpc(editedNpc);

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
                var areaToEdit = _context.AreasOfInterest.Where(x => x.Id == Area.Id).FirstOrDefault();

                if (areaToEdit != null)
                {
                    areaToEdit.AreaName = Area.AreaName;
                    areaToEdit.AreaDescription = Area.AreaDescription;
                }

                _context.AreasOfInterest.Update(areaToEdit);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }

    }
}
