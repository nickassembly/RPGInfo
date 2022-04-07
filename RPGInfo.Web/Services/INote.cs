using Microsoft.AspNetCore.Mvc;
using RPGInfo.Web.Models;
using System.Collections.Generic;


namespace RPGInfo.Web.Services
{
    public interface INote
    {
        List<Note> AddNotes([FromBody] string[] stringsToConvert, RpgEntityType noteType, int id);
        void EditNote(Note editedNote);
        void DeleteNote(Note deletedNote);
    }

}
