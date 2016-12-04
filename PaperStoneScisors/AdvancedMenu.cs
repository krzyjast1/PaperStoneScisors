using System;
using System.Collections.Generic;
using System.Threading;

namespace PaperStoneScisors
{
    public class AdvancedMenu
    {
        private List<string> options;
        private int activeOption;
        private readonly ConsoleColor foregroundDefault;

        public AdvancedMenu(List<string> options)
        {
            this.options = options;
            activeOption = 0;
            foregroundDefault = Console.ForegroundColor;
        }

        private void Menu()
        {
            Console.Clear();
            ConsoleColor defaultBackground = Console.BackgroundColor;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            int i = 0;
            foreach (string option in options)
            {
                i++;
                if (i == activeOption)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(option);
                    Console.BackgroundColor = defaultBackground;
                }
                else Console.WriteLine(option);
            }
            Console.WriteLine("");
        }

        public int Capture()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            Menu();
            key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    if (activeOption == options.Count)
                    {
                        activeOption = 1;
                    }
                    else activeOption++;
                    return 0;
                     

                case ConsoleKey.UpArrow:
                    if (activeOption == 1)
                    {
                        activeOption = options.Count;
                    }
                    else activeOption--;
                    return 0;
                     

                case ConsoleKey.Enter:
                    return activeOption;
                     

                case ConsoleKey.Escape:
                    return options.Count;
                     

                default: return 0;  
            }
        }

    }
}
