using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperStoneScisors
{
    class Player
    {
        public enum Choice { PAPER, STONE, SCISSORS };
        public Choice choice { get; set; }
    }
}
