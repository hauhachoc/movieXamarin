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

        void Handle_Clicked(object sender, EventArgs e)
        {
            //var name = edtName.Text;
            //lblName.Text =name;
        }

        void RegisterClickEvent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Register());
        }
    }
}
