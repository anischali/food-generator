using System.Collections.Generic;
using System.Windows;

namespace food
{
    /// <summary>
    /// Logique d'interaction pour AddRecipePage.xaml
    /// </summary>


    public partial class AddRecipePage
    {
        private List<Content> contents;
        private RecipePanel AddPanelView = null;
        private bool isPanelViewVisible = false;
        public AddRecipePage()
        {
            InitializeComponent();
            contents = new List<Content>();
        }

        private void addToListRecipe(Content content)
        {
            contents.Add(content);
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
