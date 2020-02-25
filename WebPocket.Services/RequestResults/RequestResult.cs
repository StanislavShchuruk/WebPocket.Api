using Microsoft.AspNetCore.Http;

namespace WebPocket.Services.RequestResults
{
    public class RequestResult
    {
        public string[] Errors { get; set; }
        public int StatusCode { get; set; }

        public bool IsSuccess => StatusCode == StatusCodes.Status200OK;

        public RequestResult() { StatusCode = StatusCodes.Status400BadRequest; }

        public RequestResult(int statusCode)
        {
            StatusCode = statusCode;
        }

        public void SetStatusOK()
        {
            StatusCode = StatusCodes.Status200OK;
        }

        public void SetStatusBadRequest()
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }

        public void SetStatusInternalServerError()
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }

        public void SetInternalServerError()
        {
            StatusCode = StatusCodes.Status500InternalServerError;
            Errors = new[] { "Internal server error." };
        }
    }

    public class RequestResult<T> : RequestResult
    {
        public T Obj { get; set; }

        public RequestResult() : base() { }

        public RequestResult(int statusCode) : base(statusCode) { }

        public void SetSuccess(T obj)
        {
            this.Obj = obj;
            StatusCode = StatusCodes.Status200OK;
        }
    }
}
