using SQLiteCrossPlatform.Model.Database;
using SQLiteCrossPlatform.Model.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace SQLiteCrossPlatform
{
    public class DBSample
    {
        /// <summary>
        /// Used only for Abstract and SQLiteExtensions database access
        /// Path should be private
        /// </summary>
        public static string DbPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData,
                    Environment.SpecialFolderOption.Create)
                    ,"TodoSQLite.db3"); 
            }
        }
        public async Task<List<TodoItem>> Test()
        {
            List<String> x = new List<string>();
            x.Add("a");

            var l = Newtonsoft.Json.JsonConvert.SerializeObject(x);


           DatabaseAccess todoItemDatabase = new DatabaseAccess(DbPath);

            // Create object to insert to database
            TodoItem item = new TodoItem();
            item.Name = "item";
            item.Text = "item text";

            // Insert
            await todoItemDatabase.InsertOrUpdateItemAsync(item);

            // Get all object from database based on object type
            var itemsFromDb = todoItemDatabase.GetItemsAsync<TodoItem>().Result;

            // Write all objects from database to console
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(itemsFromDb.Count);
            foreach (TodoItem todoItem in itemsFromDb)
            {
                Debug.WriteLine(todoItem);
            }
            return itemsFromDb;
        }
    }
}
