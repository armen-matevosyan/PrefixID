
namespace PrefixIDClient.NetMVC.Models
{
    public class OperationResult
    {
        public int operation_code { get; set; }
        public string operation_message { get; set; }

        public OperationResult()
        {

        }
        public OperationResult(int operation_code, string operation_message)
        {
            this.operation_code = operation_code;
            this.operation_message = operation_message;
        }

       
    }

    
}
