﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPGInfo.Web.Models;
using System.Collections.Generic;

namespace RPGInfo.Web.Pages
{
    public class Characters : PageModel
    {
        // https://www.youtube.com/watch?v=68towqYcQlY&t=3457s

        // TODO: Add buttons on form to add party, relationships, settings, etc. 

        [BindProperty] 
        public CharacterModel Character { get; set; }

        public List<CharacterModel> CharacterList { get; set; } = new List<CharacterModel>()
        {
            new CharacterModel{Name = "frodo", Race = "halfling", CurrentLocation = "shire"},
            new CharacterModel{Name = "bilbo", Race = "halfling", CurrentLocation = "shire"},
            new CharacterModel{Name = "keller", Race = "halfling", CurrentLocation = "mordor"}
        };

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}
