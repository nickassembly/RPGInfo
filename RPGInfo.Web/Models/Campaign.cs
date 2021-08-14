using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Models
{
    public class Campaign : BaseEntity
    {
        public string CampaignName { get; set; }
        public List<Party> Parties { get; set; }
        public List<CampaignEvent> CampaignEvents { get; set; }
        public List<AreaOfInterest> CampaignAreas { get; set; }
        public List<Note> CampaignNotes { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
