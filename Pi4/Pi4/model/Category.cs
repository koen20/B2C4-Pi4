using System;
using System.Collections.Generic;
using System.Text;

namespace Pi4.model
{
    class Category
    {
        public Category(string Title)
        {
            this.Title = Title;
        }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
