using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace food
{
    /// <summary>
    /// Logique d'interaction pour AdvancedSearchPanel.xaml
    /// </summary>
    public partial class AdvancedSearchPanel : UserControl
    {
        private readonly List<int> RecipeIndexs = new List<int>();
        private readonly List<int> ContentsInRecipe = new List<int>();
        private readonly List<Tag> TagsInRecipe = new List<Tag>();
        public AdvancedSearchPanel()
        {
            InitializeComponent();
            PopulateContentsComboBox();
            PopulateTagsComboBox();
        }

        private void SearchWithTitle()
        {
            string titleToSearch = (tbTitle.Text == "") ? "" : tbTitle.Text.ToLower();
            if (!(chbTitle.IsChecked == true) || (titleToSearch == ""))
                return;
            int Length = IO.Database.AllMenus.Count;
            for (int i = 0; i < Length; ++i)
            {
                string lowerTitle = IO.Database.AllMenus[i].title.ToLower();
                if (lowerTitle.Contains(titleToSearch))
                    RecipeIndexs.Add(i);
            }
        }

        private void PopulateListWithSearchResults()
        {
            if (!(RecipeIndexs.Count > 0))
                return;
            List<string> titles = new List<string>();
            foreach (int idx in RecipeIndexs)
            {
                titles.Add(IO.Database.AllMenus[idx].title);
            }
            lstSearchResults.ItemsSource = titles;
        }

        private void SearchWithContents()
        {
            if (!(chbContents.IsChecked == true) || !(ContentsInRecipe.Count > 0))
                return;
            int Length = IO.Database.AllMenus.Count;
            for (int idx = 0; idx < Length; ++idx)
            {
                if (Tools.IsRecipeContainsContents(IO.Database.AllMenus[idx], ContentsInRecipe))
                {
                    RecipeIndexs.Add(idx);
                }
            }
        }


        

        private void ClearAllStuffs()
        {
            RecipeIndexs.Clear();
            lstSearchResults.ItemsSource = null;
            //ContentsInRecipe.Clear();
            //TagsInRecipe.Clear();
        }

        


        private void OnTagCheckedEvent(object sender, RoutedEventArgs args)
        {
            CheckBox senderBox = (CheckBox)sender;
            TagsInRecipe.Add((Tag)senderBox.Tag);
        }
        private void OnTagUncheckedEvent(object sender, RoutedEventArgs args)
        {
            CheckBox senderBox = (CheckBox)sender;
            TagsInRecipe.Remove((Tag)senderBox.Tag);
        }

        private void OnContentCheckedEvent(object sender, RoutedEventArgs args)
        {
            CheckBox senderBox = (CheckBox)sender;
            ContentsInRecipe.Add((int)senderBox.Tag);
        }
        private void OnContentUncheckedEvent(object sender, RoutedEventArgs args)
        {
            CheckBox senderBox = (CheckBox)sender;
            ContentsInRecipe.Remove((int)senderBox.Tag);
        }


        private void PopulateTagsComboBox()
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

            cmbTags.ItemsSource = lst;
        }

        private void PopulateContentsComboBox()
        {
            List<CheckBox> lst = new List<CheckBox>();
            CheckBox chbTemp;
            int Length = IO.Database.contents.Count;
            for (int i = 0; i < Length; ++i)
            {
                chbTemp = new CheckBox();
                chbTemp.IsChecked = false;
                chbTemp.Content = IO.Database.contents[i].Name;
                chbTemp.Tag = i;
                chbTemp.Checked += new RoutedEventHandler(OnContentCheckedEvent);
                chbTemp.Unchecked += new RoutedEventHandler(OnContentUncheckedEvent);
                lst.Add(chbTemp);
            }
            cmbContents.ItemsSource = lst;
        }

        private void SearchWithAllTags()
        {
            int Length = IO.Database.AllMenus.Count;
            for (int idx = 0; idx < Length; ++idx)
            {
                if (Tools.IsRecipeContainsAllTags(IO.Database.AllMenus[idx], TagsInRecipe))
                {
                    RecipeIndexs.Add(idx);
                }
            }
        }

        private void SearchWithAnyTags()
        {
            int Length = IO.Database.AllMenus.Count;
            for (int idx = 0; idx < Length; ++idx)
            {
                if (Tools.IsRecipeContainsAllTags(IO.Database.AllMenus[idx], TagsInRecipe))
                {
                    RecipeIndexs.Add(idx);
                }
            }
        }

        private void SearchWithTags()
        {
            if (!(chbTags.IsChecked == true) || !(TagsInRecipe.Count > 0))
                return;
            if (chbOrAnd.IsChecked == true)
            {
                SearchWithAllTags();
                return;
            }
            SearchWithAnyTags();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            ClearAllStuffs();
            SearchWithTitle();
            SearchWithContents();
            SearchWithTags();
            PopulateListWithSearchResults();
        }

    }
}
