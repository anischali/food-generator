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
    internal struct TempLine
    {
        internal TextBox name { get; set; }
        internal TextBox quantity { get; set; }
        internal Button edit { get; set; }
        internal Button remove { get; set; }
    };

    public partial class AddRecipePage 
    {
        public AddRecipePage()
        {
            InitializeComponent();
        }

       

        private void btnAddContent_Click(object sender, RoutedEventArgs e)
        {

            lstContententList.Items.Add(new TempLine { name = new TextBox(), quantity = new TextBox() }) ;
            
        }
    }
}
