using FCT_game__console_.Bot;
using FCT_game__console_.Game;
using FCT_game__console_.Player;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheoryManagmentWPF.ViewModel.Commands;

namespace TheoryManagmentWPF.ViewModel
{
    class GameVM : BaseVM
    {

        private string botType;
        private readonly Timer timer;
        private readonly Stopwatch stopwatch = new Stopwatch();
        private TimeSpan _time;
        public event Action<int>? GameSelected;
        public int part=1;
        public int toStop = 20;
        public int selected = 0;
        public int parts = 2;

        public string information = "";

        public Action<string>? partEnded;
        public Action<string>? gameEnded;

        public string Information
        {
            get => information;
            set => Set(ref information, value);
        }

        public double firstPoints = 0;
        public double FirstPoints
        {
            get => firstPoints;
            set => Set(ref firstPoints, value);
        }

        public double secindPoints = 0;
        public double SecindPoints
        {
            get => secindPoints;
            set => Set(ref secindPoints, value);
        }

        public int Parts
        {
            get => parts;
            set => Set(ref parts, value);
        }

        public TimeSpan Time { get => _time; private set => Set(ref _time, value); }

        IPlayer firstPlayer = new Player("Player");
        IPlayer secondPlayer = new Player("Denyux");

        public IPlayer FirstPlayer 
        {
            get => firstPlayer;
            set => Set(ref firstPlayer, value);
        }

        public IPlayer SecondPlayer
        {
            get => secondPlayer;
            set => Set(ref secondPlayer, value);
        }

        IGameSettings settings = new GameSettings()
        {
            SuccessPoints = 500,
            DrawPoints = 100,
            FailurePoints = 0
        };

        IGame game { get; set; }

        IDictionary<string, IBot> bots = new Dictionary<string, IBot>()
            {
                { "pc", new RandomBot(0.5d) },
                { "aa", new RandomBot(0.66d) },
                { "bb", new RandomBot(0.34d) }
            };

        IBotFactory botFactory { get; set; }

        Random random = new();

        public int Part
        {
            get => part; 
            set => Set(ref part, value);
        }

        public int Selected
        {
            get => selected;
            set => Set(ref selected, value);
        }

        public string BotType
        {
            get => botType;
            set => Set(ref botType, value);
        }

        bool botChoice;
        double botTimeoutInSeconds;

        public bool BotChoice
        {
            get => botChoice;
            set => Set(ref botChoice, value);
        }

        public double BotTimeoutInSeconds
        {
            get => botTimeoutInSeconds;
            set => Set(ref botTimeoutInSeconds, value);
        }

        IBot bot;

        public IBot Bot
        {
            get => bot;
            set => Set(ref bot, value);
        }

        public GameVM(string botType)
        {
            BotType = botType;
            game = new GameTime(settings, firstPlayer, secondPlayer, gameTimeInMilliseconds: 1 * 60 * 1000);
            botFactory = new BotFactory(bots);
            timer = new Timer(_ => Time = stopwatch.Elapsed, null, 0, 10);  
            stopwatch.Start();
            Bot = botFactory.GetBot(botType ?? throw new ArgumentNullException(nameof(botType)));
        }


        public Command ZeroButtonCommand => Command.Create(ZeroButtonStart);
        private void ZeroButtonStart()
        {
            GameSelected?.Invoke(0);
            Selected += 1;
            botTimeoutInSeconds = new Random().NextDouble() * 5;
            Thread.Sleep(TimeSpan.FromSeconds(random.NextDouble() * botTimeoutInSeconds));
            botChoice = bot.GetAnswer();
            game.MakeChoice(false, botChoice);
            FirstPoints = FirstPlayer.Points;
            SecindPoints = SecondPlayer.Points;
            string res = "";
            for (int i = 0; i < FirstPlayer.Choices.Count; i++)
            {

                res += "\n Вы: ";
                res += game.FirstPlayer.Choices[i] ? "1" : "0";
                res += "\n Игрок 2: ";
                res += game.SecondPlayer.Choices[i] ? "1" : "0";
            }
            Information = res;
            if (Selected == toStop)
            {
                Selected = 0;
                Part += 1;
                if (FirstPlayer.Points > SecondPlayer.Points)
                {
                    partEnded?.Invoke("В данной партии победили вы");
                }
                else if (FirstPlayer.Points < SecondPlayer.Points)
                {
                    partEnded?.Invoke("В данной партии побебил игрок 2");
                }
                else
                {
                    partEnded?.Invoke("Ничья");
                }

                if (Part == 3)
                {
                    gameEnded?.Invoke("Игра окончена");
                }
            }
        }

        public Command OneButtonCommand => Command.Create(OneButtonStart);
        private void OneButtonStart()
        {
            GameSelected?.Invoke(1);
            Selected += 1;
            botTimeoutInSeconds = new Random().NextDouble() * 5;
            Thread.Sleep(TimeSpan.FromSeconds(random.NextDouble() * botTimeoutInSeconds));
            botChoice = bot.GetAnswer();
            game.MakeChoice(true, botChoice);
            FirstPoints = FirstPlayer.Points;
            SecindPoints = SecondPlayer.Points;
            string res = "";
            for (int i = 0; i < FirstPlayer.Choices.Count; i++)
            {

                res += "\n Вы: ";
                res += game.FirstPlayer.Choices[i] ? "1" : "0";
                res += "\n Игрок 2: ";
                res += game.SecondPlayer.Choices[i] ? "1" : "0";
            }
            Information = res;
            if (Selected == toStop)
            {
                Selected = 0;
                Part += 1;
                if (FirstPlayer.Points > SecondPlayer.Points)
                {
                    partEnded?.Invoke("В данной партии победили вы");
                }
                else if (FirstPlayer.Points < SecondPlayer.Points)
                {
                    partEnded?.Invoke("В данной партии побебил игрок 2");
                }
                else
                {
                    partEnded?.Invoke("Ничья");
                }

                
                if (Part == 3)
                {
                    gameEnded?.Invoke("Игра окончена");
                }
            }
        }

    }
}
