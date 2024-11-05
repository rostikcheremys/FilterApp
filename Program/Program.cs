namespace Program
{
    static class Program
    {
        static void Main(string[] args)
        {
            string? filterWord = null; 
            bool ignoreCase = false;
            string? filePath = null; 
            
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
                else if (args[i] == "-file" && i + 1 < args.Length)
                {
                    filePath = args[i + 1];
                    i++; 
                }
            }
            
            if (string.IsNullOrEmpty(filterWord))
            {
                Console.WriteLine("Необхідно вказати слово для фільтрації.");
                return;
            }

            string[] lines;
            
            if (!string.IsNullOrEmpty(filePath))
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файл не знайдено.");
                    return;
                }
                
                string fileContent = File.ReadAllText(filePath);
                
                fileContent = fileContent.Replace("\\n", "\n");
                
                lines = fileContent.Split(['\n'], StringSplitOptions.None);
            }
            else
            {
                using var reader = new StreamReader(Console.OpenStandardInput());
                string input = reader.ReadToEnd();
                
                lines = input.Split(['\n'], StringSplitOptions.None);
            }

            foreach (var line in lines)
            {
                if ((ignoreCase && line.IndexOf(filterWord, StringComparison.OrdinalIgnoreCase) >= 0) || (!ignoreCase && line.Contains(filterWord)))
                {
                    Console.WriteLine(line.Trim());
                }
            }
        }
    }
}
