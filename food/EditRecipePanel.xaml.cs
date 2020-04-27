using System;
using System.Windows;
using System.Windows.Controls;

namespace food
{
    /// <summary>
    /// Logique d'interaction pour EditRecipePanel.xaml
    /// </summary>
    public partial class EditRecipePanel : UserControl
    {
        internal Delegates.closeAddContentPanelDelegate closeEvent;
        internal Delegates.editRecipeContentDelegate editRecipeContent;
        internal Delegates.removeRecipeContentDelegate removeRecipeContent;
        private string uid = "";
        internal EditRecipePanel(string name, RecipeContent content)
        {
            InitializeComponent();
            lblContentName.Content = name;
            txtContentQuantity.Text = content.Quantity.ToString();
            cmbQuantityUnit.SelectedIndex = (int)content.QuantityUnit;
            uid = content.uid;
            cmbQuantityUnit.ItemsSource = Generator.units;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            closeEvent();
        }

        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            Unit unit = (cmbQuantityUnit.SelectedIndex > -1) ? (Unit)cmbQuantityUnit.SelectedIndex : Unit.Unknown;
            editRecipeContent(uid, Double.Parse(txtContentQuantity.Text), unit);
            closeEvent();
        }

        private void btnContentRemove_Click(object sender, RoutedEventArgs e)
        {
            removeRecipeContent(uid);
            closeEvent();
        }
    }
}
