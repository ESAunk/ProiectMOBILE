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
    public class DeleteBookPage : ContentPage
    {
        private ListView _listView;
        private Button _button;

        Book _book = new Book();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myDB.db3");

        public DeleteBookPage()
        {
            this.Title = "Delete Book Review";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Book>().OrderBy(x => x.BookName).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Delete";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;

        }
        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _book = (Book)e.SelectedItem;
        }
        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Book>().Delete(x => x.Id == _book.Id);
            await Navigation.PopAsync();
        }
    }
}