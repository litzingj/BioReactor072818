using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using Android.Support.V4.App;
//using Android.Things.Pio;
using System.Diagnostics;
using Java.Util.Concurrent;
using Java.Lang;

namespace BioReactor072818.Droid
{
    [Activity(Label = "BioReactor072818", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        public const int EXTERNAL_STORAGE = 1;
        //private IUartDevice Arduino;
        //private PeripheralManager PM;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            //For the popup window to get text for the chemical and additives
            Rg.Plugins.Popup.Popup.Init(this, bundle);


            global::Xamarin.Forms.Forms.Init(this, bundle);

            //Request permissions
            ActivityCompat.RequestPermissions(this, new System.String[] { Manifest.Permission.WriteExternalStorage }, EXTERNAL_STORAGE);
            //Checking if able to write to public storage, if unable to, ask for permission
            if (!Android.OS.Environment.MediaMounted.Equals(Android.OS.Environment.ExternalStorageState))
            {
                ActivityCompat.RequestPermissions(this, new System.String[] { Manifest.Permission.WriteExternalStorage }, EXTERNAL_STORAGE);
            }


            //var PM = PeripheralManager.Instance;
            //var gpios = PM.GpioList;
            //foreach (var gpio in gpios)
            //{
            //    System.Diagnostics.Debug.Print(gpio);
            //}
            //
            LoadApplication(new App());
        }



        /// <summary>
        /// 
        /// 
        /// LEFT OFF HERE, TRYING TO RUN SOME CODE TO TALK TO ARDUINO
        /// 
        /// https://medium.com/@bastermark3/connecting-raspberry-pi-3-with-android-things-to-arduino-51d202006379
        /// 
        /// 
        /// 
        /// </summary>
        public void TxRxArduino()
        {
            /*Arduino = PM.OpenUartDevice("UART0");
            Arduino.SetBaudrate(9600);

            Executors.NewSingleThreadScheduledExecutor().ScheduleAtFixedRate(new Runnable()
            {
                public void run()
                {
                    //write data
                }
            },0,1,TimeUnit.SECONDS);*/
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if(requestCode == EXTERNAL_STORAGE)
            {
                System.Diagnostics.Debug.Print("External Storage Request Granted");
            }
            else
            {
                System.Diagnostics.Debug.Print("External Storage Request Denied");
            }
        }
    }
}

