using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Florea_Iulia_ProiectFinal.Data;
using Florea_Iulia_ProiectFinal.Models;

namespace Florea_Iulia_ProiectFinal.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Florea_Iulia_ProiectFinal.Data.Florea_Iulia_ProiectFinalContext _context;

        public DetailsModel(Florea_Iulia_ProiectFinal.Data.Florea_Iulia_ProiectFinalContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
