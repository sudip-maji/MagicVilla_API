
namespace MagicVilla_Web.Services{
    public class BaseService:IBaseService
    {
        public APIResponse responseModel{get;set;}
        public IHttpClientFactory httpClient{get;set;}
        public BaseService(IHttpClientFactory httpClient){
            this.responseModel=new();
            this.httpClient=httpClient;
        }
        async Task<T>SendAsync<T>(APIRequest aPIRequest){
            try{
                var client =httpClient.CreateClient("MagicAPI");
                HttpRequestMessage =message =new HttpRequestMessage();
                message.Headers.Add("Accept","application/json");
                message.RequestUri=new Uri(aPIRequest.Url);
                if(aPIRequest.Data!=null){
                    message.Content=new stringContent(JsonConvert.SerializeObject(aPIRequest.Data),
                    Encoding.UTF8,"application/json");
                }
                switch(aPIRequest.ApiType){
                    case SD.ApiRequest.POST:
                    message.Method=HttpMethod.Post;
                    break;
                    case SD.ApiRequest.PUT:
                    message.Method=HttpMethod.Put;
                    break;
                    case SD.ApiRequest.DELETE:
                    message.Method=HttpMethod.Delete;
                    break;
                    case SD.ApiRequest.GET:
                    message.Method=HttpMethod.Get;
                    break;

                }
                HttpResponseMessage apiResponse=null;
                apiResponse=await client.SendAsync(message);
                var apiContent=await apiResponse.Content.ReadAsStringAsync();
                var APIResponse=JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;
            }
            catch(Exception e){
                var dto = new APIResponse{
                    ErrorMessages=new List<string>{Convert.ToString(e.Message)},
                    IsSuccess=false
                };
                var APIResponse=JsonConvert.SerializeObject(dto);
                var APIResponse=JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }
            
        }
        
    }
}
