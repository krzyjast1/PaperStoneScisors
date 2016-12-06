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

        public enum Win { USER, CPU, DRAW};

        public static void startEngine() //method which configure game event
        {
            Console.Write("Podaj nick: ");
            string nick = Console.ReadLine();
            Console.Clear();

            UserPlayer = new UserPlayer(nick);
            CpuPlayer = new CPUPlayer();

            for(int i = 0; i<3; i++)
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
            while(true)
            {
                Console.Clear();
                showNecessaryInfo();
                Console.WriteLine();
                Console.WriteLine("Wybierz przedmiot lub wciśnij ESC żeby wyjść do menu");
                ConsoleKeyInfo key = new ConsoleKeyInfo();
                key = Console.ReadKey();
                Console.Clear();
                CpuPlayer.choose();

                Win winner = new Win();

                switch (key.Key)
                {
                    case ConsoleKey.K: UserPlayer.choice = Player.Choice.STONE; winner = whoIsWinner(); break;
                    case ConsoleKey.P: UserPlayer.choice = Player.Choice.PAPER; winner = whoIsWinner(); break;
                    case ConsoleKey.N: UserPlayer.choice = Player.Choice.SCISSORS; winner = whoIsWinner(); break;
                    case ConsoleKey.Escape: return;
                    default: Console.WriteLine("Zły klawisz. K - kamień. P - papier. N - nożyczki"); Thread.Sleep(1000);  winner = Win.DRAW ; break;
                }

                if (key.Key == ConsoleKey.K || key.Key == ConsoleKey.N || key.Key == ConsoleKey.P)
                {
                    Console.WriteLine(showChoice());
                    Thread.Sleep(1000);
                }

                switch(winner)
                {
                    case Win.USER: UserPlayer.pointCounter++; Console.WriteLine(UserPlayer.nick + " wygrał."); break;
                    case Win.CPU: CpuPlayer.pointCounter++; Console.WriteLine("Komputer wygrał."); break;
                    case Win.DRAW: Console.WriteLine("Był remis."); break;
                }

                Thread.Sleep(1050);
                Console.Clear();

                if(UserPlayer.pointCounter == 5)
                {
                    showWinnerMessage(Win.USER);
                    break;
                }
                else if(CpuPlayer.pointCounter == 5)
                {
                    showWinnerMessage(Win.CPU);
                    break;
                }
            }
        }

        public static void showNecessaryInfo()
        {
            Console.WriteLine(UserPlayer.nick + ": " + UserPlayer.pointCounter + "       Komputer: " + CpuPlayer.pointCounter);
        }

        public static Win whoIsWinner()
        {
            if (UserPlayer.choice == Player.Choice.STONE && CpuPlayer.choice == Player.Choice.STONE) return Win.DRAW;
            else if (UserPlayer.choice == Player.Choice.PAPER && CpuPlayer.choice == Player.Choice.PAPER) return Win.DRAW;
            else if (UserPlayer.choice == Player.Choice.SCISSORS && CpuPlayer.choice == Player.Choice.SCISSORS) return Win.DRAW;
            else if (UserPlayer.choice == Player.Choice.PAPER && CpuPlayer.choice == Player.Choice.STONE) return Win.USER;
            else if (UserPlayer.choice == Player.Choice.STONE && CpuPlayer.choice == Player.Choice.SCISSORS) return Win.USER;
            else if (UserPlayer.choice == Player.Choice.SCISSORS && CpuPlayer.choice == Player.Choice.PAPER) return Win.USER;
            else if (UserPlayer.choice == Player.Choice.SCISSORS && CpuPlayer.choice == Player.Choice.STONE) return Win.CPU;
            else if (UserPlayer.choice == Player.Choice.STONE && CpuPlayer.choice == Player.Choice.PAPER) return Win.CPU;
            else if (UserPlayer.choice == Player.Choice.PAPER && CpuPlayer.choice == Player.Choice.SCISSORS) return Win.CPU;
            else throw new Exception("Błąd systemu sprawdzania wyników");
        }
        public static void showWinnerMessage(Win winner)
        {
            if(winner == Win.USER)
            {
                Console.WriteLine(UserPlayer.nick + " wygrał!!!.");
                showNecessaryInfo();
            }
            else if(winner == Win.CPU)
            {
                Console.WriteLine("Komputer wygrał :(");
                showNecessaryInfo();
            }
            Console.WriteLine();
            Console.WriteLine("Wciśnij dowolny klawisz aby kontynuować...");
            Console.ReadKey();
        }

        public static string showChoice()
        {
            string msgCPU = "";
            string msgUSER = "";
            switch(UserPlayer.choice)
            {
                case Player.Choice.PAPER: msgUSER = "Papier"; break;
                case Player.Choice.STONE: msgUSER = "Kamień"; break;
                case Player.Choice.SCISSORS: msgUSER = "Nożyczki"; break;
            }
            switch (CpuPlayer.choice)
            {
                case Player.Choice.PAPER: msgCPU = "Papier"; break;
                case Player.Choice.STONE: msgCPU = "Kamień"; break;
                case Player.Choice.SCISSORS: msgCPU = "Nożyczki"; break;
            }

            return "Komputer: " + msgCPU + "\n" + UserPlayer.nick + ": " + msgUSER;
        }
    }
}
