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
  }
}