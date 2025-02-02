﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using TheoryManagmentWPF.ViewModel;

namespace TheoryManagmentWPF.View
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            DataContext = new StartVM();
            if (DataContext is StartVM vm)
            {
                vm.GameSelected += ButtonsClick;
            }
        }

        private void ButtonsClick(string botType)
        {
            WaitWindow waitWindow = new WaitWindow(botType);
            waitWindow.Show();
            this.Close();
        }

    }
}
