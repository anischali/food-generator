﻿using System.ComponentModel;
using System.Windows;

namespace food
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button_Click_1(null, null);
            IO.Database.LoadAllDatabases();
            Closing += MainWindow_Closing; 
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            IO.Database.SaveAllDatabases();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GeneratorPage generator = new GeneratorPage();
            PanelOfUserControl.Children.Clear();
            PanelOfUserControl.Children.Add(generator);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddRecipePage recipePage = new AddRecipePage();
            PanelOfUserControl.Children.Clear();
            PanelOfUserControl.Children.Add(recipePage);
        }
    }
}