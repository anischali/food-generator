using System;
using System.Collections.Generic;
using System.Windows;

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
        private Recipe recipe;
        private RecipePanel AddPanelView = null;
        private bool isPanelViewVisible = false;
        public AddRecipePage()
        {
            InitializeComponent();
            recipe = new Recipe();
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
    }
}
