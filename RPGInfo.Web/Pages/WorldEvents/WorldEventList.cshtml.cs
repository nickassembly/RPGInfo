using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using RPGInfo.Web.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;

namespace RPGInfo.Web.Pages
{

    // TODO: Remove all references to Context, need to call data from Mongodb
    [Authorize]
    public class WorldEventListModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public WorldEventListModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty]
        public WorldEvent WorldEvent { get; set; }

        [NotMapped]
        [BindProperty]
        public IFormFile EventImage { get; set; }

        public List<WorldEvent> WorldEventList { get; set; } = new List<WorldEvent>();

        public void OnGet()
        {
            string loggedInUserId = UserUtils.GetLoggedInUser(User);

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            string loggedInUserId = UserUtils.GetLoggedInUser(User);

            var worldEvent = WorldEvent;
            worldEvent.EventName = WorldEvent.EventName;
            worldEvent.EventDescription = WorldEvent.EventDescription;
            worldEvent.EventDate = WorldEvent.EventDate;
            worldEvent.UserId = loggedInUserId;

            if (EventImage != null)
            {
                var file = Path.Combine(_environment.ContentRootPath, "portraits", EventImage.FileName);
                using (var fileStream = new MemoryStream())
                {
                    EventImage.CopyTo(fileStream);
                    var fileBytes = fileStream.ToArray();

                    worldEvent.EventImage = fileBytes;

                    if (!ModelState.IsValid)
                    {
                        return Page();
                    }
                }
            }

            return RedirectToAction("/Get");
        }
    }
}
