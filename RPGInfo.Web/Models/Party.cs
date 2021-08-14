﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Models
{
    public class Party : BaseEntity
    {
        public string PartyName { get; set; }
        public List<Character> Characters { get; set; }
        public List<Setting> Settings { get; set; }
        public List<Note> PartyNotes { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

    }
}
