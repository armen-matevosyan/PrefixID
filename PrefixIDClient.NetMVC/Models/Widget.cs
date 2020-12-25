using System;
using System.Collections.Generic;
using System.Text;

namespace PrefixIDClient.NetMVC.Models
{
    public class Widget
    {
        public string request_id { get; set; }
        public string document_type_code { get; set; }
        public string country_code { get; set; }
        public string partner_key { get; set; }
        public string back_url { get; set; }

    }

    public class WidgetRequest
    {
        public string request_id { get; set; }
        public string document_type_code { get; set; }
        public string country_code { get; set; }
        public string back_url { get; set; }

    }

    public class WidgetResponse
    {
        public OperationResult OperationResult { get; set; }
        public string url { get; set; }
        public string key { get; set; }

    }
}
