using Microsoft.AspNetCore.Mvc.RazorPages;
using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages
{
    public class NoteModel : PageModel
    {
        public Note Note { get; set; }

        public void OnGet()
        {

        }
    }
}
