using System.Collections.Generic;

namespace RPGInfo.Web.Models
{
    public class Area : BaseEntity
    {
        public byte[] AreaImage { get; set; }
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public string UserId { get; set; }
        public List<Note> AreaNotes { get; set; } = new List<Note>();
        public List<RelatedNpc> RelatedNpcs { get; set; } = new List<RelatedNpc>();
        public List<WorldEvent> AreaEvents { get; set; } = new List<WorldEvent>();
    }
}
