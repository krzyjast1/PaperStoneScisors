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
        }
        public override string ToString()
        {
            return "Choice: " + choice+"\nNick: "+nick;
        }
    }

    class CPUPlayer : Player
    {
        public override string ToString()
        {
            return "Choice: " + choice;
        }
    }
}
