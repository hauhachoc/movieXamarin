using Xamarin.Forms;
using System;
using System.Diagnostics;
using testapp.Models.Response;
using System.Threading.Tasks;

namespace testapp.Views
{
    public partial class Register : ContentPage
    {

        public BaseResponse Response { set; get; }
        public Task<BaseResponse> task;

        public Register()
        {
            InitializeComponent();
        }

        void Register_Clicked(object sender, EventArgs e)
        {
				var user = new BaseUser(edtName.Text, edtEmail.Text, edtPw.Text);
    			Response = new BaseResponse();
    			task = App.userManager.RegisterTaskAsync(user);
    			Response = task.Result;
    			if (Response.error)
    			{
    				ShowAlert(null, "Register Failed");
    			}
    			else
    			{
    				Debug.WriteLine(@"             Success:" + Response.data.ToString());
                    ShowAlert(null, "Register successful");
				    Application.Current.Properties["token"] = Response.data.access_token;
				    Navigation.PushAsync(new Views.MoviesPage()).ConfigureAwait(false);
			}
        }

        public void ShowAlert(string title, string content){
			DisplayAlert(title, content, "OK");
		}
    }
}
