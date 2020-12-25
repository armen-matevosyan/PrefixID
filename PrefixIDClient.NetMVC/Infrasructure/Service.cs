using Microsoft.Extensions.Configuration;
using PrefixIDClient.NetMVC.Models;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PrefixIDClient.NetMVC.Infrasructure
{
    public class Service :IService
    {
        HttpClient client = new HttpClient();
        private  string partnerKey;
        private  string api;
        private  string partnerID;


        public Service(IConfiguration config)
        {
            partnerID = config.GetValue<string>("partnerID");
            partnerKey = config.GetValue<string>("partnerKey");
            api = config.GetValue<string>("api"); //https://prefixid.com/api

        }

        public async Task<AuthorizationResponse> GetRequestID()
        {
            string uri = string.Format("{0}/{1}/{2}", api, "Identification/GetRequestID", partnerID);
            AuthorizationResponse authorizationResponse = await Helper.ReadAsJsonAsync<AuthorizationResponse>(client, uri, "");

            if (authorizationResponse.OperationResult.operation_code == 0)
                client.DefaultRequestHeaders.Add("X-TOKEN", GetToken(partnerKey, authorizationResponse.request_id));

            return authorizationResponse;
        }

        public async Task<DocumentCountryResponse> GetCountries(string requestID)
        {
            string token = GetToken(partnerKey, requestID);

            string uri = string.Format("{0}/{1}/{2}", api, "Identification/GetDocumentCountries", requestID);
            return await Helper.ReadAsJsonAsync<DocumentCountryResponse>(client, uri, token);
        }

        public async Task<DocumentTypeResponse> GetDocumentTypes(string requestID, string documentCountry)
        {
            string token = GetToken(partnerKey, requestID);

            string uri = string.Format("{0}/{1}/{2}/{3}", api, "Identification/GetDocumentTypes", requestID, documentCountry);
            return await Helper.ReadAsJsonAsync<DocumentTypeResponse>(client, uri, token);

        }

        public async Task<WidgetResponse> GetWidget(string requestID, string documentCountry, string documentType)
        {

            WidgetRequest widgetRequest = new WidgetRequest();
            widgetRequest.request_id = requestID;
            widgetRequest.country_code = documentCountry;
            widgetRequest.document_type_code = documentType;

            string token = GetToken(partnerKey, requestID);

            string uri = string.Format("{0}/{1}", api, "Identification/GetWidget");
            return await Helper.PostAsJsonAsync<WidgetResponse>(client, uri, widgetRequest, token);

        }

        public async Task<IdentificationDataResponse> GetData(string requestID)
        {
            string token = GetToken(partnerKey, requestID);

            string uri = string.Format("{0}/{1}/{2}/{3}", api, "Identification/GetIdentificationData", requestID, true);
            return await Helper.ReadAsJsonAsync<IdentificationDataResponse>(client, uri, token);
        }

        private string GetToken(string partner_key, string request_id)
        {
            string hashBase64 = "";

            byte[] message = Encoding.UTF8.GetBytes(request_id);
            byte[] keyByte = Encoding.UTF8.GetBytes(partner_key);

            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(message);
                hashBase64 = Convert.ToBase64String(hashmessage);
            }

            return hashBase64;
        }

    }
}
