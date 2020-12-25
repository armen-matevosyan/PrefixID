using System.Collections.Generic;

namespace Client.NetCore.Models
{

    public class DocumentTypeResponse
    {
        public OperationResult OperationResult { get; set; }
        public List<DocumentType> document_types { get; set; }
    }

    public class DocumentType
    {
        public string document_type_code { get; set; }
        public string document_type_name { get; set; }
        public int document_sides { get; set; }
    }
}
