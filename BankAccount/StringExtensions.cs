
namespace BankAccount
{
    public static class StringExtensions
    {

        public static string CompleteWithSpaces(this string source, int length)
        {
            return source.PadRight(length);
        }
    }
}
