using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using popo.Model;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RenameCategoryPopup : PopupPage
    {

        public RenameCategoryPopup(CategoryModel selectedCategory = null)
        {
            InitializeComponent();
            this.selectedCategory = selectedCategory;
            CurrentNameLabel.Text = selectedCategory.Category_Name;
        }
        private CategoryModel selectedCategory;
        private async void OnCancelClicked(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private async void OnSaveClicked(object sender, System.EventArgs e)
        {
            // Save the new name here
            string NewCategoryName = NewNameEntry.Text;

            if (string.IsNullOrWhiteSpace(NewCategoryName))
            {
                await DisplayAlert("Invalid", "Enter Product Name!", "OK");
            }
            else
            {
                UpdateCategoryName();
            }
        }
        async void UpdateCategoryName()
        {
            selectedCategory.Category_Name = NewNameEntry.Text;
            await App.CategoryDatabase.UpdateCategory(selectedCategory);
            await DisplayAlert("Success", "Updated Category Name", "OK");
            // Close the popup
            await PopupNavigation.Instance.PopAsync();
        }
    }
}