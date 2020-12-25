using Client.NetCore.Models;
using System.Threading.Tasks;

namespace Client.NetCore.Service
{
    public interface IServiceLogic
    {
        Task<AuthorizationResponse> GetRequestID();
        Task<DocumentCountryResponse> GetCountries(string requestID);
        Task<DocumentTypeResponse> GetDocumentTypes(string requestID, string documentCountry);
        Task<WidgetResponse> GetWidget(string requestID, string documentCountry, string documentType);
        Task<IdentificationDataResponse> GetData(string requestID);
    }
}
