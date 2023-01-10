using System.Net;

namespace VideoTheque.Core
{
    public class ApiException : Exception
    {
        protected int _httpStatusCode = (int)HttpStatusCode.InternalServerError;
        public ApiException() { }

        public ApiException(string message, int httpStatusCode) : base(message)
        {
            this._httpStatusCode = httpStatusCode;
        }

        public int httpStatusCode
        {
            get { return this._httpStatusCode; }
        }
    }

    public class NotFoundException : ApiException
    {
        public NotFoundException() : base("", (int)HttpStatusCode.NotFound) { }
        public NotFoundException(string message) : base(message, (int)HttpStatusCode.NotFound) { }
    }

    public class InternalErrorException : ApiException
    {
        public InternalErrorException() : base("", (int)HttpStatusCode.InternalServerError) { }
        public InternalErrorException(string message) : base(message, (int)HttpStatusCode.InternalServerError) { }
    }

    public class BadRequestException : ApiException
    {
        public BadRequestException() : base("", (int)HttpStatusCode.BadRequest) { }
        public BadRequestException(string message) : base(message, (int)HttpStatusCode.BadRequest) { }
    }
}
