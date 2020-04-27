using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace food
{
    internal class ContentBind
    {
        public string name { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }

    }
    /// <summary>
    /// Logique d'interaction pour AddRecipePage.xaml
    /// </summary>

    
    public partial class AddRecipePage
    {
        internal Delegates.returnToHomePanel HomePanel;
        private Recipe recipe;
        private RecipePanel AddPanelView = null;
        private bool isPanelViewVisible = false;
        public AddRecipePage()
        {
            InitializeComponent();
            recipe = new Recipe();
            PopulateTagsList();
        }

        

        private void addToListRecipe(RecipeContent content)
        {
            recipe.Contents.Add(content);
        }

        private void addToListViewRecipe(RecipeContent content)
        {
            ContentBind cb = new ContentBind()
            {
                name = Tools.FindContentNameByUid(content.uid),
                quantity = content.Quantity,
                unit = ((content.QuantityUnit != Unit.Undefined) ?
                Generator.units[((int)content.QuantityUnit)] : "Unknown")
            };
            lstContententList.Items.Add(cb);
        }

        private void UpdateListView()
        {
            lstContententList.Items.Clear();
            foreach (RecipeContent rc in recipe.Contents)
            {
                addToListViewRecipe(rc);
            }
        }
        private void CloseSubPanels()
        {
            gridAddPanelPlace.Children.Clear();
            gridAddPanelPlace.Visibility = Visibility.Hidden;
            AddPanelView = null;
            isPanelViewVisible = false;
            UpdateListView();
        }

        private void btnAddContent_Click(object sender, RoutedEventArgs e)
        {
            if (isPanelViewVisible)
                return;
            AddPanelView = new RecipePanel();
            AddPanelView.addToListOfContentsEvent += addToListRecipe;
            AddPanelView.closeEvent += CloseSubPanels;
            AddPanelView.addNewContentToDatabaseEvent += IO.Database.AddContentToDatabase;
            this.gridAddPanelPlace.Visibility = Visibility.Visible;
            this.gridAddPanelPlace.Children.Add(AddPanelView);
            isPanelViewVisible = true;

        }


        private void RemoveRecipeContent(string uid)
        {
            foreach (RecipeContent rc in recipe.Contents)
            {
                if (rc.uid == uid)
                {
                    recipe.Contents.Remove(rc);
                    break;
                }
            }
        }

        private void EditRecipeContent(string uid, double quantity, Unit unit)
        {
            foreach (RecipeContent rc in recipe.Contents)
            {
                if (rc.uid == uid)
                {
                    rc.Quantity = quantity;
                    rc.QuantityUnit = unit;
                    break;
                }
            }
        }

        private void lstContententList_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lstContententList.SelectedItem == null || recipe.Contents.Count <= 0)
                return;
            ContentBind content = (ContentBind)lstContententList.SelectedItem;
            RecipeContent rc = Tools.FindRecipeContentByName(recipe.Contents, content.name);
            if (rc == null)
                return;
            EditRecipePanel editPanel = new EditRecipePanel(content.name, rc);
            editPanel.editRecipeContent += EditRecipeContent;
            editPanel.removeRecipeContent += RemoveRecipeContent;
            editPanel.closeEvent += CloseSubPanels;
            this.gridAddPanelPlace.Visibility = Visibility.Visible;
            this.gridAddPanelPlace.Children.Add(editPanel);
            isPanelViewVisible = true;
        }


        public void OnTagCheckedEvent(object sender, RoutedEventArgs args)
        {
            CheckBox senderBox = (CheckBox)sender;
            recipe.Tags.Add((Tag)senderBox.Tag);
        }

        internal void OnTagUncheckedEvent(object sender, RoutedEventArgs args)
        {
            CheckBox senderBox = (CheckBox)sender;
            recipe.Tags.Remove((Tag)senderBox.Tag);
        }

        internal void PopulateTagsList()
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

            cmbRecipeTags.ItemsSource = lst;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            HomePanel();
        }

        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            recipe.PeopleNumber = int.Parse(txtPeopleNumber.Text);
            recipe.title = txtRecipeTitle.Text;
            IO.Database.AddRecipeToDatabase(recipe);
            HomePanel();
        }

    }




}
