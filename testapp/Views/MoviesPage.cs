using System;

using Xamarin.Forms;

namespace testapp.Views
{
    public class MoviesPage : ContentPage
    {
        public MoviesPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

