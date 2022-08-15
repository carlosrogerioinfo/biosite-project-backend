namespace Biosite.Core.Response
{
    /// <summary>
    /// Resposta base.
    /// </summary>
    /// <typeparam name="T">Tipo dos dados.</typeparam>
    public class BaseResponse<T> where T : class
    {
        public BaseResponse(T data, bool success)
        {
            Success = success;
            Data = data;
        }

        /// <summary>
        /// Dados.
        /// </summary>
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}