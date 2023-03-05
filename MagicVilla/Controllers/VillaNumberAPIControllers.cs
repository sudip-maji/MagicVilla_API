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
{   [Route("api/VillaNumberAPI")]
    [ApiController]
    public class VillaNumberAPIControllers : ControllerBase
    {
      private readonly IVillaNumberRepository _dbVillaNumber;
      private readonly IVillaRepository _dbVilla;

      protected APIResponse _response; 
      private readonly IMapper _mapper;
      public VillaNumberAPIControllers(IVillaNumberRepository dbVillaNumber,IMapper mapper, IVillaRepository dbVilla){
        _dbVillaNumber =dbVillaNumber;
        _mapper=mapper;
        this._response=new();
        _dbVilla=dbVilla;
      }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
      public async Task<ActionResult <APIResponse>> GetVillaNumbers(){
        IEnumerable<VillaNumber>villaNumberList=await _dbVillaNumber.GetAll();
        _response.Result=_mapper.Map<List<VillaNumberDTO>>(villaNumberList);
        _response.StatusCode=HttpStatusCode.OK;
        return Ok(_response);
      }
      [HttpGet("id",Name="GetVillaNumber")]
      [ProducesResponseType(200)]
      [ProducesResponseType(404)]
      [ProducesResponseType(400)]
   public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
      {
        if(id ==0){
          return BadRequest();
        }
        var villaNumber=await _dbVillaNumber.Get(u=>u.VillaNo==id);
        if(villaNumber==null){  
          return NotFound();
        }
        _response.Result=_mapper.Map<VillaNumberDTO>(villaNumber);
        _response.StatusCode=HttpStatusCode.OK;
        return Ok(_response);
      }
      [HttpPost]
      [ProducesResponseType(StatusCodes.Status201Created)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      
      public async Task<ActionResult<APIResponse>>CreateVillaNumber([FromBody]VillaNumberCreateDTO createDTO){
        if (await _dbVillaNumber.Get(u=>u.VillaNo==createDTO.VillaNo)!=null){
          ModelState.AddModelError("CustomError","VillaNumber aready exixts!");
          return BadRequest(ModelState);
        }
        if(await _dbVilla.Get(U=>U.Id==createDTO.VillaID)==null){
          ModelState.AddModelError("CustomError","VillaID id Invalid");
          return BadRequest(ModelState);
        }
        if(createDTO==null){
          return BadRequest(createDTO);
        }

        VillaNumber villaNumber=_mapper.Map<VillaNumber>(createDTO);

        await _dbVillaNumber.Create(villaNumber);
        _response.Result=_mapper.Map<List<VillaNumberDTO>>(villaNumber);
        _response.StatusCode=HttpStatusCode.Created;

        return CreatedAtRoute("GetVilla " , new {id=villaNumber.VillaNo },_response);
      }
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      [HttpDelete("id",Name="DeleteVillaNumber")]
       
      public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id){
        if(id==0){
          return BadRequest();

        }
        var villaNumber=await _dbVillaNumber.Get(u=>u.VillaNo==id);
        if(villaNumber==null){
          return NotFound();
        }
        await _dbVillaNumber.Remove(villaNumber);
        _response.StatusCode=HttpStatusCode.NoContent;
        _response.IsSuccess=true;
        return Ok(_response); 
      }
      [HttpPut("id",Name = "UpdateVillaNumber")]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id,[FromBody]VillaNumberUpdateDTO updateDTO){
         if(updateDTO == null || id!=updateDTO.VillaNo){
          return BadRequest();
         }
         if(await _dbVilla.Get(U=>U.Id==updateDTO.VillaID)==null){
          ModelState.AddModelError("CustomError","VillaID id Invalid");
          return BadRequest(ModelState);
        }
         VillaNumber model =_mapper.Map<VillaNumber>(updateDTO);
         await _dbVillaNumber.Update(model);
        _response.StatusCode=HttpStatusCode.NoContent;
        _response.IsSuccess=true;
        return Ok(_response);
        

      }
    }
}
