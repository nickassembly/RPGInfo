﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using RPGInfo.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInfo.Web.Pages
{
    public class AreaDetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AreaDetailModel> _logger;
        private readonly INote _notes;

        public AreaDetailModel(ApplicationDbContext context, ILogger<AreaDetailModel> logger, INote notes)
        {
            _context = context;
            _logger = logger;
            _notes = notes;
        }

        [BindProperty]
        public Area Area { get; set; }

        public void OnGet(int id)
        {
            Area = _context.AreasOfInterest.Where(x => x.Id == id).FirstOrDefault();

            Area.AreaNotes = _context.Notes.Where(note => note.AreaId == id).ToList();

            Area.RelatedNpcs = _context.RelatedNpcs.Where(npc => npc.AreaId == id).ToList();
        }

        [BindProperty]
        public string[] AreaNoteStrings { get; set; }

        public ActionResult OnPostAddNotes([FromBody] string[] noteStrings)
        {
            var newNotes = _notes.AddNotes(noteStrings, NoteType.AreaNote, Area.Id);

            Area.AreaNotes.AddRange(newNotes);

            return RedirectToPage();
        }

        public ActionResult OnPutEditNote(Note editedNote)
        {
            _notes.EditNote(editedNote);

            return RedirectToPage();
        }

        public ActionResult OnPutDeleteNote(Note noteToDelete)
        {
            _notes.DeleteNote(noteToDelete);

            return RedirectToPage();
        }

        public async Task<ActionResult> OnPostAddNpcs([FromForm] RelatedNpc npcToAdd)
        {
            RelatedNpc newNpc = new RelatedNpc
            {
                AreaId = Area.Id,
                Name = npcToAdd.Name,
                Relationship = npcToAdd.Relationship,
                Background = npcToAdd.Background,
                Race = npcToAdd.Race,
                Class = npcToAdd.Class
            };

            _context.RelatedNpcs.Add(newNpc);
            _context.SaveChanges();

            return RedirectToPage();
        }

        public ActionResult OnPutEditNpc(RelatedNpc editedNpc)
        {

            var npcToEdit = _context.RelatedNpcs.Where(npc => npc.Id == editedNpc.Id).FirstOrDefault();

            npcToEdit.Name = editedNpc.Name != null ? editedNpc.Name : npcToEdit.Name;
            npcToEdit.Relationship = editedNpc.Relationship != null ? editedNpc.Relationship : npcToEdit.Relationship;
            npcToEdit.Background = editedNpc.Background != null ? editedNpc.Background : npcToEdit.Background;
            npcToEdit.Race = editedNpc.Race != null ? editedNpc.Race : npcToEdit.Race;
            npcToEdit.Class = editedNpc.Class != null ? editedNpc.Class : npcToEdit.Class;
            _context.SaveChanges();

            return RedirectToPage();
        }

        public ActionResult OnPutDeleteNpc(RelatedNpc npcToDelete)
        {
            var npcToRemove = _context.RelatedNpcs.AsNoTracking().Where(npc => npc.Id == npcToDelete.Id).FirstOrDefault();

            if (npcToDelete != null)
            {
                _context.RelatedNpcs.Remove(npcToDelete);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var areaToEdit = _context.AreasOfInterest.Where(x => x.Id == Area.Id).FirstOrDefault();

                if (areaToEdit != null)
                {
                    areaToEdit.AreaName = Area.AreaName;
                    areaToEdit.AreaDescription = Area.AreaDescription;
                }

                _context.AreasOfInterest.Update(areaToEdit);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }

    }
}
