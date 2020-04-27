using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            editRecipeContent(uid,Double.Parse(txtContentQuantity.Text), unit);
            closeEvent();
        }

        private void btnContentRemove_Click(object sender, RoutedEventArgs e)
        {
            removeRecipeContent(uid);
            closeEvent();
        }
    }
}
