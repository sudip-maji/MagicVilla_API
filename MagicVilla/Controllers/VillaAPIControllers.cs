using System.Collections;
using System.Net;
using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MagicVilla_VillaAPI.Controllers
{   [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
      private readonly IVillaRepository _dbVilla;
      // private readonly ApplicationDBContext _db;
      protected APIResponse _response; 
      private readonly IMapper _mapper;
      // private readonly IVillaRepository _dbVilla;
      public VillaAPIController(IVillaRepository dbVilla,IMapper mapper){
        _dbVilla =dbVilla;
        _mapper=mapper;
        this._response=new();
      }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
      public async Task<ActionResult <APIResponse>> GetVillas(){
        // _logger.LogInformation("Getting All Villas");
        // return Ok(_db.Villas.ToList());
        IEnumerable<Villa>villaList=await _dbVilla.GetAll();
        _response.Result=_mapper.Map<List<VillaDTO>>(villaList);
        _response.StatusCode=HttpStatusCode.OK;
        // return Ok(_mapper.Map<List<VillaDTO>>(villaList));
        return Ok(_response);
      }
      [HttpGet("id",Name="GetVilla")]
      [ProducesResponseType(200)]
      [ProducesResponseType(404)]
      [ProducesResponseType(400)]
   public async Task<ActionResult<APIResponse>> GetVilla(int id)
      {
        if(id ==0){
          // /_logger.LogError("Get Villa Error with Id "+Id);
          return BadRequest();
        }
        var villa=await _dbVilla.Get(u=>u.Id==id);
        if(villa==null){  
          return NotFound();
        }
        _response.Result=_mapper.Map<VillaDTO>(villa);
        _response.StatusCode=HttpStatusCode.OK;
        // return Ok(_mapper.Map<VillaDTO>(villa));
        return Ok(_response);
        // return Ok(_mapper.Map<VillaDTO>(villa));
      }
      [HttpPost]
      [ProducesResponseType(StatusCodes.Status201Created)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      
      public async Task<ActionResult<APIResponse>>CreateVilla([FromBody]VillaCreateDTO createDTO){
        // if(!ModelState.IsValid){
        //   return BadRequest(ModelState);
        // }
        if (await _dbVilla.Get(u=>u.Name.ToLower()==createDTO.Name.ToLower())!=null){
          ModelState.AddModelError("CustomError","Villa aready exixts!");
          return BadRequest(ModelState);
        }
        if(createDTO==null){
          return BadRequest(createDTO);
        }
        // if(villaDTO.Id>0){
        //   return StatusCode(StatusCodes.Status500InternalServerError);
        // }
        Villa villa=_mapper.Map<Villa>(createDTO);
        // Villa model =new(){
        //   // Id=villaDTO.Id,
        //   Name=createDTO.Name,
        //   Details=createDTO.Details,
        //   Rate=createDTO.Rate,
        //   Sqft=createDTO.Sqft,
        //   Occupancy=createDTO.Occupancy,
        //   ImageUrl=createDTO.ImageUrl,
        //   Amenity=createDTO.Amenity
        // };
        // villaDTO.Id=VillaStore.villaList.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
        // await _db.Villas.AddAsync(model);
        // await _db.SaveChangesAsync();
        await _dbVilla.Create(villa);
        _response.Result=_mapper.Map<List<VillaDTO>>(villa);
        _response.StatusCode=HttpStatusCode.Created;
        // return Ok(_response);
        return CreatedAtRoute("GetVilla " , new {id=villa.Id},_response);
      }
      

      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [HttpDelete("id",Name="DeleteVilla")]
       
      public async Task<ActionResult<APIResponse>> DeleteVilla(int id){
        if(id==0){
          return BadRequest();

        }
        var villa=await _dbVilla.Get(u=>u.Id==id);
        if(villa==null){
          return NotFound();
        }
        await _dbVilla.Remove(villa);
        // await _db.SaveChangesAsync();
        // _response.Result=_mapper.Map<VillaDTO>(villa);
        _response.StatusCode=HttpStatusCode.NoContent;
        _response.IsSuccess=true;
        return Ok(_response); 
      }
      [HttpPut("id",Name = "UpdateVilla")]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<ActionResult<APIResponse>> UpdateVillaAsync(int id,[FromBody]VillaUpdateDTO updateDTO){
         if(updateDTO == null || id!=updateDTO.Id){
          return BadRequest();
         }
         Villa model =_mapper.Map<Villa>(updateDTO);
        //  Villa model =new(){
        //   Id=updateDTO.Id,
        //   Name=updateDTO.Name,
        //   Details=updateDTO.Details,
        //   Rate=updateDTO.Rate,
        //   Sqft=updateDTO.Sqft,
        //   Occupancy=updateDTO.Occupancy,
        //   ImageUrl=updateDTO.ImageUrl,
        //   Amenity=updateDTO.Amenity
        // };
         await _dbVilla.Update(model);
        //  await _db.SaveChangesAsync();
        //  _response.Result=_mapper.Map<VillaDTO>(model);
        _response.StatusCode=HttpStatusCode.NoContent;
        _response.IsSuccess=true;
        // return NoContent();
        return Ok(_response);
        

      }
      [HttpPatch("id",Name = "UpdatePartialVilla")]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async  Task<IActionResult> UpdatePartialVilla(int id,JsonPatchDocument<VillaUpdateDTO>patchDTO){
        if(patchDTO == null ||  id==0){
          return BadRequest();
        }
        var villa=await _dbVilla.Get(u=>u.Id==id,tracked: false);  
        // villa.Name= "new name";
        // _db.SaveChanges();
        VillaUpdateDTO villaDTO=_mapper.Map<VillaUpdateDTO>(villa);
        //  VillaUpdateDTO villaDTO =new(){
        //   Id=villa.Id,
        //   Name=villa.Name,
        //   Details=villa.Details,
        //   Rate=villa.Rate,
        //   Sqft=villa.Sqft,
        //   Occupancy=villa.Occupancy,
        //   ImageUrl=villa.ImageUrl,
        //   Amenity=villa.Amenity
        // };
        if(villa == null){
          return BadRequest();
        }
        patchDTO.ApplyTo(villaDTO, ModelState);
        Villa model=_mapper.Map<Villa>(villaDTO);
        //  Villa model =new Villa(){
        //   Id=villaDTO.Id,
        //   Name=villaDTO.Name,
        //   Details=villaDTO.Details,
        //   Rate=villaDTO.Rate,
        //   Sqft=villaDTO.Sqft,
        //   Occupancy=villaDTO.Occupancy,
        //   ImageUrl=villaDTO.ImageUrl,
        //   Amenity=villaDTO.Amenity
        // };
         await _dbVilla.Update(model);
        //  await _db.SaveChangesAsync();
        if(!ModelState.IsValid){
          return BadRequest(ModelState);
        }
        return NoContent();
      }
      

    }
}
