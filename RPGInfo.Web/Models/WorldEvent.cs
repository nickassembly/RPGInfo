using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPGInfo.Web.Models
{
    public class WorldEvent : BaseEntity
    {
        public byte[] EventImage { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        public List<Note> EventNotes { get; set; } = new List<Note>();
        public List<Area> EventLocations { get; set; } = new List<Area>();
        public List<RelatedNpc> RelatedNpcs { get; set; } = new List<RelatedNpc>();

    }
}
