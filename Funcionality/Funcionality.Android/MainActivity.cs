using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using Funcionality.Interface;
using Funcionality.Services;
using Plugin.DownloadManager;
using System.Linq;
using System.IO;

namespace Funcionality.Droid
{
    [Activity(Label = "Funcionality", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            Download();
            ZXing.Mobile.MobileBarcodeScanner.Initialize(Application);
            DependencyService.Register<IQrCodeScannerService, QrCodeScannerService>();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void Download()
        {
            CrossDownloadManager.Current.PathNameForDownloadedFile =
                new Func<Plugin.DownloadManager.Abstractions.IDownloadFile, string>(file =>
                {
                    string fileName = Android.Net.Uri.Parse(file.Url).Path.Split('/').Last();
                    return Path.Combine(ApplicationContext.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads).AbsolutePath, fileName);
                });
        }
    }
}