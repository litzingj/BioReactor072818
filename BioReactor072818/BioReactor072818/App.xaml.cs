using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using BioReactor072818.Models;


[assembly: XamlCompilation (XamlCompilationOptions.Compile)]



namespace BioReactor072818
{
	public partial class App : Application
	{

        public const int CHEMICAL_t = 0;
        public const int ADDITIVE_t = 1;

        public static string EXTERN_PUBLIC_PATH;

        public App ()
		{
			InitializeComponent();
            EXTERN_PUBLIC_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            Debug.Print(EXTERN_PUBLIC_PATH);
            //Navigation page allows you to use Navigation.PushAsync() and .PopAsync() to navigate
            //MainPage = new NavigationPage(new MainPage());
            MainPage = new NavigationPage(new MainPage());
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
