using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Models
{
    public class Character : BaseEntity
    {
        public byte[] Portrait { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string CurrentLocation { get; set; }
        public List<Character> KnownCharacters { get; set; } = new List<Character>();
        public Setting Setting { get; set; }
        public Campaign Campaign { get; set; }
        public List<Note> CharacterNotes { get; set; }
    }
}
