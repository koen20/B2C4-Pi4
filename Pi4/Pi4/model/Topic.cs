using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pi4.model
{
    public class Topic
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
    }
}
