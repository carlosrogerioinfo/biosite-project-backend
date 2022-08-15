namespace Biosite.Core.Commands.Response
{
    public class AuthenticationResponse : ICommandResult
    {
        public AuthenticationResponse()
        {

        }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
