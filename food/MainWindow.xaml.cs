using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            Button_Click_1(null,null);
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
