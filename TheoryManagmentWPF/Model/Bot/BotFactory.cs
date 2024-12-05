using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_game__console_.Bot
{
    public class BotFactory : IBotFactory
    {
        private readonly IDictionary<string, IBot> _bots;

        public BotFactory(IDictionary<string, IBot> bots)
        {
            _bots = bots;
        }

        public IBot? GetBot(string name)
        {
            return _bots.TryGetValue(name, out var bot) ? bot : null;
        }
    }
}
