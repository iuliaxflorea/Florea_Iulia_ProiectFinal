using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Florea_Iulia_ProiectFinal.Data;
using Florea_Iulia_ProiectFinal.Models;

namespace Florea_Iulia_ProiectFinal.Pages.Cameras
{
    public class CreateModel : CameraCategoriesPageModel
    {
        private readonly Florea_Iulia_ProiectFinal.Data.Florea_Iulia_ProiectFinalContext _context;

        public CreateModel(Florea_Iulia_ProiectFinal.Data.Florea_Iulia_ProiectFinalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StoreID"] = new SelectList(_context.Set<Store>(), "ID", "StoreName");

            var camera = new Camera();
            camera.CameraCategories = new List<CameraCategory>();
            PopulateAssignedCategoryData(_context, camera);

            return Page();

        }

        [BindProperty]
        public Camera Camera { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCamera = new Camera();
            if (selectedCategories != null)
            {
                newCamera.CameraCategories = new List<CameraCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CameraCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newCamera.CameraCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Camera>(
            newCamera,
            "Camera",
            i => i.Brand, i => i.Model,
            i => i.Price, i => i.ReleaseDate, i => i.StoreID))
            {
                _context.Camera.Add(newCamera);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newCamera);
            return Page();
        }

    }
}
