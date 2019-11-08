using System;

namespace ABD.WEB.Models
{
    public class ErrorViewModel
    {
        //hi
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
