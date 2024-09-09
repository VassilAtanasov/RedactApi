using System.Text.RegularExpressions;

namespace RedactApi.Services;

public class RedactionService
{
    private readonly string[] _redactionWords;

    public RedactionService(string[] redactionWords)
    {
        _redactionWords = redactionWords.Select(w => w.ToLower()).ToArray();
    }

    public string RedactText(string input)
    {
        foreach (var word in _redactionWords)
        {
            input = Regex.Replace(input, $"\\b{word}\\b", "REDACTED", RegexOptions.IgnoreCase);
        }
        return input;
    }
}
