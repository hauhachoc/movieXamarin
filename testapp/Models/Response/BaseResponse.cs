using System;
namespace testapp.Models.Response
{
    public class BaseResponse
    {
        public Boolean error { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public BaseResponse()
        {
        }
    }
}
