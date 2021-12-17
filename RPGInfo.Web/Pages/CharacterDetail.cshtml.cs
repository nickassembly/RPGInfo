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
        public List<Note> CharacterNotes { get; set; } = new List<Note>();

        public void OnGet(int id)
        {
            Character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();

            Character.CharacterNotes = _context.Notes.Where(x => x.NoteAuthor == Character.Name).ToList();   
        }

        [BindProperty]
        public Note CharacterNote { get; set; }

        public ActionResult OnPostAddNote(Note note)
        {
            // TODO: create note model based on input, add Author, date, etc. 

            return RedirectToPage();
        }




    }
}
