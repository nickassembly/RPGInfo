using Microsoft.AspNetCore.Mvc;
using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Services
{
    public interface INote
    {
        List<Note> AddNotes([FromBody] string[] stringsToConvert, NoteType noteType, int id);
        void EditNote(Note editedNote);
        void DeleteNote(Note deletedNote);
    }


}
