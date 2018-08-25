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
        public const int NUM_VESSELS = 3;
        public static string EXTERN_PUBLIC_PATH;
        public Vessel[] vessels = new Vessel[NUM_VESSELS];
        public App ()
		{
            //Liscense for the graphs
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTY1MDhAMzEzNjJlMzIyZTMwQWZVa2gwcmErSzhUcEZvcjF5cGRYZ2hmQmhEY0FYaCtsb1V3bmRraHpTST0=");

            for(int i = 0; i < NUM_VESSELS; i++)
            {
                vessels[i] = new Vessel
                {
                    ID = (i + 1).ToString()
                };
            }

            //initialize all the stuff that the OS needs, we don't know all that happens
			InitializeComponent();

            //Get the path to save the recipes
            EXTERN_PUBLIC_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal);


            //Start timer that puts allows for Arduinos to communicate with the pi
            Device.StartTimer(TimeSpan.FromSeconds(5), () => 
            {

                foreach(Vessel v in vessels)
                {
                    UpdateVessel(v);
                }


                //Return true if you want to keep updating, return false if you want the timer to stop (should never return false)
                return true;
            });

            //Debug.Print(EXTERN_PUBLIC_PATH);
            
            //Navigation page allows you to use Navigation.PushAsync() and .PopAsync() to navigate
            MainPage = new NavigationPage(new MainPage(vessels));
            //MainPage = new NavigationPage(new DataPage(vessels[1]));

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

        /// <summary>
        /// This is where Grant should write the code for interfacing with the arduino
        /// </summary>
        /// <param name="vessel"></param>
        protected void UpdateVessel(Vessel vessel)
        {
            //Debug.Print("Updating Vessel");
        }
	}
}
