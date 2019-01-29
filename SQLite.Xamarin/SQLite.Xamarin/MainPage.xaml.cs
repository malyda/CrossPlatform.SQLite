using SQLiteCrossPlatform;
using SQLiteCrossPlatform.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLite.Xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            DBSample dBSample = new DBSample();


            var items = Task.Run<List<TodoItem>>(async () =>
            {
                return await dBSample.Test();
            }).Result;

            itemsListView.ItemsSource = items;
        }
    }
}
