using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace food
{
    /// <summary>
    /// Logique d'interaction pour AddRecipePage.xaml
    /// </summary>
    public partial class AddRecipePage 
    {
        public AddRecipePage()
        {
            InitializeComponent();
            PopulateContentListViewHeaders();
        }

        private void PopulateContentListViewHeaders()
        {
            string[] header = {"Nom","Quantité","Modifier","Supprimer"};
            for (int i = 0; i < header.Length; ++i)
            {
            }
            
        }

        private void btnAddContent_Click(object sender, RoutedEventArgs e)
        {
            lstContententList.Items.Add("Patate");
            
        }
    }
}
