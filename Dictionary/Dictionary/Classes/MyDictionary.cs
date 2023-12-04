using Dictionary.Checks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Classes;

class MyDictionary
{
    public string[] DictionaryType { get; init; }
    public Dictionary<string, List<string>> Dictionary { get; set; }

    public MyDictionary(string[] dictionaryType)
    {
        if (dictionaryType.Length == 2)
        {
            DictionaryType = dictionaryType;
            Dictionary = new();
        }
        else throw new ArgumentException("The array must contain exactly two elements.", nameof(dictionaryType));
    }

    public void AddWord(string word, string translate)
    {
        try
        {
            CheckWord(word, DictionaryType[0]);
            CheckWord(translate, DictionaryType[1]);
        }
        catch (Exception e)
        {
            throw;
        }

        if (!Dictionary.ContainsKey(word))
        {
            Dictionary[word] = new List<string>();
        }
        Dictionary[word].Add(translate);
    }

    public void ReplaceWord(string word, string newWord, string? translation = null)
    {
        try
        {
            if (translation != null)
            {
                try
                {
                    CheckWord(translation, DictionaryType[1]);
                    CheckWord(newWord, DictionaryType[1]);
                }
                catch (Exception e)
                {
                    throw;
                }

                Dictionary[word][Dictionary[word].IndexOf(translation)] = newWord;
            }
            else
            {
                try
                {
                    CheckWord(word, DictionaryType[0]);
                    CheckWord(newWord, DictionaryType[0]);
                }
                catch (Exception e)
                {
                    throw;
                }

                List<string> temp = Dictionary[word];
                Dictionary.Remove(word);
                Dictionary[newWord] = temp;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void RemoveWord(string word, string? translation = null)
    {
        try
        {
            if (translation != null)
            {
                try
                {
                    CheckWord(translation, DictionaryType[1]);
                }
                catch (Exception e)
                {
                    throw;
                }

                if (Dictionary[word].Count > 1)
                    Dictionary[word].Remove(translation);
                else
                    throw new Exception("This is the last translation, it cannot be deleted!");
            }
            else
            {
                try
                {
                    CheckWord(word, DictionaryType[0]);
                }
                catch (Exception e)
                {
                    throw;
                }

                Dictionary.Remove(word);
            }
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public void SearchWord(string word)
    {
        try
        {
            for (int i = 0; i < Dictionary[word].Count; i++)
            {
                Console.WriteLine($"Translation {i + 1}: {Dictionary[word][i]}");
            }
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public void DisplayData()
    {
        foreach (var key in Dictionary.Keys)
        {
            Console.Write($"{key} - ");
            for (int i = 0; i < Dictionary[key].Count; i++)
            {
                Console.Write($"{Dictionary[key][i]}");
                if (i + 1 != Dictionary[key].Count)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private void CheckWord(string word, string language)
    {
        if (!СheckRegex.Сheck(word, language))
        {
            throw new ArgumentException("Invalid data!");
        }
    }

    public override string ToString()
    {
        return $"{DictionaryType[0]} - {DictionaryType[1]}";
    }
}