using System.Collections.Generic;

namespace RPGInfo.Web.Models
{
    public class Character : BaseEntity
    {
        public byte[] Portrait { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Backstory { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public List<WorldEvent> CharacterEvents { get; set; } = new List<WorldEvent>();
        public List<Note> CharacterNotes { get; set; } = new List<Note>();
        public List<Area> KnownAreas { get; set; } = new List<Area>();
        public List<RelatedNpc> RelatedNpcs { get; set; } = new List<RelatedNpc>();

    }
}
