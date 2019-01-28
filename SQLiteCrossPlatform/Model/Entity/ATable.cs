using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteCrossPlatform.Model.Entity
{
    public abstract class ATable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
