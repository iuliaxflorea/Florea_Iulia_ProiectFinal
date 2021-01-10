using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Florea_Iulia_ProiectFinal.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public ICollection<CameraCategory> CameraCategories { get; set; }
    }
}
