using SQLite;
using SQLiteCrossPlatform.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteCrossPlatform.Model.Database
{
    public class DatabaseAccess
    {

        private SQLiteAsyncConnection database;

        public DatabaseAccess(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
        }


        public async Task<List<T>> GetItemsAsync<T>() where T : ATable, new()
        {
            return await database.Table<T>().ToListAsync();
        }


        public async Task<T> GetItemAsync<T>(int id) where T : ATable, new()
        {
            return await database.Table<T>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> InsertOrUpdateItemAsync<T>(T item) where T : ATable, new()
        {
            if (item.ID != 0)
            {
                return await database.UpdateAsync(item);
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync<T>(T item) where T : ATable, new()
        {
            return await database.DeleteAsync(item);
        }
    }
}
