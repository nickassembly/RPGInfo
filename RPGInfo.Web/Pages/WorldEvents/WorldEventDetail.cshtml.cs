using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPGInfo.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages.WorldEvents
{
    public class WorldEventDetail : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CharacterDetailModel> _logger;

        public WorldEventDetail(ApplicationDbContext context, ILogger<CharacterDetailModel> logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
