using System.Collections.Generic;

namespace Biosite.Core.Response
{
    public class ResponseError
    {
        public bool Success { get; set; }
        public ICollection<Error> Errors { get; set; }
    }

    public class Error
    {
        public string Property { get; set; }
        public string Message { get; set; }
    }
}
