using System.Linq;

namespace Biosite.Core.Extensions
{
    public static class StringExtensionTools
    {

        public static string OnlyNumbers(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }

    }
}