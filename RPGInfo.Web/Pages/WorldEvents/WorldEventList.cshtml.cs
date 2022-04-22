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
    [Authorize]
    public class WorldEventListModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public WorldEventListModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
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

            WorldEventList = _context.WorldEvents.Where(u => u.UserId == loggedInUserId).ToList();
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

            _context.Add(worldEvent);
            _context.SaveChanges();

            return RedirectToAction("/Get");
        }
    }
}
