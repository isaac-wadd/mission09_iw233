using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookApp.Models {
    public class Book {
        [Key]
        [Required]
        public int bookID { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string author { get; set; }

        [Required]
        public string publisher { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public ushort classificationID { get; set; }
        public Classification classification { get; set; }

        [Required]
        public ushort categoryID { get; set; }
        public Category category { get; set; }

        [Required]
        public ushort pageCount { get; set; }

        [Required]
        public float price { get; set; }
    }
}
