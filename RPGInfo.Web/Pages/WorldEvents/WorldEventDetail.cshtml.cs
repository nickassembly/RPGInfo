using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using System.Linq;

namespace RPGInfo.Web.Pages.WorldEvents
{
    public class WorldEventDetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CharacterDetailModel> _logger;

        public WorldEventDetailModel(ApplicationDbContext context, ILogger<CharacterDetailModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public WorldEvent WorldEvent { get; set; }

        public void OnGet(int id)
        {
            WorldEvent = _context.WorldEvents.Where(x => x.Id == id).FirstOrDefault();

            WorldEvent.EventNotes = _context.Notes.Where(note => note.WorldEventId == id).ToList();

            WorldEvent.RelatedNpcs = _context.RelatedNpcs.Where(npc => npc.WorldEventId == id).ToList();
        }

    }
}
