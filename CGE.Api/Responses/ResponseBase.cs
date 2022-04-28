using System.Collections.Generic;

namespace ServiceLibrary.Responses
{
    public class ResponseBase
    {
        public bool IsSuccess { get; set; }
        public string ResponseText { get; set; }
        public object Data { get; set; }

        public ResponseBase()
        {
            IsSuccess = true;
        }

        public ResponseBase(object data)
        {
            Data = data;
            IsSuccess = true;
        }

        public static ResponseBase CreateResponseError(string errorMessage, string errorLog = "")
        {
            var response = new ResponseBase()
            {
                IsSuccess = false,
                ResponseText = errorMessage,
                
            };

            if(!string.IsNullOrEmpty(errorLog))
            {
            }

            return response;
        }
    }
}