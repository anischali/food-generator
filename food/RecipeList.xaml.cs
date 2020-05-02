﻿using System;
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
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class RecipeList : UserControl
    {
        private AddRecipePage EditRecipePage;

        public RecipeList()
        {
            InitializeComponent();
            RecipeListPopulate();
        }

        private void RecipeListPopulate()
        {
            if (IO.Database.AllMenus == null)
                return;
            foreach(Recipe r in IO.Database.AllMenus)
            {
                vwlRecipeList.Items.Add(r.title);
            }
        }

        private void GoBackHere()
        {
            vwlRecipeList.Items.Clear();
            RecipeListPopulate();
            GrdListView.Children.Remove(EditRecipePage);
        }

        private void BtnEditRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe SelectedRecipe =  Tools.FindRecipeByTitle((string)vwlRecipeList.SelectedItem);
            if (SelectedRecipe == null)
                return;
            EditRecipePage = new AddRecipePage(SelectedRecipe);
            EditRecipePage.HomePanel += GoBackHere;
            
            GrdListView.Children.Add(EditRecipePage);

        }

        private void BtnViewRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe SelectedRecipe = Tools.FindRecipeByTitle((string)vwlRecipeList.SelectedItem);
            if (SelectedRecipe == null)
                return;
            EditRecipePage = new AddRecipePage(SelectedRecipe, true);
            EditRecipePage.HomePanel += GoBackHere;

            GrdListView.Children.Add(EditRecipePage);
        }

        private void BtnRemoveRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe SelectedRecipe = Tools.FindRecipeByTitle((string)vwlRecipeList.SelectedItem);
            if (SelectedRecipe == null)
                return;
            IO.Database.AllMenus.Remove(SelectedRecipe);
            IO.Database.SaveAllDatabases();
            vwlRecipeList.Items.Clear();
            RecipeListPopulate();

        }
    }
}