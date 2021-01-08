using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pi4.model
{
    class CategoryItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string ShortDescription { get; set; }
        [MaxLength(2000)]
        public string Content { get; set; }
        [MaxLength(250)]
        public string Link { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
    }
}
