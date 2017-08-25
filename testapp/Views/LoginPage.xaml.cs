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

        async void LoginClick(object sender, EventArgs e)
        {
            await App.userManager.LoginTaskAsync(edtEmail.Text, edtPw.Text);
        }

        void RegisterClickEvent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Register());
        }
    }
}
