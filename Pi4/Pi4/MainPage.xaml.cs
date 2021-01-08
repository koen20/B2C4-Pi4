using Pi4.model;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pi4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateTopics();
        }

        private void UpdateTopics() {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Topic>();
                List<Topic> topics = connection.Table<Topic>().ToList();
                topics.Add(new Topic() { Title = "Onderwerp toevoegen" });
                listViewTopics.ItemsSource = topics;
            }
        }

        private void listViewTopics_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listViewTopics.SelectedItem != null)
            {
                var selectedTopic = listViewTopics.SelectedItem as Topic;
                if (selectedTopic.Title == "Onderwerp toevoegen")
                {
                    Navigation.PushAsync(new AddTopicPage());
                    UpdateTopics();
                }
                else
                {
                    Navigation.PushAsync(new SubjectPage(selectedTopic));
                }
            }
            ((ListView)sender).SelectedItem = null;
        }

    }
}
