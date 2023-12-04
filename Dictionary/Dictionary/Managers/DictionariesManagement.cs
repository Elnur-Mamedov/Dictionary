using Dictionary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Managers;

class DictionariesManagement
{
    public List<MyDictionary> Dictionaries;
    public List<string[]> DictionaryTypes;

    public DictionariesManagement()
    {
        Dictionaries = new();
        DictionaryTypes = new();
    }

    public void AddNewDictionary(string[] dictionaryType)
    {
        if (dictionaryType.Length != 2)
        {
            throw new Exception("Invalid argument!");
        }

        for (int i = 0; i < Dictionaries.Count; i++)
        {
            if (Dictionaries[i].DictionaryType[0] == dictionaryType[0] && Dictionaries[i].DictionaryType[1] == dictionaryType[1])
                throw new Exception("Such a dictionary already exists");
        }

        Dictionaries.Add(new MyDictionary(dictionaryType));
        DictionaryTypes.Add(dictionaryType);
    }

    public void AddWord(ushort currentDictionary, string word, string translation)
    {
        try
        {
            Dictionaries[currentDictionary].AddWord(word, translation);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void ReplaceWord(ushort currentDictionary, string word, string newWord, string? translation = null)
    {
        try
        {
            if (translation != null)
            {
                Dictionaries[currentDictionary].ReplaceWord(word, newWord, translation);
            }
            else
                Dictionaries[currentDictionary].ReplaceWord(word, newWord);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void RemoveWord(ushort currentDictionary, string word, string? translation = null)
    {
        try
        {
            if (translation != null)
            {
                Dictionaries[currentDictionary].RemoveWord(word, translation);
            }
            else
                Dictionaries[currentDictionary].RemoveWord(word);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void SearchWord(ushort currentDictionary, string word)
    {
        try
        {
            Dictionaries[currentDictionary].SearchWord(word);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void DisplayData(ushort currentDictionary)
    {
        try
        {
            Dictionaries[currentDictionary].DisplayData();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void ExportInCSV()
    {
        try
        {
            using (var writer = new StreamWriter("DictionaryTypes.csv"))
            {
                foreach (var item in DictionaryTypes)
                {
                    writer.WriteLine($"{item[0]}, {item[1]}");
                }
            }

            foreach (var item in Dictionaries)
            {
                string FileName = item.DictionaryType[0] + "-" + item.DictionaryType[1] + ".csv";

                using (var writer = new StreamWriter(FileName, false, Encoding.UTF8))
                {
                    foreach (var pair in item.Dictionary)
                    {
                        string key = pair.Key;
                        string values = string.Join(",", pair.Value);
                        writer.WriteLine($"{key},{values}");
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void ImportInProgram()
    {
        try
        {
            using (var reader = new StreamReader("DictionaryTypes.csv"))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] Types = line.Split(", ");

                    DictionaryTypes.Add(Types);
                }
            }

            for (int i = 0; i < DictionaryTypes.Count; i++)
            {
                string FileName = DictionaryTypes[i][0] + "-" + DictionaryTypes[i][1] + ".csv";
                Dictionaries.Add(new MyDictionary(DictionaryTypes[i]));

                using (var reader = new StreamReader(FileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        string key = parts[0];
                        List<string> values = parts.Skip(1).ToList();

                        Dictionaries[i].Dictionary[key] = values;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public override string ToString()
    {
        StringBuilder ListOfDictionaries = new();

        for (int i = 0; i < DictionaryTypes.Count; i++)
        {
            ListOfDictionaries.Append($"{i + 1}. {DictionaryTypes[i][0]} - {DictionaryTypes[i][1]}\n");
        }

        return ListOfDictionaries.ToString();
    }
}