using PrefixIDClient.NetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrefixIDClient.NetMVC.Infrasructure
{
    public interface IService
    {
        Task<AuthorizationResponse> GetRequestID();
        Task<DocumentCountryResponse> GetCountries(string requestID);
        Task<DocumentTypeResponse> GetDocumentTypes(string requestID, string documentCountry);
        Task<WidgetResponse> GetWidget(string requestID, string documentCountry, string documentType);
        Task<IdentificationDataResponse> GetData(string requestID);
    }
}
