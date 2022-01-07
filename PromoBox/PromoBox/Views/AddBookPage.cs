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
    public class AddBookPage : ContentPage
    {
        private Entry _bookEntry;
        private Entry _reviewEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myDB.db3");
        public AddBookPage()
        {
            this.Title = "Add Book Review";
            StackLayout stackLayout = new StackLayout();
            _bookEntry = new Entry();
            _bookEntry.Keyboard = Keyboard.Text;
            _bookEntry.Placeholder = "Book Name";
            stackLayout.Children.Add(_bookEntry);

            _reviewEntry = new Entry();
            _reviewEntry.Keyboard = Keyboard.Text;
            _reviewEntry.Placeholder = "Add a review";
            stackLayout.Children.Add(_reviewEntry);
               

            _saveButton = new Button();
            _saveButton.Text = "Add";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);



            Content = stackLayout;
        }
        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Book>();

            var maxPk = db.Table<Book>().OrderByDescending(c => c.Id).FirstOrDefault();

            Book book = new Book()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                BookName = _bookEntry.Text,
                BookReview = _reviewEntry.Text
            };
            db.Insert(book);
            await DisplayAlert(null, book.BookName + " - Saved", "Ok");
            await Navigation.PopAsync();
        }

    }
}