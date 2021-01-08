using Pi4.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pi4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryItemsPage : ContentPage
    {
        List<CategoryItem> categoryItems;

        public CategoryItemsPage()
        {
            InitializeComponent();
            categoryItems = new List<CategoryItem>();
            CategoryItem categoryItem2 = new CategoryItem()
            {
                Title = "Een prachtige titel met link",
                ShortDescription = "Beschijving",
                Link = "https://koenhabets.nl"
            };
            categoryItems.Add(categoryItem2);
            categoryItems.Add(new CategoryItem() { Title = "Nieuw item toevoegen" });
            ListViewCategoryItems.ItemsSource = categoryItems;
        }

        private void ListViewCategoryItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ListViewCategoryItems.SelectedItem != null)
            {
                var selectedCategoryItem = ListViewCategoryItems.SelectedItem as CategoryItem;
                if (selectedCategoryItem.Title == "Nieuw item toevoegen")
                {
                    Navigation.PushAsync(new NewCategoryItemPage());
                }
                else
                {
                    if (selectedCategoryItem.Link != "" && selectedCategoryItem.Link != null)
                    {
                        Device.OpenUri(new Uri(selectedCategoryItem.Link));
                    }
                    else
                    {
                        Navigation.PushAsync(new CategoryItemDeatailPage());
                    }
                }
            }
            ((ListView)sender).SelectedItem = null;
        }
    }
}