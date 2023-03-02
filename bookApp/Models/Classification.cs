using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookApp.Models {
    public class Classification {
        [Key]
        [Required]
        public ushort classificationID { get; set; }
        public string classificationName { get; set; }
    }
}