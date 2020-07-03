using LevelUpClient.RequestHandler.Interfaces;
using LevelUpDTO;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpClient.RequestHandler
{
    public abstract class RequestHandler<TDTORequest, TDTOResponse> : IRequestHandler<TDTORequest, TDTOResponse>
        where TDTORequest : DTORequest where TDTOResponse : DTOResponse
    {
        protected RequestHandler(string fullAddress)
        {
            FullAddress = fullAddress;
        }

        public TDTORequest DTORequest { get; set; }

        public TDTOResponse DTOResponse { get; set; }
        public string FullAddress { get; set; }

        public abstract TDTORequest RequestBuilder();
        public virtual TDTOResponse Execute(HttpClient httpClient)
        {
            HttpResponseMessage httpResponse = ExecuteMethod(httpClient).GetAwaiter().GetResult();
            string bodyAsStr = "";
            if (httpResponse.IsSuccessStatusCode)
            {
                bodyAsStr = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            Console.WriteLine(
$@"response:
status code: {(int)httpResponse.StatusCode} {httpResponse.StatusCode}
body: {bodyAsStr}");
            return JsonSerializer.Deserialize<TDTOResponse>(bodyAsStr);
        }

        public TDTOResponse Handle(HttpClient httpClient)
        {
            DTORequest = RequestBuilder();
            return Execute(httpClient);
        }

        public async Task<HttpResponseMessage> ExecuteMethod(HttpClient httpClient)
        {
            switch (DTORequest.GetMethodType())
            {
                case LevelUpDTO.DTORequest.Method.GET:
                    return await httpClient.GetAsync(FullAddress);
                case LevelUpDTO.DTORequest.Method.POST:
                    string jsonString = JsonSerializer.Serialize(DTORequest);
                    HttpContent httpContent = new StringContent(jsonString);
                    return await httpClient.PostAsync(FullAddress, httpContent);
                default:
                    throw new NotSupportedException(DTORequest.GetMethodType() + " is not supported yet");
            }
        }
    }
}
