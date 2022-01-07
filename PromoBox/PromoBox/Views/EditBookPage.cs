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
    public class EditBookPage : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _bookEntry;
        private Entry _reviewEntry;
        private Button _button;

        Book _book = new Book();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myDB.db3");
        public EditBookPage()
        {
            this.Title = "Edit Book Review";

            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Book>().OrderBy(x => x.BookName).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _bookEntry = new Entry();
            _bookEntry.Keyboard = Keyboard.Text;
            _bookEntry.Placeholder = "Book Name";
            stackLayout.Children.Add(_bookEntry);

            _reviewEntry = new Entry();
            _reviewEntry.Keyboard = Keyboard.Text;
            _reviewEntry.Placeholder = "Add a review";
            stackLayout.Children.Add(_reviewEntry);

            _button = new Button();
            _button.Text = "Update";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }
        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Book book = new Book()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                BookName = _bookEntry.Text,
                BookReview = _reviewEntry.Text
            };
            db.Update(book);
            await Navigation.PopAsync();
            
        }
        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _book = (Book)e.SelectedItem;
            _idEntry.Text = _book.Id.ToString();
            _bookEntry.Text = _book.BookName;
            _reviewEntry.Text = _book.BookReview;
        }
    }
}