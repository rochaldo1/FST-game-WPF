using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_game__console_.Game
{
    public class GameSettings : IGameSettings
    {
        public double SuccessPoints { get; set; } = 2;
        public double FailurePoints { get; set; } = 0;
        public double DrawPoints { get; set; } = 1;
    }
}
