using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicatonProcess.February2021.Web.Response
{
    public class BasicResponse
    {
        private int _statusCode { get; set; }
        private object _message { get; set; }

        public BasicResponse(int statusCode, object message)
        {
            _statusCode = statusCode;
            _message = message;
        }

        public JsonResult Json()
        {
            return new JsonResult(new { data = _message })
            {
                StatusCode = _statusCode,
            };
        }
    }
}
