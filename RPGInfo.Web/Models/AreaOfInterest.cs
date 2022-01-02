using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Models
{
    public class AreaOfInterest : BaseEntity
    {
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public Campaign AreaCampaign { get; set; }
        public List<Note> AreaNotes { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

    }
}
