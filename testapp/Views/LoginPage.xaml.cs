using Xamarin.Forms;
using System;

namespace testapp
{
    public partial class testappPage : ContentPage
    {
        public testappPage()
        {
            InitializeComponent();
        }

         void LoginClick(object sender, EventArgs e)
        {
             App.userManager.LoginTaskAsync(edtEmail.Text, edtPw.Text);
             Navigation.PushAsync(new Views.MoviesPage());
        }

        void RegisterClickEvent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Register());
        }
    }
}
