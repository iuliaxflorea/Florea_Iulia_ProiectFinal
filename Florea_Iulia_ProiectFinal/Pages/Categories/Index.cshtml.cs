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
    public class IndexModel : PageModel
    {
        private readonly Florea_Iulia_ProiectFinal.Data.Florea_Iulia_ProiectFinalContext _context;

        public IndexModel(Florea_Iulia_ProiectFinal.Data.Florea_Iulia_ProiectFinalContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
