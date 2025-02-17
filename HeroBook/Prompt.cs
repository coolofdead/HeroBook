using System;
namespace HeroBook
{
    public static class Prompt
    {
        public static void WriteLine(string text, PromptType promptType = PromptType.Text)
        {
            Write(text, promptType);
            Console.WriteLine();
        }

        public static void Write(string text, PromptType promptType = PromptType.Text)
        {
            Console.ForegroundColor = GetConsoleColorForPromptType(promptType);
            Console.Write(text);
            Console.ResetColor();
        }

        private static ConsoleColor GetConsoleColorForPromptType(PromptType promptType)
        {
            return promptType switch
            {
                PromptType.Text => ConsoleColor.White,
                PromptType.Title => ConsoleColor.Yellow,
                PromptType.Quest => ConsoleColor.DarkYellow,
                PromptType.Reward => ConsoleColor.Green,
                PromptType.Log => ConsoleColor.Blue,
                PromptType.Inventory => ConsoleColor.Red,
                _ => ConsoleColor.White
            };
        }
    }

    public enum PromptType
    {
        Text,
        Title,
        Quest,
        Reward,
        Log,
        Inventory,
    }
}
