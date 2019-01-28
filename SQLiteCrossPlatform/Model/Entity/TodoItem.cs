using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteCrossPlatform.Model.Entity
{
    public class TodoItem: ATable
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return "ID" + ID + " Name " + Name + " Text " + Text;
        }
    }
}
