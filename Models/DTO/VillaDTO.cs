using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

<<<<<<< HEAD
namespace MagicVilla_Web.Models.DTO
=======
namespace MagicVilla_VillaAPI.Models.DTO
>>>>>>> 1d945c3a6169b9fe3aed61bee7a4541b9a52bc3e
{
    public class VillaDTO
    {  
        public int Id {get;set;}

        [Required]
        [MaxLength(30)]
        internal string? name;
        public string? Name {get;set;}
        public string? Details {get;set;}
        public double? Rate {get;set;}
        public int? Sqft {get;set;}
        public int? Occupancy {get;set;}
        public string? ImageUrl {get;set;}
        public string? Amenity {get;set;}
    }
}