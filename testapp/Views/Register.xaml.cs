using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.Diagnostics;

namespace testapp.Views
{
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

       async void Register_Clicked(object sender, EventArgs e)
        {
            var user = new BaseUser(edtName.Text, edtEmail.Text, edtPw.Text);
            Debug.WriteLine(@"" + edtName.Text);
            await App.userManager.RegisterTaskAsync(user);
            //await Navigation.PopAsync();
        }
    }
}
