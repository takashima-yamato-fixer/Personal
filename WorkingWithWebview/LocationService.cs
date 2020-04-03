using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppName.Droid.Services;
using AppName.Services;
using AppName.ViewModels;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
[assembly: Dependency(typeof(LocationService))]

namespace AppName.Droid.Services
{
    public class LocationService : ILocationService
    {
        private IGeolocator _locator = null;

        /// <summary>
        /// GPSを初期化する
        /// </summary>
        public void Initialize()
        {
            _locator = CrossGeolocator.Current;
            _locator.DesiredAccuracy = 30;   //30mの精度に指定
        }

        /// <summary>
        /// 非同期で現在座標を取得する
        /// </summary>
        /// <param name="timeout">タイムアウト時間</param>
        /// <returns>現在の座標</returns>
        public async Task<GeoCoordinate> GetGeoCoordinateAsync(int timeout)
        {
            //指定した秒数までを限度に現在の位置を取得する
            Position position = await _locator.GetPositionAsync(timeout: new TimeSpan(timeout));

            return this.ConvertGeoCoordinate(position);
        }

        /// <summary>
        /// Plugin.Geolocator.Abstractions.Position を GeoCoordinate に変換し値を返す
        /// </summary>
        /// <param name="position">Plugin.Geolocator.Abstractions.Position</param>
        /// <returns>GeoCoordinate</returns>
        private GeoCoordinate ConvertGeoCoordinate(Position position)
        {
            var result = new GeoCoordinate
            {
                Latitude = position.Latitude,   //緯度
                Longitude = position.Longitude, //経度
                Altitude = position.Altitude,   //高度
                Timestamp = position.Timestamp  //取得時間
            };

            return result;
        }

        /// <summary>
        /// 非同期で位置情報の変更をリスニングする
        /// </summary>
        /// <param name="minTime"></param>
        /// <param name="minDistance"></param>
        /// <param name="includeHeading"></param>
        /*public void StartListening(int minTime, double minDistance, bool includeHeading = false)
        {
            if (_locator != null &&
                _locator.IsGeolocationEnabled &&
                _locator.IsGeolocationAvailable)
            {
                _locator.AllowsBackgroundUpdates = true;
                _locator.StartListeningAsync(minTime, minDistance, includeHeading);

                //位置変更時イベント
                _locator.PositionChanged += (sender, e) =>
                {
                    if (this.OnLocationChanged != null)
                    {
                        this.OnLocationChanged(this.ConvertGeoCoordinate(e.Position));
                    }
                };

                //位置取得エラー時イベント
                _locator.PositionError += (sender, e) =>
                {
                    if (this.OnLocationError != null)
                    {
                        this.OnLocationError(e.Error.ToString());
                    }
                };
            }
        }*/

        //位置情報変更イベント
        public event OnLocationChangedDelegate OnLocationChanged;
        public event OnLocationErrorDelegate OnLocationError;
    }
}