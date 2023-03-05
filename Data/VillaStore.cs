using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Data
{
public static class VillaStore
 {
 public static List<VillaDTO>villaList=new List<VillaDTO>{
        new VillaDTO{Id=1,name="Pool View"},
        new VillaDTO{Id=2,Name="Beach View"}
    
       
    };
}
}
