using FCT_game__console_.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_game__console_.Game
{
    internal interface IGame
    {
        public IGameSettings Settings { get; }
        public IPlayer FirstPlayer { get; }
        public IPlayer SecondPlayer { get; }

        public bool MakeChoice(bool playerChoice, bool botChoice);
    }
}
