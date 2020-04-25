using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.TextFormatting;

namespace food
{
    /// <summary>
    /// Logique d'interaction pour AddRecipePage.xaml
    /// </summary>


    public partial class AddRecipePage 
    {
        private List<Content> contents;
        private RecipePanel panel = null;
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
            panel = null;
        }

        private void btnAddContent_Click(object sender, RoutedEventArgs e)
        {

            panel = new RecipePanel();
            panel.addToListOfContentsEvent += addToListRecipe;
            panel.closeEvent += closeAddPanel;
            this.gridAddPanelPlace.Visibility = Visibility.Visible;
            this.gridAddPanelPlace.Children.Add(panel);
        }
    }
}
