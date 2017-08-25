using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using testapp.Utils;

namespace testapp.Views
{
    public partial class MoviesPage : ContentPage
    {

		ObservableCollection<string> notes;
		IPlatformPreferences prefs;

        public MoviesPage()
        {
			InitializeComponent();
			prefs = DependencyService.Get<IPlatformPreferences>();
			if (prefs == null)
			{
				notes = new ObservableCollection<string>();
			}
			else
			{
				notes = new ObservableCollection<string>(prefs.getUserInfo());
			}

			listView.ItemsSource = notes;
			listView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
				if (e.SelectedItem == null)
					return;

				//Navigation.PushAsync(new DetailPage(e.SelectedItem.ToString()));
				listView.SelectedItem = null;
			};

			add.Clicked += (object sender, EventArgs e) => {
				notes.Add(note.Text);
				note.Text = "";
				if (prefs != null)
				{
					prefs.saveUserInfo(notes);
				}
			};
        }

		public void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			string item = (string)mi.CommandParameter;
			notes.Remove(item);
		}

		public void OnClearNotes(object sender, EventArgs e)
		{
			notes.Clear();
			if (prefs != null)
			{
				prefs.saveUserInfo(notes);
			}
		}

    }
}
