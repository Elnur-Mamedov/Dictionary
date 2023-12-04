using Dictionary.Managers;

MenuManagement Menu = new();

try
{
    Menu.ImportInProgram();
}
catch (Exception e) { };

while (true)
{
    int choice = -1;

    Menu.SelectCurrentDictionary();
    Console.Clear();

    while (choice != 9)
    {
        choice = 0;
        Menu.DisplayCurrentDictioany();

        Console.WriteLine("1. Add Word or Translation.\n" +
            "2. Replace Word or Translation.\n" +
            "3. Remove Word or Translation.\n" +
            "4. Search Word.\n" +
            "5. Display dictionary data\n" +
            "6. Add favorite word.\n" +
            "7. Remove favorite word.\n" +
            "8. Display favorite words.\n" +
            "9. Go back.\n" +
            "10. Exit and Save.\n" +
            "(If you do not save and close the program, the changes will not be saved)");

        Menu.CheckChoice(1, 10, ref choice);

        switch (choice)
        {
            case 1:
                Console.Clear();

                Menu.AddWord();
                break;
            case 2:
                Console.Clear();
                if (Menu.CheckDictionaryForEmpty())
                {
                    Thread.Sleep(2000);
                    continue;
                }

                Menu.ReplaceWord();
                break;
            case 3:
                Console.Clear();
                if (Menu.CheckDictionaryForEmpty())
                {
                    Thread.Sleep(2000);
                    continue;
                }

                Menu.DeleteWord();
                break;
            case 4:
                Console.Clear();
                if (Menu.CheckDictionaryForEmpty())
                {
                    Thread.Sleep(2000);
                    continue;
                }

                Menu.SearchWord();
                break;
            case 5:
                Console.Clear();
                if (Menu.CheckDictionaryForEmpty())
                {
                    Thread.Sleep(2000);
                    continue;
                }

                Menu.DisplayDictionaryData();
                break;
            case 6:
                Console.Clear();

                Menu.AddFavoriteWord();
                break;
            case 7:
                Console.Clear();
                if (Menu.Favorites.CheckFavoriteForEmpty())
                {
                    Thread.Sleep(2000);
                    continue;
                }

                Menu.RemoveFavoriteWord();
                break;
            case 8:
                Console.Clear();
                if (Menu.Favorites.CheckFavoriteForEmpty())
                {
                    Thread.Sleep(2000);
                    continue;
                }

                Menu.DisplayFavoriteWords();
                break;
            case 9:
                Console.Clear();
                break;
            case 10:
                Menu.ExportInCSV();
                Environment.Exit(0);
                break;
        }
    }
}