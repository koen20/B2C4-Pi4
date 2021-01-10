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
    public partial class SubjectPage : ContentPage
    {
        private Topic topic;

        public SubjectPage(Topic topic)
        {
            this.topic = topic;
            Title = topic.Title;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateCategories();
        }

        private void UpdateCategories() {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Category>();
                List<Category> categories = connection.Query<Category>("SELECT * FROM Category WHERE TopicId = ?", topic.Id).ToList();
                categories.Add(new Category() { Title = "Categorie toevoegen" });
                ListViewTopicCategories.ItemsSource = categories;
            }
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
                    Navigation.PushAsync(new CategoryItemsPage(selectedCategory));

                }
                ListViewTopicCategories.SelectedItem = null;
            }
        }

        async void NewCategory()
        {
            string result = await DisplayPromptAsync("Nieuwe categorie", "Voer de naam van de nieuwe categorie in");
            if (result != "")
            {
                Category category = new Category() { Title = result, TopicId = topic.Id };

                using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
                {
                    connection.CreateTable<Category>();
                    int rows = connection.Insert(category);
                    if (rows == 0)
                    {
                        DisplayAlert("Mislukt", "De categorie kon niet worden toegevoegd", "Ok");
                    }
                }
                UpdateCategories();
            }
        }
    }
}