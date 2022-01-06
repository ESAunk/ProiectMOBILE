using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PromoBox.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Select Option";
            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Add Book Review";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "My Reviews";
            button.Clicked += Button_Get_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Edit Reviews";
            button.Clicked += Button_Edit_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Delete Reviews";
            button.Clicked += Button_Delete_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
            
        }
     
        private  async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBookPage());
        }
        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllBooksPage());
        }
        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditBookPage());
        }
        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteBookPage());
        }
    }
}