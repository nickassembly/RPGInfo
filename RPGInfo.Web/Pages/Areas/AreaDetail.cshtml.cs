using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages
{
    public class AreaDetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AreaDetailModel> _logger;

        public AreaDetailModel(ApplicationDbContext context, ILogger<AreaDetailModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Area Area { get; set; }

        public void OnGet(int id)
        {
            Area = _context.AreasOfInterest.Where(x => x.Id == id).FirstOrDefault();

            Area.AreaNotes = _context.Notes.Where(note => note.AreaId == id).ToList();
        }

    }
}
