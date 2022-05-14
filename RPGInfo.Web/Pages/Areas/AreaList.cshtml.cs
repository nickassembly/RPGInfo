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
    public class AreaListModel : PageModel
    {
 
        private readonly IWebHostEnvironment _environment;

        public AreaListModel(IWebHostEnvironment environment)
        {
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
            //string loggedInUserId = UserUtils.GetLoggedInUser(User);

            //AreaList = _context.AreasOfInterest.Where(u => u.UserId == loggedInUserId).ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            //var area = _context.AreasOfInterest.Where(x => x.Id == id).FirstOrDefault();

            //_context.Remove(area);
            //_context.SaveChanges();

            return RedirectToAction("Get");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            string loggedInUserId = UserUtils.GetLoggedInUser(User);

            var area = Area;
            area.AreaName = Area.AreaName;
            area.AreaDescription = Area.AreaDescription;
            area.UserId = loggedInUserId;
            
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

            //_context.Add(area);
            //_context.SaveChanges();

            return RedirectToAction("/Get");
        }
    }
}
