using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        // Слова: послідовності літер, які можуть містити апострофи (наприклад, "It's")
        var words = Regex.Matches(phrase, @"[A-Za-z]+(?:'[A-Za-z]+)*");

        return string.Concat(
            words.Select(w => char.ToUpperInvariant(w.Value[0])));
    }
}