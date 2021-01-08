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
    public partial class AddTopicPage : ContentPage
    {
        ObservableCollection<Category> categories;
        public AddTopicPage()
        {
            InitializeComponent();
            categories = new ObservableCollection<Category>();
            categories.Add(new Category() { Title = "Categorie toevoegen" });
            ListViewCategories.ItemsSource = categories;
        }

        private void ListViewCategories_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ListViewCategories.SelectedItem != null)
            {
                var selectedTopic = ListViewCategories.SelectedItem as Category;
                if (selectedTopic.Title == "Categorie toevoegen")
                {
                    NewCategory();

                }
            }
            ((ListView)sender).SelectedItem = null;
        }

        async void NewCategory()
        {
            string result = await DisplayPromptAsync("Nieuwe categorie", "Voer de naam van de nieuwe categorie in");
            categories.Add(new Category() { Title = result });
            
        }

        private void SaveToolbarItem_Clicked(object sender, EventArgs e)
        {
            Topic topic = new Topic() { Title = entryTopicName.Text };

            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation)) {
                connection.CreateTable<Topic>();
                int rows = connection.Insert(topic);
                if (rows == 0) {
                    DisplayAlert("Mislukt", "Het onderwerp kon niet worden toegevoegd", "Ok");
                }
            }
        }

        private void DeleteToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}