using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Models
{
    public class AreaOfInterest
    {
        public string AreaName { get; set; }
        public List<Character> Characters { get; set; }
        public string AreaDescription { get; set; }
        public List<Note> AreaNote { get; set; }

    }
}
