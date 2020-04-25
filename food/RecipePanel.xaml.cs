using System;
using System.Windows;
using System.Windows.Controls;

namespace food
{
    /// <summary>
    /// Logique d'interaction pour RecipePanel.xaml
    /// </summary>
    public partial class RecipePanel : UserControl
    {
        private Content content;
        private Content[] contents; 
        internal Delegates.addToListOfContentsDelegate addToListOfContentsEvent;
        internal Delegates.addContentsToDatabaseDelegate addNewContentToDatabaseEvent;
        internal Delegates.closeAddContentPanelDelegate closeEvent;

        internal RecipePanel()
        {
            InitializeComponent();
        }



        private void HideAddNewContentPanel()
        {
            this.grdNewContent.Visibility = Visibility.Hidden;
            this.grdNewContentAdd.Visibility = Visibility.Visible;
        }

        private void ShowAddNewContentPanel()
        {
            this.grdNewContentAdd.Visibility = Visibility.Hidden;
            this.grdNewContent.Visibility = Visibility.Visible;
        }

        private void btnContentSubmit_Click(object sender, RoutedEventArgs e)
        {
            content.Name = this.txtContentName.Text;
            content.type = (Tag)this.cmbContentType.SelectedIndex;
            addNewContentToDatabaseEvent(content);

        }

        private void btnNewContent_Click(object sender, RoutedEventArgs e)
        {
            content = new Content();
            ShowAddNewContentPanel();
        }

        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {

            content.Quantity = Double.Parse(this.txtContentQuantity.Text);
            addToListOfContentsEvent(content);
            closeEvent();
        }

        private void btnContentCancel_Click(object sender, RoutedEventArgs e)
        {
            HideAddNewContentPanel();
            content = null;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            closeEvent();
        }
    }
}
