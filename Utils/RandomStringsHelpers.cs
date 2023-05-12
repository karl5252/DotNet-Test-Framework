using SelfServicePortal.Specs.Utils;
/// <summary>
/// Class with random name generators
/// random alphanumeric string
/// random names from dictionary
/// random email
/// </summary>
public static class RandomStringsHelpers
{
    private static readonly Random _random = new Random();

    public static string GetRandomAlphanumericString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
    }

    public static string GetRandomNameString(int maxWords = 3)
    {
        var list = GetDictionary("namesDictionary");
        if(list.Count > 0) 
        {
            var randomWord = list[_random.Next(list.Count)];
            var words = randomWord.Split(' ');
            if (words.Length > maxWords)
            {
                return string.Join(" ", words.Take(maxWords));
            }
            return randomWord;
        }
        else { return string.Empty; }

        
    }
    private static List<String> GetDictionary(string name)
    {
        if (NamesDictionary.namesDictionary.TryGetValue(name, out var list))
    {
            return list; 
        }else 
        {
            throw new Exception($"Misisng dictionary {name}"); 
        }
    }

}