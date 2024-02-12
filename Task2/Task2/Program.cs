using System.Text.RegularExpressions;


static class Program
{
    static void Main()
    {
        Console.WriteLine("Введите путь до файла, в котором нужно посчтитать слова:");
        var path = Console.ReadLine();
        string? fileText = FileOpen(path);

        if (fileText is null)
        {
            return;
        }
        
        Console.WriteLine("Введите путь до файла, в который нужно записать посчитанные данные:");
        path = Console.ReadLine();
        WriteToFile(path, WordsCount(fileText));
    }

    static Dictionary<string, int> WordsCount(string text)
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        string[] words = Regex.Split(text, @"\W+");

        foreach (var word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                string lowerCaseWord = word.ToLower();

                if (wordCount.ContainsKey(lowerCaseWord))
                {
                    wordCount[lowerCaseWord]++;
                }
                else
                {
                    wordCount.Add(lowerCaseWord, 1);
                }
            }
        }

        return wordCount.OrderByDescending(pair => pair.Value)
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    static void WriteToFile(string filePath, Dictionary<string, int> Count)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var it in Count)
            {
                writer.WriteLine($"{it.Key.PadRight(20)}\t\t{it.Value}");
            }
        }
        
        Console.WriteLine("Данные успешно записаны в файл!");
    }

    static string? FileOpen(string filePath)
    {
        try
        {
            string text = File.ReadAllText(filePath);
            return text;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при открытии файла: {ex.Message}");
            return null;
        }
    }
}