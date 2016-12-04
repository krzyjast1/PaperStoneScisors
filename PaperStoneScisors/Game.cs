using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AdvancedMenu;

namespace PaperStoneScisors
{
    static class Game
    {

//        private static int choice;

        public enum Choice { CONTINUE, PLAY, RULES, EXIT };
        private static Choice choice;

        public static void startGame()
        {
            var Menu = new AdvancedMenu(new List<string>{"1. Play", "2. Rules","3. Exit" });
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
                        //TODO: Here place engine start method
                        Console.WriteLine("Your choice is PLAY");
                        Thread.Sleep(2000);
                        break;

                    case Choice.RULES:
                        Console.WriteLine("Your choice is RULES");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }

    }
}
