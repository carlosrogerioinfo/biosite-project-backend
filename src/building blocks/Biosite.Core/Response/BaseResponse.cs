namespace Biosite.Core.Response
{
    public static class BaseResponse
    {
        public static BaseResponse<T> Create<T>(T data, bool success) where T : class
        {
            return new BaseResponse<T>(data, success);
        }
    }
}