
using System.Collections.Generic;

namespace PrefixIDClient.NetMVC.Models
{
    public class DocumentCountryResponse
    {
        public OperationResult OperationResult { get; set; } = new OperationResult();
        public List<DocumentCountry> document_countries { get; set; }
    }

    public class DocumentCountry
    {
        public string country_code { get; set; }
        public string country_name { get; set; }
    }

}
