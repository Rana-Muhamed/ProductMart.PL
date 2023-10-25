using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.PL.ViewModels
{
    public class ApplicationUser :IdentityUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }
    }
}
