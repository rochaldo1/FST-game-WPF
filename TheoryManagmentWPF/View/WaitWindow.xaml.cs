using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TheoryManagmentWPF.View
{
    /// <summary>
    /// Логика взаимодействия для WaitWindow.xaml
    /// </summary>
    public partial class WaitWindow : Window
    {
        Random random = new Random();
        string botType = "";
        public WaitWindow(string botType)
        {
            InitializeComponent();
            this.botType = botType;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            GameWindow gameWindow = new GameWindow(botType);
            gameWindow.Hide();
            Thread.Sleep(TimeSpan.FromSeconds(random.NextDouble() * 10));
            gameWindow.Show();
            this.Close();
        }
    }
}
