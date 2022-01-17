using System;
using System.ComponentModel.DataAnnotations;

namespace RPGInfo.Web.Models
{
    public class Note : BaseEntity
    {
        [Required]
        [MaxLength(40)]
        public string NoteTitle { get; set; }

        public DateTime NoteDate { get; set; }

        [Required]
        [MaxLength(500)]
        public string NoteContent { get; set; }
        public NoteType NoteType { get; set; }

        
        public int? CharacterId { get; set; }

    }
}
