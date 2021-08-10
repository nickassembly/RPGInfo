using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Models
{
    public class CampaignEvent
    {
        public DateTime EventDate { get; set; }
        public string EventTitle { get; set; }
        public List<Note> EventNotes { get; set; }

    }
}
