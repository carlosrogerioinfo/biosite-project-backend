using System.Collections.Generic;

namespace Biosite.Core.Response
{
    public class BaseResponseError
    {
        public bool Success { get; set; }
        public IEnumerable<ErrorMessages> Data { get; set; }

        public class ErrorMessages
        {
            public string Property { get; set; }
            public string Message { get; set; }
        }

    }
}
