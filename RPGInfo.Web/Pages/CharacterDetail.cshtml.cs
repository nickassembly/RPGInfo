using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages
{
    public class CharacterDetail : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CharacterDetail(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Character Character { get; set; }

        [BindProperty]
        public List<Character> KnownCharacters { get; set; } = new List<Character>();


        public void OnGet(int id)
        {
            Character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();
            

        }
    }
}
