using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PaperStoneScisors
{
    static class Engine
    {
        private static UserPlayer UserPlayer;
        private static CPUPlayer CpuPlayer;

        public static void startEngine() //method which configure game event
        {
            Console.Write("Podaj nick: ");
            string nick = Console.ReadLine();
            Console.Clear();

            UserPlayer = new UserPlayer(nick);
            CpuPlayer = new CPUPlayer();

            for(int i = 0; i<10; i++)
            {
                Console.WriteLine("Ładowanie ");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("Ładowanie .");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("Ładowanie ..");
                Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("Ładowanie ...");
                Thread.Sleep(200);
                Console.Clear();
            }

            play();
        }

        public static void play()
        {
            while( CpuPlayer.pointCounter <5 || UserPlayer.pointCounter <5 )
            {
                Console.Clear();
                showNecessaryInfo();
                Console.WriteLine();
                Console.WriteLine("Wybierz przedmiot lub wciśnij ESC żeby wyjść do menu");
                ConsoleKeyInfo key = new ConsoleKeyInfo();
                key = Console.ReadKey();
                Console.Clear();
                CpuPlayer.choose();
                
                switch (key.Key)
                {
                    case ConsoleKey.K: UserPlayer.choice = Player.Choice.STONE; Console.WriteLine(UserPlayer.ToString());    break;
                    case ConsoleKey.P: UserPlayer.choice = Player.Choice.PAPER; Console.WriteLine(UserPlayer.ToString()); break;
                    case ConsoleKey.N: UserPlayer.choice = Player.Choice.SCISSORS; Console.WriteLine(UserPlayer.ToString()); break;
                    case ConsoleKey.Escape: return;
                    default: Console.WriteLine("Zły klawisz. K - kamień. P - papier. N - nożyczki"); break;
                }
                Console.WriteLine(CpuPlayer.ToString());
                Thread.Sleep(2000);
            }
        }

        public static void showNecessaryInfo()
        {
            Console.WriteLine(UserPlayer.nick + ": " + UserPlayer.pointCounter + "       Komputer: " + CpuPlayer.pointCounter);
        }
    }
}
