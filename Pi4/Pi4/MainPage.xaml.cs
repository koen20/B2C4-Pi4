using Pi4.model;
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
        List<Topic> topics;
        public MainPage()
        {
            InitializeComponent();

            topics = new List<Topic>();
            topics.Add(new Topic("onderwerp1"));
            topics.Add(new Topic("onderwerp2"));
            topics.Add(new Topic("Onderwerp toevoegen"));
            listViewTopics.ItemsSource = topics;
        }

        private void listViewTopics_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listViewTopics.SelectedItem != null)
            {
                var selectedTopic = listViewTopics.SelectedItem as Topic;
                if (selectedTopic.Title == "Onderwerp toevoegen")
                {
                    Navigation.PushAsync(new AddTopicPage());
                }
                else
                {
                    Navigation.PushAsync(new SubjectPage());
                }
            }
            ((ListView)sender).SelectedItem = null;
        }

    }
}
