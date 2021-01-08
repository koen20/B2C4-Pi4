using System;
using System.Collections.Generic;
using System.Text;

namespace Pi4.model
{
    class CategoryItem
    {
        public CategoryItem(string Title)
        {
            this.Title = Title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
    }
}
