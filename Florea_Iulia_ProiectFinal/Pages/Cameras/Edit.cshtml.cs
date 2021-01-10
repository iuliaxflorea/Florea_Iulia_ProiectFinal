using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Florea_Iulia_ProiectFinal.Data;
using Florea_Iulia_ProiectFinal.Models;

namespace Florea_Iulia_ProiectFinal.Pages.Cameras
{
    public class EditModel : CameraCategoriesPageModel
    {
        private readonly Florea_Iulia_ProiectFinal.Data.Florea_Iulia_ProiectFinalContext _context;

        public EditModel(Florea_Iulia_ProiectFinal.Data.Florea_Iulia_ProiectFinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Camera Camera { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Camera = await _context.Camera
 .Include(b => b.Store)
 .Include(b => b.CameraCategories).ThenInclude(b => b.Category)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);
           

            if (Camera == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData 
            PopulateAssignedCategoryData(_context, Camera);

            ViewData["StoreID"] = new SelectList(_context.Set<Store>(), "ID", "StoreName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cameraToUpdate = await _context.Camera
            .Include(i => i.Store)
            .Include(i => i.CameraCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (cameraToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Camera>(
            cameraToUpdate,
            "Camera",
            i => i.Brand, i => i.Model,
            i => i.Price, i => i.ReleaseDate, i => i.Store))
            {
                UpdateCameraCategories(_context, selectedCategories, cameraToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateCameraCategories pentru a aplica informatiile din checkboxuri la entitatea Cameras care
            //este editata
            UpdateCameraCategories(_context, selectedCategories, cameraToUpdate);
            PopulateAssignedCategoryData(_context, cameraToUpdate);
            return Page();
        }
    }
}
