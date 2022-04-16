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

        public string LoggedInUser
        {
            get
            {
                return UserUtils.GetLoggedInUser(User);
            }

        }

        [BindProperty]
        public Area Area { get; set; }

        public void OnGet(int id)
        {
          //  string loggedInUserId = UserUtils.GetLoggedInUser(User);

            Area = _context.AreasOfInterest.Where(x => x.Id == id && x.UserId == LoggedInUser).FirstOrDefault();

            Area.AreaNotes = _context.Notes.Where(note => note.AreaId == id).ToList();

            Area.RelatedNpcs = _context.RelatedNpcs.Where(npc => npc.AreaId == id).ToList();
        }

        [BindProperty]
        public string[] AreaNoteStrings { get; set; }

        public ActionResult OnPostAddNotes([FromBody] string[] noteStrings/*, string userId*/)
        {
            var newNotes = _notes.AddNotes(noteStrings, LoggedInUser, RpgEntityType.AreaType, Area.Id);

            Area.AreaNotes.AddRange(newNotes);

            return RedirectToPage();
        }

        public ActionResult OnPutEditNote(Note editedNote/*, string userId*/)
        {
            _notes.EditNote(editedNote, LoggedInUser);

            return RedirectToPage();
        }

        public ActionResult OnPutDeleteNote(Note noteToDelete)
        {
            _notes.DeleteNote(noteToDelete);

            return RedirectToPage();
        }

        public async Task<ActionResult> OnPostAddNpcs([FromForm] RelatedNpc npcToAdd/*, string userId*/)
        {
            _npcs.AddNpcs(npcToAdd, LoggedInUser, RpgEntityType.AreaType, Area.Id);

            return RedirectToPage();
        }

        public ActionResult OnPutEditNpc(RelatedNpc editedNpc/*, string userId*/)
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
            if (ModelState.IsValid)
            {
                var areaToEdit = _context.AreasOfInterest.Where(x => x.Id == Area.Id).FirstOrDefault();

                if (areaToEdit != null)
                {
                    areaToEdit.AreaName = Area.AreaName;
                    areaToEdit.AreaDescription = Area.AreaDescription;
                    areaToEdit.UserId = LoggedInUser;
                }

                _context.AreasOfInterest.Update(areaToEdit);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }

    }
}
