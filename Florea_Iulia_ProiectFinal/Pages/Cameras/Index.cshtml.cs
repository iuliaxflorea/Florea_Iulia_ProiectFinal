using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Florea_Iulia_ProiectFinal.Data;
using Florea_Iulia_ProiectFinal.Models;

namespace Florea_Iulia_ProiectFinal.Pages.Cameras
{
    public class IndexModel : PageModel
    {
        private readonly Florea_Iulia_ProiectFinal.Data.Florea_Iulia_ProiectFinalContext _context;

        public IndexModel(Florea_Iulia_ProiectFinal.Data.Florea_Iulia_ProiectFinalContext context)
        {
            _context = context;
        }

        public IList<Camera> Camera { get;set; }
        public CameraData CameraD { get; set; }
        public int CameraID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            CameraD = new CameraData();

            CameraD.Cameras = await _context.Camera
            .Include(b => b.Store)
            .Include(b => b.CameraCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Brand)
            .ToListAsync();
            if (id != null)
            {
                CameraID = id.Value;
                Camera camera = CameraD.Cameras
                .Where(i => i.ID == id.Value).Single();
                CameraD.Categories = camera.CameraCategories.Select(s => s.Category);
            }
        }

    }
}
