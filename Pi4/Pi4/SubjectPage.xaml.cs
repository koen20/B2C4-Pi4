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
    public partial class SubjectPage : ContentPage
    {
        ObservableCollection<Category> categories;

        public SubjectPage()
        {
            InitializeComponent();
            categories = new ObservableCollection<Category>();
            categories.Add(new Category("Tips"));
            categories.Add(new Category("Handige links"));
            categories.Add(new Category("Categorie toevoegen"));
            ListViewTopicCategories.ItemsSource = categories;
        }

        private void ListViewTopicCategories_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ListViewTopicCategories.SelectedItem != null)
            {
                var selectedCategory = ListViewTopicCategories.SelectedItem as Category;
                if (selectedCategory.Title == "Categorie toevoegen")
                {
                    NewCategory();
                }
                else
                {
                    Navigation.PushAsync(new CategoryItemsPage());

                }
                ListViewTopicCategories.SelectedItem = null;
            }
        }

        async void NewCategory()
        {
            string result = await DisplayPromptAsync("Nieuwe categorie", "Voer de naam van de nieuwe categorie in");
            categories.Add(new Category(result));

        }
        }
}