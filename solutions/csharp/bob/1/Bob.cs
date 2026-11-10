using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        string trimmed = statement.Trim();

        if (trimmed.Length == 0)
            return "Fine. Be that way!";

        bool isQuestion = trimmed.EndsWith("?");
        bool isYelling = trimmed.Any(char.IsLetter) && trimmed == trimmed.ToUpperInvariant();

        if (isYelling && isQuestion)
            return "Calm down, I know what I'm doing!";

        if (isYelling)
            return "Whoa, chill out!";

        if (isQuestion)
            return "Sure.";

        return "Whatever.";
    }
}