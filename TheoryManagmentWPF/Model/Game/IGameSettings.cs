using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_game__console_.Game
{
    public interface IGameSettings
    {
        public double SuccessPoints {  get; set; }
        public double FailurePoints { get; set; }
        public double DrawPoints { get; set; }
    }
}
