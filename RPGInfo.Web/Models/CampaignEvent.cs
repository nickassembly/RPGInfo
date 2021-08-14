using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Models
{
    public class CampaignEvent : BaseEntity
    {
        public DateTime EventDate { get; set; }
        public string EventTitle { get; set; }
        public List<Note> EventNotes { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

    }
}
