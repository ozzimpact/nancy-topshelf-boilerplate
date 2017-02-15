using System;
using Nancy;
using Nancy.Responses;

namespace Host
{
    public class ErrorResponse: JsonResponse
    {
        readonly Error _error;

        private ErrorResponse(Error error)
            : base(error, new DefaultJsonSerializer())
        {
            _error = error;
        }

        public string ErrorMessage => _error.ErrorMessage;
        public string FullException => _error.FullException;
        public string[] Errors => _error.Errors;

        public static ErrorResponse FromMessage(string message)
        {
            return new ErrorResponse(new Error { ErrorMessage = message });
        }

        public static ErrorResponse FromException(Exception ex)
        {
            Exception exception = ex.GetBaseException();

            string summary = exception.Message;

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            Error error = new Error { ErrorMessage = summary, FullException = exception.ToString() };

            ErrorResponse response = new ErrorResponse(error) { StatusCode = statusCode };

            return response;
        }

        public class Error
        {
            public string ErrorMessage { get; set; }

            public string FullException { get; set; }

            public string[] Errors { get; set; }
        }
    }
}
