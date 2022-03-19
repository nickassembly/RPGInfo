using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.ViewModels
{
    public class CharacterDetailsDisplay
    {
        public List<Note> CharacterNotes { get; set; }
        public List<RelatedNpc> CharacterRelatedNpcs { get; set; }

    }
}
