using System;
using System.Collections.Generic;
using System.Text;

namespace Pi4.model
{
    class Topic
    {
        public Topic(string Title)
        {
            this.Title = Title;
        }
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
