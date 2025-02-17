using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HeroBook
{
    class MainClass
    {
        public static async Task Main()
        {
            AIHandler AIHandler = new();

            //while (true)
            //{
            //    var prompt = Console.ReadLine();
            //    var response = await AIHandler.CallAI(prompt);
            //    Console.WriteLine(response);
            //    Prompt.WriteLine($"\n{new string('-', 50)}\n", PromptType.Title);
            //}

            Prompt.WriteLine("Generating...", PromptType.Log);
            Prompt.WriteLine(new string('-', 50), PromptType.Title);

            var response = await AIHandler.ShowIntroduction();
            Console.WriteLine(response);

            var bookFileName = "HauntedCastle.json";
            var bookPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", bookFileName);
            if (!File.Exists(bookPath))
            {
                Console.WriteLine($"Fichier JSON introuvable at {bookPath}!");
                return;
            }
            string jsonContent = File.ReadAllText(bookPath);
            Book book = JsonConvert.DeserializeObject<Book>(jsonContent);


            Console.WriteLine($"Book {book.Title} successfuly opened");

            book.OpenBook();

            var readBook = true;
            while (readBook)
            {
                var input = Console.ReadLine();

                if (input.ToLower() == "quitter") readBook = false;

                book.ReadPrompt(input);
            }
        }
    }
}
