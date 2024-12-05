using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_game__console_.Player
{
    public interface IPlayer
    {
        public string Name { get; set; }
        public double Points { get; set; }
        public IReadOnlyList<bool> Choices { get; }

        public void AddChoice(bool choice);
    }
}
