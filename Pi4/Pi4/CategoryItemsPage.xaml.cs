using Pi4.model;
using SQLite;
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
        private List<CategoryItem> categoryItems;
        private Category category;

        public CategoryItemsPage(Category category)
        {
            InitializeComponent();
            this.category = category;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateCategoryItems();
        }

        private void UpdateCategoryItems()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<CategoryItem>();
                List<CategoryItem> categoryItems = connection.Query<CategoryItem>("SELECT * FROM CategoryItem WHERE CategoryId = ?", category.Id).ToList();
                categoryItems.Add(new CategoryItem() { Title = "Nieuw item toevoegen" });
                ListViewCategoryItems.ItemsSource = categoryItems;
            }
        }

        private void ListViewCategoryItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ListViewCategoryItems.SelectedItem != null)
            {
                var selectedCategoryItem = ListViewCategoryItems.SelectedItem as CategoryItem;
                if (selectedCategoryItem.Title == "Nieuw item toevoegen")
                {
                    Navigation.PushAsync(new NewCategoryItemPage(new CategoryItem() { CategoryId = category.Id }));
                    UpdateCategoryItems();
                }
                else
                {
                    if (selectedCategoryItem.Link != "" && selectedCategoryItem.Link != null)
                    {
                        Device.OpenUri(new Uri(selectedCategoryItem.Link));
                    }
                    else
                    {
                        Navigation.PushAsync(new CategoryItemDeatailPage(selectedCategoryItem));
                    }
                }
            }
            ((ListView)sender).SelectedItem = null;
        }
    }
}