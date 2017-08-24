using Xamarin.Forms;

namespace testapp
{
    public partial class App : Application
    {
        public static Data.BaseUserManager userManager { get; private set; }
        public App()
        {
			//InitializeComponent();
			userManager = new Data.BaseUserManager(new Data.RestService());
			MainPage = new NavigationPage(new testappPage());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
