using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using testapp.Utils;
using testapp.Models.Response;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace testapp.Views
{
    public partial class MoviesPage : ContentPage
    {

        IList<Film> films;
        Task<FilmsResponse> data;

        public MoviesPage()
        {
			InitializeComponent();
			data = App.userManager.GetFilmsTasksAsync("1", "20");
			FilmsResponse filmRes = data.Result;
			if (filmRes.error)
			{
				ShowAlert(null, "get films failed");
			}
			else
			{
				films = data.Result.data;
			}
			listView.ItemsSource = films;
			listView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
				if (e.SelectedItem == null)
					return;

				//Navigation.PushAsync(new DetailPage(e.SelectedItem.ToString()));
				listView.SelectedItem = null;
			};

			add.Clicked += (object sender, EventArgs e) => {
				if (Application.Current.Properties.ContainsKey("token"))
				{
                    string token = Application.Current.Properties["token"] as string;
                    note.Text = token;
				}
			};
        }

		public void ShowAlert(string title, string content)
		{
			DisplayAlert(title, content, "OK");
		}

    }
}
