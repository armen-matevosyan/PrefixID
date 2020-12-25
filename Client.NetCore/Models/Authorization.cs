
using System.ComponentModel.DataAnnotations;

namespace Client.NetCore.Models

{
   
    public class AuthorizationResponse
    {
        public OperationResult OperationResult { get; set; }
        public string request_id { get; set; }
    }

}
