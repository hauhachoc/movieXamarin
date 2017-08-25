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
				await App.userManager.RegisterTaskAsync(user);
				//await Navigation.PopAsync();
        }

   //     public bool ValidateView(){
            
   //         if(edtName.Text.Length==0){
   //             ShowAlert("Alert", "Name is empty");
   //             return false;
   //         }else{
   //             return true;
   //         }

			//if (edtEmail.Text.Length == 0)
			//{
			//	ShowAlert("Alert", "Email is empty");
			//return false;
   //         }
			//else
			//{
			//	return true;
			//}

   //         if (edtPw.Text.Length == 0 || edtConfirmPw .Text.Length == 0)
			//{
			//	ShowAlert("Alert", "Password is empty");
			//    return false;
   //         }
			//else
			//{
			//	return true;
			//}
        //    return false;
        //}

        public void ShowAlert(string title, string content){
			DisplayAlert(title, content, "OK");
		}
    }
}
