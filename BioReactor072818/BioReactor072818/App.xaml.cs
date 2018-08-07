using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace BioReactor072818
{
	public partial class App : Application
	{



		public App ()
		{
			InitializeComponent();

            //Navigation page allows you to use Navigation.PushAsync() and .PopAsync() to navigate
            //MainPage = new NavigationPage(new MainPage());
            MainPage = new NavigationPage(new RecipePage());
		}

        /// <summary>
        /// This keeps track of the prerun checkoff list index that you're at
        /// </summary>
        public int ResumeAtTodoId { get; set; }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
