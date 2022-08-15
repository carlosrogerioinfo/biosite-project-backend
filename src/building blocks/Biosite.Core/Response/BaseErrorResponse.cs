namespace Biosite.Core.Response
{
    public static class BaseErrorResponse
    {
        public static BaseErrorResponse<T> Create<T>(T data) where T : class
        {
            return new BaseErrorResponse<T>(data);
        }
    }
}