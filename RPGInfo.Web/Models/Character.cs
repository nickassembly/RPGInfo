using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPGInfo.Web.Models
{
    public class Character : BaseEntity
    {
        public byte[] Portrait { get; set; }

        // TODO: Add Description property
        // Add property to model and migrate to DB

        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string CurrentLocation { get; set; }
        public Setting Setting { get; set; }
        public Campaign Campaign { get; set; }
        public List<Note> CharacterNotes { get; set; } = new List<Note>();

        public virtual ICollection<Character> OthersWhoCharacterKnows { get; set; }
        public virtual ICollection<Character> OthersWhoKnowCharacter { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
