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
    public class AreaListModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public AreaListModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Area Area { get; set; }

        [NotMapped]
        [BindProperty]
        public IFormFile AreaImage { get; set; }

        public List<Area> AreaList { get; set; } = new List<Area>();

        public void OnGet()
        {
            AreaList = _context.AreasOfInterest.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var area = _context.AreasOfInterest.Where(x => x.Id == id).FirstOrDefault();

            _context.Remove(area);
            _context.SaveChanges();

            return RedirectToAction("Get");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            DateTimeOffset createdDate = DateTime.Now;

            var area = Area;
            area.AreaName = Area.AreaName;
            area.AreaDescription = Area.AreaDescription;
            
            if (AreaImage != null)
            {
                var file = Path.Combine(_environment.ContentRootPath, "areaImages", AreaImage.FileName);
                using (var fileStream = new MemoryStream())
                {
                    AreaImage.CopyTo(fileStream);
                    var fileBytes = fileStream.ToArray();

                    area.AreaImage = fileBytes;

                    if (!ModelState.IsValid)
                    {
                        return Page();
                    }
                }
            }

            _context.Add(area);
            _context.SaveChanges();

            return RedirectToAction("/Get");
        }
    }
}
