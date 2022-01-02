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
        public Campaign Campaign { get; set; }
        public List<Note> CharacterNotes { get; set; } = new List<Note>();
        public List<Character> OthersWhoCharacterKnows { get; set; } = new List<Character>();

        public List<Character> OthersWhoKnowCharacter { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
