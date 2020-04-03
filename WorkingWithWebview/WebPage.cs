using System;
using AppName.Services;
using AppName.ViewModels;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WorkingWithWebview
{
    public class WebPage : ContentPage
    {
        void OnEnableGpsClick()
        {
            //GPSデバイスを初期化する
            DependencyService.Get<ILocationService>().Initialize();
            //10秒までを限度に現在の位置を取得する
            DependencyService.Get<ILocationService>().GetGeoCoordinateAsync(10000);

            //DependencyServiceの位置変更イベントと紐づける
            //DependencyService.Get<ILocationService>().OnLocationChanged += new OnLocationChangedDelegate(this.LocationChanged);
            //DependencyService.Get<ILocationService>().OnLocationError += new OnLocationErrorDelegate(this.LocationError);
        }
        /*
        //現在位置が変更されたら通知する
        private void LocationChanged(GeoCoordinate location)
        {
            DependencyService.Get<INotificationService>().SetNotifyCondition(DateTimeOffset.Now, 0, "");
            DependencyService.Get<INotificationService>().On("位置変更", "LocationUtility", "緯度：" + location.Latitude.ToString() + "　経度：" + location.Longitude + "　高度：" + location.Altitude);
        }

        //現在位置の取得エラーがあった場合、通知する
        private void LocationError(string error)
        {
            DependencyService.Get<INotificationService>().SetNotifyCondition(DateTimeOffset.Now, 0, "");
            DependencyService.Get<INotificationService>().On("LocationUtility", "位置取得エラー", error);
        }
        */
        public WebPage()
        {
            //GPSデバイスを初期化する
            DependencyService.Get<ILocationService>().Initialize();
            //10秒までを限度に現在の位置を取得する
            DependencyService.Get<ILocationService>().GetGeoCoordinateAsync(10000);

            var browser = new WebView();
            browser.Source = "https://kanji-check.cloud-config.jp/";
            Content = browser;
        }
    }
}

