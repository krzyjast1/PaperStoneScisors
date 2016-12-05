using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperStoneScisors
{
    class UserPlayer : Player
    {
        public readonly string nick;

        public UserPlayer(string nick)
        {
            this.nick = nick;
            this.pointCounter = 0;
        }
        public override string ToString()
        {
            return "Choice: " + choice+"\nNick: "+nick;
        }
    }

    class CPUPlayer : Player
    {
        public CPUPlayer()
        {
            this.pointCounter = 0;
        }
        public override string ToString()
        {
            return "Choice: " + choice;
        }

        public void choose()
        {
            int x = 23;
            x = new Random().Next(0, 9);
            switch(x)
            {
                case 1:
                case 4:
                case 7:
                    choice = Choice.PAPER;
                    break;
                case 2:
                case 5:
                case 8:
                    choice = Choice.SCISSORS;
                    break;
                case 3:
                case 6:
                case 9:
                    choice = Choice.STONE;
                    break;
            }
        }
    }
}
