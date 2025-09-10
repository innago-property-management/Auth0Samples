namespace Auth0Client;

using System.Text;

internal static class LuceneHelpers
{
    public static string SanitizeSearchTerm(this string term)
    {
        if (string.IsNullOrEmpty(term))
        {
            return string.Empty;
        }

        StringBuilder sb = new();

        foreach (char c in term)
        {
            switch (c)
            {
                case '\\':
                case '+':
                case '-':
                case '!':
                case '(':
                case ')':
                case ':':
                case '^':
                case '[':
                case ']':
                case '"':
                case '{':
                case '}':
                case '~':
                case '*':
                case '?':
                case '|':
                case '&':
                case '/':
                    sb.Append('\\');
                    break;
            }

            sb.Append(c);
        }

        return sb.ToString();
    }
}
