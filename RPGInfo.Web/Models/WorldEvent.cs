using System;
using System.Collections.Generic;

namespace RPGInfo.Web.Models
{
    public class WorldEvent : BaseEntity
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public List<Note> EventNotes { get; set; } = new List<Note>();
        public List<Area> EventLocations { get; set; } = new List<Area>();
        public List<Character> EventCharacters { get; set; } = new List<Character>();

    }
}
