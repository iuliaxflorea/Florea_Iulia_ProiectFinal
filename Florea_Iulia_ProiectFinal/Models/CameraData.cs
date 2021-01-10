using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Florea_Iulia_ProiectFinal.Models
{
    public class CameraData
    {
        public IEnumerable<Camera> Cameras { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<CameraCategory> CameraCategories { get; set; }
    }
}
