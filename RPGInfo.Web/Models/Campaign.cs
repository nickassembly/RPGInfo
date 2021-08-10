﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Models
{
    public class Campaign
    {
        public string CampaignName { get; set; }
        public List<Party> Parties { get; set; }
        public List<CampaignEvent> CampaignEvents { get; set; }
        public List<AreasOfInterest> CampaignAreas { get; set; }
        public List<Note> CampaignNotes { get; set; }
    }
}