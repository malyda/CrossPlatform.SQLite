using SQLiteCrossPlatform;
using SQLiteCrossPlatform.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLite.NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            DBSample dBSample = new DBSample();


            var items = Task.Run<List<TodoItem>>(async () =>
           {
              return await dBSample.Test();
           }).Result;

            items.ForEach(Console.WriteLine);

            Console.WriteLine("Output is also in Debug window");
            Console.ReadKey();
        }
    }
}
