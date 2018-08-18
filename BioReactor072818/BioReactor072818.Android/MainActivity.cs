using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using Android.Support.V4.App;
using System.Diagnostics;

namespace BioReactor072818.Droid
{
    [Activity(Label = "BioReactor072818", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        public const int EXTERNAL_STORAGE = 1;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.WriteExternalStorage }, EXTERNAL_STORAGE);
            //Checking if able to write to public storage, if unable to, ask for permission
            if (!Android.OS.Environment.MediaMounted.Equals(Android.OS.Environment.ExternalStorageState))
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.WriteExternalStorage }, EXTERNAL_STORAGE);
            }
            LoadApplication(new App());
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

