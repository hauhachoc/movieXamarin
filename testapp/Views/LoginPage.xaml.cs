using Xamarin.Forms;
using System;
using testapp.Models.Response;
using testapp.Data;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;

namespace testapp
{
    public partial class testappPage : ContentPage
    {

        public Task<BaseResponse> task;

        public BaseResponse Response { set; get; }

        public testappPage()
        {
            InitializeComponent();
        }

         void LoginClick(object sender, EventArgs e)
        {
            //App.userManager.LoginTaskAsync(edtEmail.Text, edtPw.Text);
            Response = new BaseResponse();
            task =  App.userManager.LoginTaskAsync(edtEmail.Text, edtPw.Text);
            Response = task.Result;
			if (Response.error)
			{
                ShowAlert(null, "Login Failed" );
			}
			else
			{
                Debug.WriteLine(@"             Success:" + Response.data.ToString());
                Application.Current.Properties["token"] =  Response.data.access_token;
				Navigation.PushAsync(new Views.MoviesPage());
			}
        }

        void RegisterClickEvent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Register());
        }

		public void ShowAlert(string title, string content)
		{
			DisplayAlert(title, content, "OK");
		}
    }
}
