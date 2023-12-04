using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Classes;

class Favorites
{
    public Dictionary<string, List<string>> FavoritesWords = new();

    public void AddWord(string word, List<string> translations)
    {
        if (FavoritesWords.ContainsKey(word))
        {
            FavoritesWords[word].AddRange(translations);
        }
        else
        {
            FavoritesWords[word] = translations;
        }
    }

    public void RemoveWord(string word)
    {
        if (FavoritesWords.ContainsKey(word))
        {
            FavoritesWords.Remove(word);
        }
        else
            throw new Exception("There is no such word in the dictionary!");
    }

    public void DisplayData()
    {
        Console.WriteLine("Favorite words: ");

        foreach (var key in FavoritesWords.Keys)
        {
            Console.Write($"{key} - ");
            for (int i = 0; i < FavoritesWords[key].Count; i++)
            {
                Console.Write($"{FavoritesWords[key][i]}");
                if (i + 1 != FavoritesWords[key].Count)
                    Console.Write(", ");
            }
            Console.WriteLine("\n");
        }
    }

    public bool CheckFavoriteForEmpty()
    {
        if (FavoritesWords.Count == 0)
        {
            Console.WriteLine("Favorites is empty!");
            return true;
        }
        else
            return false;
    }
}