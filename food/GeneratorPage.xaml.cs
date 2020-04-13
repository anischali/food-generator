using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace food
{
    /// <summary>
    /// Logique d'interaction pour GeneratorPage.xaml
    /// </summary>
    public partial class GeneratorPage : UserControl
    {
        public GeneratorPage()
        {
            InitializeComponent();
            PopulateTagsList();
        }

        public void OnTagCheckedEvent(object sender, RoutedEventArgs args)
        {
            CheckBox senderBox = (CheckBox)sender;
            Console.WriteLine($"Index: {senderBox.Tag} Text: {senderBox.Content} Checked");

        }

        public void OnTagUncheckedEvent(object sender, RoutedEventArgs args)
        {
            CheckBox senderBox = (CheckBox)sender;
            Console.WriteLine($"Index: {senderBox.Tag} Text: {senderBox.Content} Unchecked");
        }

        public void PopulateTagsList()
        {
            List<CheckBox> lst = new List<CheckBox>();
            CheckBox chbTemp;
            for (int i = 0; i < Generator.tags.Length; ++i)
            {
                chbTemp = new CheckBox();
                chbTemp.IsChecked = false;
                chbTemp.Content = Generator.tags[i];
                chbTemp.Tag = i;
                chbTemp.Checked += new RoutedEventHandler(OnTagCheckedEvent);
                chbTemp.Unchecked += new RoutedEventHandler(OnTagUncheckedEvent);
                lst.Add(chbTemp);
            }

            TagsList.ItemsSource = lst; 
        }

    }
}
