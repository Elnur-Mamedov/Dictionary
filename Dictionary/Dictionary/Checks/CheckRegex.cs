using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dictionary.Checks;

static class СheckRegex
{
    public static List<Regex> regexes = new List<Regex>()
        {
            new Regex(@"[A-Za-z]{2,}$"), // For English
            new Regex(@"[А-Яа-я]{2,}$"), // For Russia
            new Regex(@"[A-Za-zÄäÖöÜüß]{2,}$"), // For German
            new Regex(@"[ა-ჰ]{2,}$"), // For Georgia
            new Regex(@"[A-Za-zÀ-ÿ]{2,}$"), // For French
            new Regex(@"[A-Za-zÅåÄäÖö]{2,}$"), // For Swedish
            new Regex(@"[\p{IsCJKUnifiedIdeographs}]{2,}$"), // For Chine
            new Regex(@"^[가-힣]{2,}$") // For Korea
        };

    public static List<string> languages = new List<string>() // Default languages, you can also add a language here
        {
            new string("English"),
            new string("Russia"),
            new string("German"),
            new string("Georgia"),
            new string("French"),
            new string("Swedish"),
            new string("Chine"),
            new string("Korea"),
        };

    public static bool Сheck(string word, string language)
    {
        return regexes[languages.IndexOf(language)].IsMatch(word);
    }
}