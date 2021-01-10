using Pi4.model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pi4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCategoryItemPage : ContentPage
    {
        CategoryItem categoryItem;
        public NewCategoryItemPage(CategoryItem categoryItem)
        {
            InitializeComponent();
            this.categoryItem = categoryItem;

        }

        private void SaveToolbarItem_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {

                categoryItem.Title = entryTitle.Text;
                categoryItem.Link = entryLink.Text;
                categoryItem.ShortDescription = entryDesc.Text;
                categoryItem.Content = entryContent.Text;
                if (categoryItem.Title == "" || categoryItem.Title == null) {
                    DisplayAlert("Mislukt", "Een item moet een titel hebben", "Ok");
                    return;
                }
                connection.CreateTable<CategoryItem>();
                int rows = connection.Insert(categoryItem);
                if (rows == 0)
                {
                    DisplayAlert("Mislukt", "Het item kon niet worden toegevoegd", "Ok");
                }
                else {
                    Navigation.PopAsync();
                }
            }
        }

        private void DeleteToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private async void ButtonIcon_Clicked(object sender, EventArgs e)
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);

                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "image-" + (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) + ".png");

                using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }

                categoryItem.ImageIcon = fileName;
            }
        }

        private async void ButtonCover_Clicked(object sender, EventArgs e)
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);

                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "image-" + (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) + ".png");

                using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }

                categoryItem.ImageCover = fileName;
            }
        }
    }
}