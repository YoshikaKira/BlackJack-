using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBlackGack
{
    class Player
    {
        public string Name { get; set; }
        public int Bet { get; set; }
        public int Bank { get; set; }
        public List<Card> Hand { get; set; }
    }
}
