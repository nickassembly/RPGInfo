using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Models
{
    public class Setting
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public List<Campaign> Campaigns { get; set; }
        public List<AreasOfInterest> AreasOfInterest { get; set; }
        public List<Character> NativeCharacters { get; set; }
        public List<Note> SettingNotes { get; set; }

    }
}
