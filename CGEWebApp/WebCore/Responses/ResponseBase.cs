namespace WebCore.Responses
{
    public class ResponseBase
    {
        public bool Status { get; set; }
        public bool IsSessionExpired { get; set; }
        public string ResponseText { get; set; }
        public object Data { get; set; }
        public string Url { get; set; }

        public ResponseBase()
        {
            Status = false;
            IsSessionExpired = false;
        }

        public ResponseBase(object data)
        {
            Status = true;
            IsSessionExpired = false;
            Data = data;
        }

        public ResponseBase Error(string errorMessage)
        {
            Status = false;
            ResponseText = errorMessage;
            return this;
        }

        public static ResponseBase ResponseError(string errorMessage)
        {
            return new ResponseBase()
            {
                Status = false,
                ResponseText = errorMessage
            };
        }

        public static ResponseBase ResponseError(string errorMessage, object data = null)
        {
            return new ResponseBase()
            {
                Status = false,
                ResponseText = errorMessage,
                Data = data,
            };
        }

    }
}
