﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Models
{
    public class RelatedNpc : BaseEntity
    {
        public byte[] Portrait { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Backstory { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }

        public int? AreaId { get; set; }
        public int? WorldEventId { get; set; }
        public int? CharacterId { get; set; }
    }
}
