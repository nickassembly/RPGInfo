using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages
{
    public class PizzaModel : PageModel
    {
        [BindProperty]
        public Pizza NewPizza { get; set; }

        public void OnGet()
        {

        }
    }
}
