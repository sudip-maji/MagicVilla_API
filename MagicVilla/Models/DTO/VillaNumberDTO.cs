using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Models.DTO
{
    public class VillaNumberDTO
    {  
        [Required]
        public int VillaNo{get;set;}
        [Required]
         public int VillaID {get;set;}
        public string SpecialDetails{get;set;}
    }
}