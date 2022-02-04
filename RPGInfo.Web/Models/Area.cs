using System.Collections.Generic;

namespace RPGInfo.Web.Models
{
    public class Area : BaseEntity
    {
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public List<Note> AreaNotes { get; set; } = new List<Note>();
        public List<Character> AreaCharacters { get; set; } = new List<Character>();
        public List<WorldEvent> AreaEvents { get; set; } = new List<WorldEvent>();
    }
}
