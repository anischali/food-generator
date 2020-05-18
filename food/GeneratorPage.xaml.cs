using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            Generator.TagsToUseInSearch.Remove((Tag)senderBox.Tag);
            
        }

        public void OnTagUncheckedEvent(object sender, RoutedEventArgs args)
        {
            CheckBox senderBox = (CheckBox)sender;
            Generator.TagsToUseInSearch.Remove((Tag)senderBox.Tag);

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
