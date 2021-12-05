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

        public CharacterDetailModel(/*ApplicationDbContext context,*/ ILogger<CharacterDetailModel> logger)
        {
          //  _context = context;
            _logger = logger;
        }

        // *** TODO TEST DATA *******
        // Test data from SO Answer https://stackoverflow.com/questions/64334126/asp-net-core-3-1-razor-pages-adding-different-child-objects-to-header
        // Added code for original Question, need to try solution implementation.
        [BindProperty]
        public Header MyHeader { get; set; } = new Header();



        // for character details (this page)
        [BindProperty]
        public Character Character { get; set; }

        [BindProperty]
        public Note CharacterNote { get; set; }

        public void OnGet(int id)
        {
            Character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();

            Character.CharacterNotes = _context.Notes.Where(x => x.NoteAuthor == Character.Name).ToList();

            // Test data
            MyHeader.Id = 1;
            MyHeader.MyHeaderProperty = "HeaderTest1";
            MyHeader.ChildOfHeader.Add(new ChildOfHeader());

            for (int i = 1; i <= 3; i++)
            {
                var childOfChild = new ChildOfChild()
                {
                    Id = i,
                    HeaderId = MyHeader.Id,
                    MyChildProperty = $"FirstChildTest{i}"
                };

                MyHeader.ChildOfHeader[0].MyFirstChildList.Add(childOfChild);
            }

            for (int i = 1; i <= 2; i++)
            {
                var childOfChild = new ChildOfChild()
                {
                    Id = i,
                    HeaderId = MyHeader.Id,
                    MyChildProperty = $"SecondChildTest{i}"
                };

                MyHeader.ChildOfHeader[0].MySecondChildList.Add(childOfChild);
            }

        }

        // Test data Partial View Results
        public PartialViewResult OnPostAddNewFirstListChildItem([FromBody] Header myHeader)
        {
            if (myHeader.ChildOfHeader[0].MyFirstChildList == null)
                myHeader.ChildOfHeader[0].MyFirstChildList = new List<ChildOfChild>();

            var childId = myHeader.ChildOfHeader[0].MyFirstChildList.Count + 1;

            myHeader.ChildOfHeader[0].MyFirstChildList.Add(new ChildOfChild
            {
                Id = childId,
                HeaderId = myHeader.Id,
                MyChildProperty = $"FirstChildTest{childId}"
            });

            var partialView = "_ListPartialView";
            //var partialView = "_FirstListItemPartial";

            var data = new CharacterDetailModel(_logger);
            data.MyHeader = myHeader;

            var myViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { { partialView, myHeader } };
            //var myViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { { partialView, myHeader.ChildOfHeader[0].MyFirstChildList } };
            myViewData.Model = data;

            var partialViewResult = new PartialViewResult()
            {
                ViewName = partialView,
                ViewData = myViewData,
            };

            return partialViewResult;
        }

        public PartialViewResult OnPostAddNewSecondListChildItem([FromBody] Header myHeader)
        {
            if (myHeader.ChildOfHeader[0].MySecondChildList == null)
                myHeader.ChildOfHeader[0].MySecondChildList = new List<ChildOfChild>();

            var childId = myHeader.ChildOfHeader[0].MySecondChildList.Count + 1;

            myHeader.ChildOfHeader[0].MySecondChildList.Add(new ChildOfChild
            {
                Id = childId,
                HeaderId = myHeader.Id,
                MyChildProperty = $"SecondChildTest{childId}"
            });

            var partialView = "_ListPartialView";
            //var partialView = "_SecondListItemPartial";

            var data = new CharacterDetailModel(_logger);
            data.MyHeader = myHeader;

            var myViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { { partialView, myHeader } };
            //var myViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { { partialView, myHeader.ChildOfHeader[0].MySecondChildList } };
            myViewData.Model = data;

            var partialViewResult = new PartialViewResult()
            {
                ViewName = partialView,
                ViewData = myViewData,
            };

            return partialViewResult;
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
