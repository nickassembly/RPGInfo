using System;
using System.Collections.Generic;

namespace RPGInfo.Web.Models
{
    public class Character : BaseEntity
    {
        public byte[] Portrait { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string CurrentLocation { get; set; }

        // TODO: Display list for a dropdown select
        // Get all characters
        // Add multiple members from drop down via razor input form

        public List<KnownCharacter> KnownCharacters { get; set; } = new List<KnownCharacter>();
        public Setting Setting { get; set; }
        public Campaign Campaign { get; set; }
        public List<Note> CharacterNotes { get; set; } = new List<Note>();
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
