using System;
using System.Collections.Generic;
using System.Threading;

namespace PaperStoneScisors
{
    static class Game
    {

        public enum Choice { CONTINUE, PLAY, RULES, EXIT };
        private static Choice choice;

        public static void startGame()
        {
            var Menu = new AdvancedMenu(new List<string>{"1. Graj", "2. Zasady","3. Wyjdź" });
            while (true)
            {
                do
                {
                    choice = (Choice)Menu.Capture();
                } while (choice == Choice.CONTINUE);

                switch (choice)
                {
                    case Choice.EXIT:
                        Environment.Exit(0);
                        break;

                    case Choice.PLAY:
                        Console.Clear();
                        Engine.startEngine();
                        break;

                    case Choice.RULES:
                        showRules();
                        break;
                }
            }
        }

        private static void showRules()
        {
            Console.Clear();
            ConsoleColor defaultBckGnd = Console.BackgroundColor;
            ConsoleColor defaultFrGnd = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ZASADY:");
            Console.BackgroundColor = defaultBckGnd;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. Grasz przeciwko komputerowi.");
            Console.WriteLine("2. Gracie do 5 zdobytych punktów.");
            Console.WriteLine("3. Papier wygrywa z kamieniem,");
            Console.WriteLine("   Kamień wygrywa z nożyczkami,");
            Console.WriteLine("   Nożyczki wygrywają z papierem,");
            Console.WriteLine("   Takie same przedmioty - remis.");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("PUNKTACJA:");
            Console.BackgroundColor = defaultBckGnd;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. Zwycięstwo - 1pkt");
            Console.WriteLine("2. Remis - 0pkt");
            Console.WriteLine("3. Porażka - 0pkt");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("STEROWANIE:");
            Console.BackgroundColor = defaultBckGnd;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. Kamień - K.");
            Console.WriteLine("2. Papier - P.");
            Console.WriteLine("3. Nożyczki - N.");
            Console.WriteLine();
            Console.WriteLine("Wciśnij ENTER aby wrócić do menu.");
            Console.ForegroundColor = defaultFrGnd;
            Console.BackgroundColor = defaultBckGnd;
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            key = Console.ReadKey();

            switch(key.Key)
            {
                case ConsoleKey.Enter: return; break;
                default: showRules(); break;
            }
        }
    }
}
