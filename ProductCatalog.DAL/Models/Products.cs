using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DAL.Models
{
    public class Products
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; } // Unique identifier for the product
        [MaxLength(50)]
        public string Name { get; set; } // Name of the product
            public DateTime CreationDate { get; set; } // Date when the product was created

            // Foreign Key for the user who created the product
            //public string CreatedByUserId { get; set; }

            public DateTime StartDate { get; set; } // Date when the product becomes available
            public TimeSpan Duration { get; set; } // Duration for which the product is available
            public int Price { get; set; } // Price of the product
        public int? CategoriesId { get; set; }
        public Categories Categories { get; set; }

        
    }
}
