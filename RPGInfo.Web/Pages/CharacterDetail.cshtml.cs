using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using RPGInfo.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages
{
    public class CharacterDetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CharacterDetailModel> _logger;

        public CharacterDetailModel(ApplicationDbContext context, ILogger<CharacterDetailModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        // for character details (this page)
        [BindProperty]
        public Character Character { get; set; }

        [BindProperty]
        public Note CharacterNote { get; set; }

        public void OnGet(int id)
        {
            Character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();

            Character.CharacterNotes = _context.Notes.Where(x => x.NoteAuthor == Character.Name).ToList();   

        }

        public IActionResult OnGetAddNote(int id)
        {
            Character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();

            return RedirectToPage("Note", new { id = id });
        }

        public IActionResult OnPostAddNote(int id, Note note)
        {
            // TODO: Refer to Demo app, How to pass input note above into this method? Need to get New Note from form, persist and save to character
            string noteAuthor = _context.Characters.Where(x => x.Id == id).Select(n => n.Name).FirstOrDefault();


            return RedirectToPage();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNote([Bind("Note")] Note note)
        {
           
        }

        public void OnPostAddKnownCharacter()
        {
            // TODO: Enter details for adding character (connected to character models)
        }

        // TEST data for child objects
        public class Header
        {
            public int Id { get; set; }
            public string MyHeaderProperty { get; set; }
            public List<ChildOfHeader> ChildOfHeader { get; set; } = new List<ChildOfHeader>();
        }

        public class ChildOfHeader
        {
            public List<ChildOfChild> MyFirstChildList { get; set; } = new List<ChildOfChild>();
            public List<ChildOfChild> MySecondChildList { get; set; } = new List<ChildOfChild>();
        }

        public class ChildOfChild
        {
            public int Id { get; set; }
            public int HeaderId { get; set; }
            public string MyChildProperty { get; set; }
        }


    }
}
