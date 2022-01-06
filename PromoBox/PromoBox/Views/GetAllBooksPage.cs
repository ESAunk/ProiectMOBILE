using PromoBox.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PromoBox.Views
{
    public class GetAllBooksPage : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myDB.db3");

        public GetAllBooksPage()
        {
            this.Title = "Book Reviews";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Book>().OrderBy(x => x.BookName).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;

        }
    }
}