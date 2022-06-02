using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages.User
{
    public class UserDetailModel : PageModel
    {
        // TODO: Need to translate from controller to page model (if possible)
        // 6:35

        public IActionResult Index()
        {
            return Page();
        }
    }
}
