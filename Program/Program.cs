namespace Program
{
    static class Program
    {
        static void Main(string[] args)
        {
            string? filterWord = null;
            bool ignoreCase = false;
            
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-filter" && i + 1 < args.Length)
                {
                    filterWord = args[i + 1];
                    i++; 
                }
                else if (args[i] == "--ignore-case")
                {
                    ignoreCase = true;
                }
            }
            
            if (string.IsNullOrEmpty(filterWord))
            {
                Console.WriteLine("Необхідно вказати слово для фільтрації.");
                return;
            }
            
            using StreamReader reader = new StreamReader(Console.OpenStandardInput());
            
            string input = reader.ReadToEnd();
            
            string[] lines = input.Split(["\\n", "\n"], StringSplitOptions.None);

            foreach (var line in lines)
            {
                
                if ((ignoreCase && line.IndexOf(filterWord, StringComparison.OrdinalIgnoreCase) >= 0) || (!ignoreCase && line.Contains(filterWord)))
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}