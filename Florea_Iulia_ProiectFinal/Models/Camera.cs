using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Florea_Iulia_ProiectFinal.Models
{
    public class Camera
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        public string Brand { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Numele modelului trebuie sa contina doar litere si cifre."), Required, StringLength(50, MinimumLength = 1)]
        public string Model { get; set; }
        [Range(1, 10000)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int StoreID { get; set; }
        public Store Store { get; set; }
        public ICollection<CameraCategory> CameraCategories { get; set; }
    }
}
