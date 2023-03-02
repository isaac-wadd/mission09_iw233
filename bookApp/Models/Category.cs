using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookApp.Models {
    public class Category {
        [Key]
        [Required]
        public ushort categoryID { get; set; }
        public string categoryName { get; set; }
    }
}