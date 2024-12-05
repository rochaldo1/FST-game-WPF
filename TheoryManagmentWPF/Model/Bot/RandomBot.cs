using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_game__console_.Bot
{
    internal class RandomBot : IBot
    {
        private readonly Random _random = new();
        private readonly double _probability;

        public RandomBot(double probability)
        {
            if (probability < 0 || probability > 1) throw new ArgumentException("trueChance < 0 or trueChance > 1");
            _probability = probability;
        }

        public bool GetAnswer()
        {
            return _random.NextDouble() < _probability;
        }
    }
}
