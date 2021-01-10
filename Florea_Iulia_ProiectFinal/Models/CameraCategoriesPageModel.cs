using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Florea_Iulia_ProiectFinal.Data;


namespace Florea_Iulia_ProiectFinal.Models
{
    public class CameraCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Florea_Iulia_ProiectFinalContext context,
        Camera camera)
        {
            var allCategories = context.Category;
            var cameraCategories = new HashSet<int>(
            camera.CameraCategories.Select(c => c.CameraID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = cameraCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateCameraCategories(Florea_Iulia_ProiectFinalContext context,
        string[] selectedCategories, Camera cameraToUpdate)
        {
            if (selectedCategories == null)
            {
                cameraToUpdate.CameraCategories = new List<CameraCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var cameraCategories = new HashSet<int>
            (cameraToUpdate.CameraCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!cameraCategories.Contains(cat.ID))
                    {
                        cameraToUpdate.CameraCategories.Add(
                        new CameraCategory
                        {
                            CameraID = cameraToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (cameraCategories.Contains(cat.ID))
                    {
                        CameraCategory courseToRemove
                        = cameraToUpdate
                        .CameraCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
