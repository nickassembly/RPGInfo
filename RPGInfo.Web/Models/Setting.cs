using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Models
{
    public class Setting : BaseEntity
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public List<Campaign> Campaigns { get; set; }
        public List<AreaOfInterest> AreasOfInterest { get; set; }
        public List<Character> NativeCharacters { get; set; }
        public List<Note> SettingNotes { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

    }
}
