using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace food
{
    /// <summary>
    /// Logique d'interaction pour RecipePanel.xaml
    /// </summary>
    public partial class RecipePanel : UserControl
    {
        private Content content;
        internal Delegates.addToListOfContentsDelegate addToListOfContentsEvent;
        internal Delegates.addContentsToDatabaseDelegate addNewContentToDatabaseEvent;
        internal Delegates.closeAddContentPanelDelegate closeEvent;

        internal RecipePanel()
        {
            InitializeComponent();
            PopulateAllComboBoxs();
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
            content = new Content();
            int idx = cmbContentType.SelectedIndex;
            content.Name = this.txtContentName.Text;
            content.type = (Tag)((idx != -1) ? idx + 4 : idx);
            addNewContentToDatabaseEvent(content);
            PopulateContentComboBox();
            HideAddNewContentPanel();
        }

        private void btnNewContent_Click(object sender, RoutedEventArgs e)
        {
            ShowAddNewContentPanel();
        }

        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            int idx = cmbContent.SelectedIndex;
            if (idx < 0)
                return;
            content = new Content();
            content.uid = IO.Database.contents[idx].uid;
            content.Name = IO.Database.contents[idx].Name;
            content.type = IO.Database.contents[idx].type;
            content.Quantity = Double.Parse(this.txtContentQuantity.Text);
            content.QuantityUnit = (Unit) this.cmbQuantityUnit.SelectedIndex;
            addToListOfContentsEvent(content);
            closeEvent();
        }

        private void btnContentCancel_Click(object sender, RoutedEventArgs e)
        {
            HideAddNewContentPanel();
            content = null;
        }

        
        private void PopulateAllComboBoxs()
        {
            List<string> contentsType = new List<string>(Generator.tags);
            contentsType.RemoveRange(0, 4);
            cmbContentType.ItemsSource = contentsType;
            PopulateContentComboBox();
            cmbQuantityUnit.ItemsSource = Generator.units;
        }

        private void PopulateContentComboBox()
        {
            List<string> allContentsString = IO.Database.contents.ConvertAll<string>(Tools.ContentToStringConverter);
            cmbContent.ItemsSource = allContentsString;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            closeEvent();
        }
    }
}
