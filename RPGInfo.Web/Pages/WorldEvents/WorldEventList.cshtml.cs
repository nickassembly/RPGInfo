using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages
{
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
            WorldEventList = _context.WorldEvents.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //DateTimeOffset createdDate = DateTime.Now;

            var worldEvent = WorldEvent;
            worldEvent.EventName = WorldEvent.EventName;
            worldEvent.EventDescription = WorldEvent.EventDescription;
            worldEvent.EventDate = WorldEvent.EventDate;

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
