using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Florea_Iulia_ProiectFinal.Data;
using Florea_Iulia_ProiectFinal.Models;

namespace Florea_Iulia_ProiectFinal.Pages.Stores
{
    public class CreateModel : PageModel
    {
        private readonly Florea_Iulia_ProiectFinal.Data.Florea_Iulia_ProiectFinalContext _context;

        public CreateModel(Florea_Iulia_ProiectFinal.Data.Florea_Iulia_ProiectFinalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Store Store { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Store.Add(Store);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
