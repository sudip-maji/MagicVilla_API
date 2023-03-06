using AutoMapper;
using MagiVilla_Web.Services.IServices;
namespace MagicVilla_Web.Controllers{
  public class VillaController:Controller{
    private readonly IVillaService _villaService;
    private readonly IMapper _mapper;
    public  VillaController(IVillaService villaService,IMapper mapper){
      _villaService=villaService;
      _mapper=mapper;
    }
    public async Task<IActionResult>IndexVilla(){
      List<VillaDTO>list =new();
      var response =await _villaService.GETAllAsync<APIResopnse>();
      if(response!=null && response.IsSuccess){
        list=JsonConvert.DeserializeObject<list<VillaDTO>>(Convert.Tostring(response.Result));
      }
      return View(list);
    }
    public async Task<IActionResult>CreateVilla(){
      
      return View();
    }
    [HttpPost]
    [ValidateAntiForeignToken]
    public async Task<IActionResult>CreateVilla(VillaCreateDTO model){
      if(ModelState.IsValid){
        var response =await _villaService.CreateAsync<APIResopnse>(model);
        if(response!=null && response.IsSuccess){
        return RedirectToAction(nameof(IndexVilla));
      }
      }
      return View(model);
    }
    public async Task<IActionResult>UpdateVilla(int villaId){
      var response =await _villaService.GetAsync<APIResopnse>(villaId);
        if(response!=null && response.IsSuccess){
        VillaDTO model=JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
        return View(_mapper.Map<VillaUpdateDTO>(model));
      }
      
      return NotFound();
    }
    [HttpPost]
    [ValidateAntiForeignToken]
    public async Task<IActionResult>UpdateVilla(VillaUpdateDTO model){
      if(ModelState.IsValid){
        var response =await _villaService.UpdateAsync<APIResopnse>(model);
        if(response!=null && response.IsSuccess){
        return RedirectToAction(nameof(IndexVilla));
      }
      }
      return View(model);
    }
    public async Task<IActionResult>DeleteVilla(int villaId){
      var response =await _villaService.GetAsync<APIResopnse>(villaId);
        if(response!=null && response.IsSuccess){
        VillaDTO model=JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
        return View(model);
      }
      
      return NotFound();
    }
    [HttpPost]
    [ValidateAntiForeignToken]
    public async Task<IActionResult>UpdateVilla(VillaDTO model){
      
        var response =await _villaService.DeleteAsync<APIResopnse>(model.Id);
        if(response!=null && response.IsSuccess){
        return RedirectToAction(nameof(IndexVilla));
      }
      return View(model);
    }
  }
}