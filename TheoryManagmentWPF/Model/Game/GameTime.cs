using FCT_game__console_.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT_game__console_.Game
{
    public class GameTime : IGame
    {
        public readonly double _gameTimeInMilliseconds;
        private DateTime? _startedAt;

        public IGameSettings Settings { get; }
        public IPlayer FirstPlayer { get; }
        public IPlayer SecondPlayer { get; }

        public GameTime(IGameSettings settings, IPlayer firstPlayer, IPlayer secondPlayer, double gameTimeInMilliseconds)
        {
            if (firstPlayer.Name == secondPlayer.Name) throw new ArgumentException("Имена у игроков должны быть разные.");

            Settings = settings;
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            _gameTimeInMilliseconds = gameTimeInMilliseconds;
        }

        public bool MakeChoice(bool playerChoice, bool botChoice)
        {
            _startedAt ??= DateTime.Now;

            FirstPlayer.AddChoice(playerChoice);
            SecondPlayer.AddChoice(botChoice);

            if (playerChoice == botChoice)
            {
                if (playerChoice)
                {
                    FirstPlayer.Points += Settings.DrawPoints;
                    SecondPlayer.Points += Settings.DrawPoints;
                }
                else
                {
                    FirstPlayer.Points += Settings.FailurePoints;
                    SecondPlayer.Points += Settings.FailurePoints;
                }
            }
            else
            {
                if (playerChoice)
                {
                    FirstPlayer.Points += Settings.FailurePoints;
                    SecondPlayer.Points += Settings.SuccessPoints;
                }
                else
                {
                    FirstPlayer.Points += Settings.SuccessPoints;
                    SecondPlayer.Points += Settings.FailurePoints;
                }
            }

            return _startedAt + TimeSpan.FromMilliseconds(_gameTimeInMilliseconds) > DateTime.Now;
        }
    }
}
