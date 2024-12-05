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
using TheoryManagmentWPF.ViewModel;

namespace TheoryManagmentWPF.View
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();




        public GameWindow(string botType)
        {
            InitializeComponent();
            DataContext = new GameVM(botType);
            if (DataContext is GameVM vm)
            {
                vm.gameEnded += GetMessageEnd;
                vm.partEnded += GetMessagePart;
            }
            
        }

        private void GetMessagePart(string message)
        {
            MessageBox.Show(message);
        }

        private void GetMessageEnd(string message) 
        { 
            MessageBox.Show(message);
            this.Close();
        }

    }
}
