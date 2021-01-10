using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Florea_Iulia_ProiectFinal.Models
{
    public class CameraCategory
    {
        public int ID { get; set; }
        public int CameraID { get; set; }
        public Camera Camera { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
