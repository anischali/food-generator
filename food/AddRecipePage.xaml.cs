﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace food
{
    internal class ContentBind
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

    }
    /// <summary>
    /// Logique d'interaction pour AddRecipePage.xaml
    /// </summary>


    public partial class AddRecipePage
    {
        internal Delegates.returnToHomePanel HomePanel;
        private Recipe recipe;
        private RecipePanel AddPanelView = null;
        private bool isPanelViewVisible = false;
        private bool IsEditMode = false;
        private bool IsReadOnlyMode = false;
        
        internal AddRecipePage(Recipe RecipeToEdit = null, bool IsReadOnly = false)
        {
            InitializeComponent();
            if (RecipeToEdit == null)
            {
                recipe = new Recipe();
                PopulateTagsList();
                return;
            }
            recipe = RecipeToEdit;
            IsEditMode = true;
            IsReadOnlyMode = IsReadOnly;
            LoadRecipe();
             
        }


        private void LoadRecipe()
        {
            UpdateListView();
            txtRecipeTitle.Text = recipe.title;
            txtPeopleNumber.Text = recipe.PeopleNumber.ToString();
            rtxtRecipeDescription.AppendText(recipe.Description);
            if (IsReadOnlyMode)
            {
                ReadOnlyModePopulateTagsList();
                return;
            }
            PopulateTagsList(true);
        }

        private void AddToListRecipe(RecipeContent content)
        {
            recipe.Contents.Add(content);
        }

        private void AddToListViewRecipe(RecipeContent content)
        {
            ContentBind cb = new ContentBind()
            {
                Name = Tools.FindContentNameByUid(content.uid),
                Quantity = content.Quantity,
                Unit = ((content.QuantityUnit != Unit.Undefined) ?
                Generator.units[((int)content.QuantityUnit)] : "Unknown")
            };
            lstContententList.Items.Add(cb);
        }

        private void UpdateListView()
        {
            lstContententList.Items.Clear();
            foreach (RecipeContent rc in recipe.Contents)
            {
                AddToListViewRecipe(rc);
            }
        }
        private void CloseSubPanels()
        {
            gridAddPanelPlace.Children.Clear();
            gridAddPanelPlace.Visibility = Visibility.Hidden;
            AddPanelView = null;
            isPanelViewVisible = false;
            UpdateListView();
        }

        private void BtnAddContent_Click(object sender, RoutedEventArgs e)
        {
            if (isPanelViewVisible || IsReadOnlyMode)
                return;
            AddPanelView = new RecipePanel();
            AddPanelView.addToListOfContentsEvent += AddToListRecipe;
            AddPanelView.closeEvent += CloseSubPanels;
            AddPanelView.addNewContentToDatabaseEvent += IO.Database.AddContentToDatabase;
            this.gridAddPanelPlace.Visibility = Visibility.Visible;
            this.gridAddPanelPlace.Children.Add(AddPanelView);
            isPanelViewVisible = true;

        }


        private void RemoveRecipeContent(string uid)
        {
            if (IsReadOnlyMode)
                return;
            foreach (RecipeContent rc in recipe.Contents)
            {
                if (rc.uid == uid)
                {
                    recipe.Contents.Remove(rc);
                    break;
                }
            }
        }

        private void EditRecipeContent(string uid, double quantity, Unit unit)
        {
            if (IsReadOnlyMode)
                return;
            foreach (RecipeContent rc in recipe.Contents)
            {
                if (rc.uid == uid)
                {
                    rc.Quantity = quantity;
                    rc.QuantityUnit = unit;
                    break;
                }
            }
        }

        private void LstContententList_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lstContententList.SelectedItem == null || recipe.Contents.Count <= 0)
                return;
            ContentBind content = (ContentBind)lstContententList.SelectedItem;
            RecipeContent rc = Tools.FindRecipeContentByName(recipe.Contents, content.Name);
            if (rc == null)
                return;
            EditRecipePanel editPanel = new EditRecipePanel(content.Name, rc);
            editPanel.editRecipeContent += EditRecipeContent;
            editPanel.removeRecipeContent += RemoveRecipeContent;
            editPanel.closeEvent += CloseSubPanels;
            this.gridAddPanelPlace.Visibility = Visibility.Visible;
            this.gridAddPanelPlace.Children.Add(editPanel);
            isPanelViewVisible = true;
        }


        public void OnTagCheckedEvent(object sender, RoutedEventArgs args)
        {
            if (IsReadOnlyMode)
                return;
            CheckBox senderBox = (CheckBox)sender;
            recipe.Tags.Add((Tag)senderBox.Tag);
            lblActiveTagsNumber.Content = recipe.Tags.Count.ToString();

        }

        internal void OnTagUncheckedEvent(object sender, RoutedEventArgs args)
        {
            if (IsReadOnlyMode)
                return;
            CheckBox senderBox = (CheckBox)sender;
            recipe.Tags.Remove((Tag)senderBox.Tag);
            lblActiveTagsNumber.Content = recipe.Tags.Count.ToString();

        }


        private CheckBox CreateCheckBox(int tagIdx, bool checkBoxState = false)
        {
            CheckBox chbTemp = new CheckBox();
            chbTemp.IsChecked = checkBoxState;
            chbTemp.Content = Generator.tags[tagIdx];
            chbTemp.Tag = tagIdx;
            chbTemp.Checked += new RoutedEventHandler(OnTagCheckedEvent);
            chbTemp.Unchecked += new RoutedEventHandler(OnTagUncheckedEvent);
            return chbTemp;
        }

        internal void PopulateTagsList(bool isEdit = false)
        {
            List<CheckBox> lst = new List<CheckBox>();
            
            for (int i = 0; i < Generator.tags.Length; ++i)
            {
                if (isEdit)
                {
                    if (recipe.Tags.Contains((Tag) i))
                    {
                        lst.Add(CreateCheckBox(i, true));
                        continue;
                    }
                }
                lst.Add(CreateCheckBox(i));
            }
            cmbRecipeTags.ItemsSource = lst;
            lblActiveTagsNumber.Content = recipe.Tags.Count.ToString();
        }



        internal void ReadOnlyModePopulateTagsList()
        {
            List<string> lst = new List<string>();

            for (int i = 0; i < Generator.tags.Length; ++i)
            {
                if (recipe.Tags.Contains((Tag)i))
                {
                    lst.Add(Generator.tags[i]);
                    continue;
                }
            }
            cmbRecipeTags.ItemsSource = lst;
            cmbRecipeTags.IsReadOnly = IsReadOnlyMode;
            lblActiveTagsNumber.Content = recipe.Tags.Count.ToString();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            HomePanel();
        }

        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            if (!IsReadOnlyMode)
            {
                recipe.PeopleNumber = (recipe.PeopleNumber < 1) ? 1 : recipe.PeopleNumber;
                recipe.title = txtRecipeTitle.Text;
                recipe.Description = new TextRange(rtxtRecipeDescription.Document.ContentStart, rtxtRecipeDescription.Document.ContentEnd).Text;
                IO.Database.AddRecipeToDatabase(recipe, IsEditMode);
            }
            HomePanel();
        }

        private void txtPeopleNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsReadOnlyMode)
            {
                recipe.PeopleNumber = (int)Tools.ParseDouble(txtPeopleNumber.Text);
                txtPeopleNumber.Text = (recipe.PeopleNumber < 1) ? "" : recipe.PeopleNumber.ToString();
            }
            else 
            {
                txtPeopleNumber.Text = recipe.PeopleNumber.ToString();
            }
        }
    }




}
