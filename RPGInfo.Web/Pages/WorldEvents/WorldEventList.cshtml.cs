using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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


    }
}
