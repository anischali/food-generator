using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;

namespace food
{
    /// <summary>
    /// Logique d'interaction pour RecipePanel.xaml
    /// </summary>
    public partial class RecipePanel : UserControl
    {

        internal Delegates.addToListOfContentsDelegate addToListOfContentsEvent;
        internal Delegates.addContentsToDatabaseDelegate addNewContentToDatabaseEvent;
        internal Delegates.closeAddContentPanelDelegate closeEvent;

        internal RecipePanel()
        {
            InitializeComponent();
            PopulateAllComboBoxs();
            this.Loaded += OnLoad;
            this.KeyDown += OnEnterKeyPressed;
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            cmbContent.Focusable = true;
            cmbContent.Focus();
        }

        private void OnEnterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnValidate_Click(sender, e);
            }
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

            Content content = new Content();
            int idx = cmbContentType.SelectedIndex;
            content.Name = this.txtContentName.Text;
            content.type = (ContentTag)(idx);
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
            Content content = IO.Database.contents[idx];
            RecipeContent rcontent = new RecipeContent();
            rcontent.uid = content.uid;
            rcontent.Quantity = Tools.ParseDouble(this.txtContentQuantity.Text);
            rcontent.QuantityUnit = (Unit)this.cmbQuantityUnit.SelectedIndex;
            addToListOfContentsEvent(rcontent);
            closeEvent();
        }

        private void btnContentCancel_Click(object sender, RoutedEventArgs e)
        {
            HideAddNewContentPanel();
        }


        private void PopulateAllComboBoxs()
        {
            List<string> contentsType = new List<string>(Generator.contentTags);
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
