using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.ViewModels
{
    public class RelatedCharacterViewModel
    {
        public byte[] RelatedCharacterPortrait { get; set; }
        public string RelatedCharacterName { get; set; }
        public string RelatedCharacterRace { get; set; }
        public string RelatedCharacterClass { get; set; }
        public string RelatedCharacterLocation { get; set; }
        public Note RelatedCharacterNotes { get; set; }
      
    }
}
