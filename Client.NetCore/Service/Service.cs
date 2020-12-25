using Client.NetCore.Infrasructure.Helper;
using Client.NetCore.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.NetCore.Service
{
    public class ServiceLogic :IServiceLogic
    {
        HttpClient client = new HttpClient();
        private  string partnerKey;
        private  string api;
        private  string partnerID;


        public ServiceLogic(IConfiguration config)
        {
            partnerID = config.GetValue<string>("partnerID");
            partnerKey = config.GetValue<string>("partnerKey");
            api = config.GetValue<string>("api"); 

        }

        public async Task<AuthorizationResponse> GetRequestID()
        {
            string uri = $"{api}/Identification/GetRequestID/{partnerID}";
            AuthorizationResponse authorizationResponse = await Helper.ReadAsJsonAsync<AuthorizationResponse>(client, uri, "");

            if (authorizationResponse.OperationResult.operation_code == 0)
                client.DefaultRequestHeaders.Add("X-TOKEN", Helper.GetToken(partnerKey, authorizationResponse.request_id));

            return authorizationResponse;
        }

        public async Task<DocumentCountryResponse> GetCountries(string requestID)
        {
            string token = Helper.GetToken(partnerKey, requestID);

            string uri = $"{api}/Identification/GetDocumentCountries/{requestID}";
            return await Helper.ReadAsJsonAsync<DocumentCountryResponse>(client, uri, token);
        }

        public async Task<DocumentTypeResponse> GetDocumentTypes(string requestID, string documentCountry)
        {
            string token = Helper.GetToken(partnerKey, requestID);

            string uri = $"{api}/Identification/GetDocumentTypes/{requestID}/{documentCountry}";
            return await Helper.ReadAsJsonAsync<DocumentTypeResponse>(client, uri, token);

        }

        public async Task<WidgetResponse> GetWidget(string requestID, string documentCountry, string documentType)
        {

            WidgetRequest widgetRequest = new WidgetRequest();
            widgetRequest.request_id = requestID;
            widgetRequest.country_code = documentCountry;
            widgetRequest.document_type_code = documentType;

            string token = Helper.GetToken(partnerKey, requestID);

            string uri = $"{api}/Identification/GetWidget";
            return await Helper.PostAsJsonAsync<WidgetResponse>(client, uri, widgetRequest, token);

        }

        public async Task<IdentificationDataResponse> GetData(string requestID)
        {
            string token = Helper.GetToken(partnerKey, requestID);

            string uri = $"{api}/Identification/GetIdentificationData/{requestID}/true";
            return await Helper.ReadAsJsonAsync<IdentificationDataResponse>(client, uri, token);
        }

       

    }
}
