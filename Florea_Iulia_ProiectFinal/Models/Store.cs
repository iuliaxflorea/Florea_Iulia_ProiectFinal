using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Florea_Iulia_ProiectFinal.Models
{
    public class Store
    {
        public int ID { get; set; }
        [Required]
        public string StoreName { get; set; }
        public ICollection<Camera> Cameras { get; set; }
    }
}
