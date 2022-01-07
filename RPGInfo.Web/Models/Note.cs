using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // TODO: Add properties See Note Table (campaign Id, event id, etc)
        public int? CharacterId { get; set; }

    }
}
