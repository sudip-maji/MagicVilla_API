using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IService;
namespace MagicVilla_Web.Services{
    public class VillaNumberService:BaseService,IVillaNumberService{
        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;
        public VillaNumberService(IHttpClientFactory clientFactory,IConfiguration configuration){
            _clientFactory=clientFactory;
            villaUrl=configuration.GETValue<string>("ServiceUrls:VillaAPI");
        }
        public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto){
            return SendAsync<T>(new APIRequest(){
            ApiType=SD.ApiType.POST,
            Data=dto,
            Url=villaUrl+"/api/villaNumberAPI"
         } );
        }
        public Task<T> DeleteAsync<T>(int id){
            return SendAsync<T>(new APIRequest(){
            ApiType=SD.ApiType.DELETE,
            Url=villaUrl+"/api/villaNumberAPI/"+id
         } );
        }
        public Task<T> GetAllAsync<T>(){
            return SendAsync<T>(new APIRequest(){
            ApiType=SD.ApiType.GET,
            Data=dto,
            Url=villaUrl+"/api/villaNumberAPI"
         } );
        }
        public Task<T> GetAsync<T>(int id){
            return SendAsync<T>(new APIRequest(){
            ApiType=SD.ApiType.GET,
            Url=villaUrl+"/api/villaNumberAPI"
         } );
        }
        public Task<T> uPDATEAsync<T>(VillaNumberCreateDTO dto){
            return SendAsync<T>(new APIRequest(){
            ApiType=SD.ApiType.PUT,
            Url=villaUrl+"/api/villaNumberAPI/"+dto.VillaNO
         } );
        }
    }
}