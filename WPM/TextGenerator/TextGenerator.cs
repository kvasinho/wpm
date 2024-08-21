
namespace WPM.TextGenerator;

public interface ITextGeneratorService
{
    ICollection<string> ReadFromFile(string filePath);
    string GenerateRandomText(ICollection<string> words, int count = 300);

    string GenerateRandomTextFromFile(string filePath, int count = 300);
}




public class TextGeneratorService : ITextGeneratorService
{
    public ICollection<string> ReadFromFile(string filePath)
    {
        var words = new List<string>();

        try
        {
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(line.Trim());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {filePath}. Exception: {ex.Message}");
        }

        return words;
    }

    public string GenerateRandomText(ICollection<string> words, int count = 300)
    {
        var random = new Random();
        var wordList = words.ToList(); // Convert to List to use indexing
            
        if (wordList.Count == 0)
        {
            return string.Empty; // Handle case where words list is empty
        }

        var text = new List<string>();
        for (int i = 0; i < count; i++)
        {
            var index = random.Next(wordList.Count);
            text.Add(wordList[index]);
        }

        return string.Join(" ", text);
    }

    public string GenerateRandomTextFromFile(string filePath, int count = 300)
    {
        var words = ReadFromFile(filePath);
        return GenerateRandomText(words, count);
    }
}