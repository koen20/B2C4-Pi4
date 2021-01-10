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
        private Topic topic;
        public AddTopicPage(Topic topic)
        {
            InitializeComponent();
            this.topic = topic;
        }

        private void SaveToolbarItem_Clicked(object sender, EventArgs e)
        {
            Topic topic = new Topic() { Title = entryTopicName.Text };

            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation)) {
                connection.CreateTable<Topic>();
                int rows = connection.Insert(topic);
                if (rows == 0)
                {
                    DisplayAlert("Mislukt", "Het onderwerp kon niet worden toegevoegd", "Ok");
                }
                else {
                    Navigation.PopAsync();
                }
            }
        }

        private void DeleteToolbarItem_Clicked(object sender, EventArgs e)
        {

            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Topic>();
                connection.Delete(topic);
            }
        }
    }
}