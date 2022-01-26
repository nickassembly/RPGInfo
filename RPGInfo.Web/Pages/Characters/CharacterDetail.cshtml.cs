﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPGInfo.Web.Data;
using RPGInfo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPGInfo.Web.Pages
{
    public class CharacterDetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CharacterDetailModel> _logger;

        public CharacterDetailModel(ApplicationDbContext context, ILogger<CharacterDetailModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        // for character details (this page)
        [BindProperty]
        public Character Character { get; set; }

        public void OnGet(int id)
        {
            Character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();

            Character.CharacterNotes = _context.Notes.Where(note => note.CharacterId == id).ToList();   
        }

        [BindProperty]
        public Note CharacterNote { get; set; }

        [BindProperty]
        public List<Note> CharacterNotes { get; set; }

        [BindProperty]
        public string[] CharacterNoteStrings { get; set; }


        public ActionResult OnPostAddNotes([FromBody]string[] notes)
        {
            List<Note> newNotes = new List<Note>();

            for (int i = 0; i < notes.Length; i++)
            {
               var noteStr =  notes[i].Substring(0, notes[i].IndexOf(":"));
                // break each string into note properties
                // create new notes for every string in array
            }

            //Note noteToAdd = new Note
            //{
            //    NoteTitle = note.NoteTitle,
            //    NoteContent = note.NoteContent,
            //    NoteDate = note.NoteDate,
            //    NoteType = NoteType.CharacterNote,
            //    CharacterId = Character.Id
            //};

            //_context.Notes.Add(noteToAdd);
            //_context.SaveChanges();

            //Character.CharacterNotes.Add(noteToAdd);

            return RedirectToPage();
        }

        public ActionResult OnPost()
        {
            // TODO: Save changes comes here
            // save properties from character detail page

            // TODO: Pass List of Notes, List of Characters to this method
            return RedirectToPage("CharacterList");
        }




    }
}
