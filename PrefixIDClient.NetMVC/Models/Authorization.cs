
using System.ComponentModel.DataAnnotations;

namespace PrefixIDClient.NetMVC.Models

{
   
    public class AuthorizationResponse
    {
        public OperationResult OperationResult { get; set; }
        public string request_id { get; set; }
    }

}
