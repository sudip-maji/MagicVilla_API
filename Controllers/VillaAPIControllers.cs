using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MagicVilla_VillaAPI.Controllers
{   [Route("api/VillAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
      private readonly ILogger<VillaAPIController> _logger;
       public VillaAPIController(ILogger<VillaAPIController> logger)
    {
      _logger =logger;
    }
        private int id;

        [HttpGet]
      public ActionResult <IEnumerable<VillaDTO>> GetVillas(){
        _logger.LogInformation("Getting All Villas");
        return Ok(VillaStore.villaList);
      }
      [HttpGet("Id",Name="GetVilla")]
      [ProducesResponseType(200)]
      [ProducesResponseType(404)]
      [ProducesResponseType(400)]
   public ActionResult<VillaDTO> GetVilla(int Id)
      {
        if(id ==0){
          _logger.LogError("Get Villa Error with Id "+Id);
          return BadRequest();
        }
        var villa=VillaStore.villaList.FirstOrDefault(u=>u.Id==id);
        if(villa==null){
          return NotFound();
        }
        return Ok(villa);
      }
      [HttpPost]
      [ProducesResponseType(200)]
      [ProducesResponseType(404)]
      [ProducesResponseType(400)]
      
      public ActionResult<VillaDTO>CreateVilla([FromBody]VillaDTO villaDTO){
        // if(!ModelState.IsValid){
        //   return BadRequest(ModelState);
        // }
        if (VillaStore.villaList.FirstOrDefault(u=>u.Name.ToLower()==villaDTO.Name.ToLower())!=null){
          ModelState.AddModelError("CustomError","Villa aready exixts!");
          return BadRequest(ModelState);
        }
        if(villaDTO==null){
          return BadRequest(villaDTO);
        }
        if(villaDTO.Id>0){
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
        villaDTO.Id=VillaStore.villaList.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
        VillaStore.villaList.Add(villaDTO);
        return CreatedAtRoute("GetVilla " , new {id=villaDTO.Id},villaDTO);
      }
      
      [HttpDelete("Id",Name="DeleteVilla")]
       [ProducesResponseType(204)]
      [ProducesResponseType(404)]
      [ProducesResponseType(400)]
      public IActionResult DeleteVilla(int id){
        if(id==0){
          return BadRequest();

        }
        var villa=VillaStore.villaList.FirstOrDefault(u=>u.Id==id);
        if(villa==null){
          return NotFound();
        }
        VillaStore.villaList.Remove(villa);
        return NoContent();
      }
    }
}
