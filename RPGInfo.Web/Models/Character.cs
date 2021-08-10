using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Models
{
    public class Character
    {
        public byte[] Portrait { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string CurrentLocation { get; set; }
        public List<string> Relationships { get; set; } = new List<string>();
        public Setting Setting { get; set; }
        public Campaign Campaign { get; set; }
        public string CharacterNotes { get; set; }
    }
}
