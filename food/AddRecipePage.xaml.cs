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
            ContentBind cb = new ContentBind() 
            { 
                name = Tools.FindContentNameByUid(content.uid),
                quantity = content.Quantity,
                unit = ((content.QuantityUnit != Unit.Undefined) ? 
                Generator.units[((int)content.QuantityUnit)] : "Unknown")
            };
            lstContententList.Items.Add(cb);
        }

        private void closeAddPanel()
        {
            gridAddPanelPlace.Children.Clear();
            gridAddPanelPlace.Visibility = Visibility.Hidden;
            AddPanelView = null;
            isPanelViewVisible = false;
        }

        private void btnAddContent_Click(object sender, RoutedEventArgs e)
        {
            if (isPanelViewVisible)
                return;
            AddPanelView = new RecipePanel();
            AddPanelView.addToListOfContentsEvent += addToListRecipe;
            AddPanelView.closeEvent += closeAddPanel;
            AddPanelView.addNewContentToDatabaseEvent += IO.Database.AddContentToDatabase;
            this.gridAddPanelPlace.Visibility = Visibility.Visible;
            this.gridAddPanelPlace.Children.Add(AddPanelView);
            isPanelViewVisible = true;

        }
    }
}
