using Pi4.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pi4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryItemDeatailPage : ContentPage
    {
        private CategoryItem categoryItem;
        public CategoryItemDeatailPage(CategoryItem categoryItem)
        {
            this.categoryItem = categoryItem;
            InitializeComponent();
            labelTitle.Text = categoryItem.Title;
            labelContent.Text = categoryItem.Content;
            if (categoryItem.ImageCover == null)
            {
                stackLayout.Children.Remove(imageItem);
            }
            else {
                imageItem.Source = categoryItem.ImageCover;
            }
            
        }

        private void ShareToolbarItem_Clicked(object sender, EventArgs e)
        {
            ShareItem(categoryItem);
        }

        public void ShareItem(CategoryItem categoryItem)
        {
            Share.RequestAsync(new ShareTextRequest
            {
                Text = categoryItem.Content,
                Title = categoryItem.Title
            });
        }
    }
}