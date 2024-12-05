using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_game__console_.Bot
{
    public interface IBotFactory
    {
        public IBot? GetBot(string name);
    }
}
