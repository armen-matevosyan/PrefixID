using System;
using System.Collections.Generic;
using System.Text;

namespace Client.NetCore.Models

{
    public class DocumentData
    {
        public string country_code { get; set; }
        public string document_type_code { get; set; }
        public string expiry_date { get; set; }
        public string document_number { get; set; }
    }
}
