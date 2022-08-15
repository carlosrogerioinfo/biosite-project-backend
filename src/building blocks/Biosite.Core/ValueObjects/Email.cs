using System;
using System.Text.RegularExpressions;

namespace Biosite.Core.ValueObjects
{
    public class Email
    {
        public string EmailAddress { get; private set; }

        //Construtor do EntityFramework
        protected Email() { }

        public Email(string emailAddress)
        {
            if (!IsEmailValid(emailAddress)) throw new Exception("E-mail inválido");
            this.EmailAddress = emailAddress;
        }

        public static bool IsEmailValid(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}
