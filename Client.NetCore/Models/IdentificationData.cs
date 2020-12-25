using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.NetCore.Models
{
    public class IdentificationDataResponse
    {
        public OperationResult OperationResult { get; set; }
        public PersonData person_data { get; set; }
        public DocumentData document_data { get; set; }
        public FaceMatchData facematch_data { get; set; }
        public IdentificationImages identification_images { get; set; }

    }
}
