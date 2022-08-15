namespace Biosite.Core.Response
{
    public class BaseErrorResponse<T> where T : class
    {
        public BaseErrorResponse(T data)
        {
            Success = false;
            Errors = data;
        }

        /// <summary>
        /// Dados.
        /// </summary>
        public bool Success { get; set; }
        public T Errors { get; set; }
    }
}