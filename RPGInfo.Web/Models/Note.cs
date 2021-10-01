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
        public string NoteAuthor { get; set; }
        public DateTime NoteDate { get; set; }
        [Required]
        public string NoteContent { get; set; }
        public NoteType NoteType { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

    }
}
