using System.Threading.Tasks;
using AppName.ViewModels;
namespace AppName.Services
{
    public delegate void OnLocationChangedDelegate(GeoCoordinate location);
    public delegate void OnLocationErrorDelegate(string error);

    //DependencyServiceから利用する
    public interface ILocationService
    {
        // GPS初期化処理
        void Initialize();

        //現在の位置情報取得（非同期）
        Task<GeoCoordinate> GetGeoCoordinateAsync(int timeout);

        //位置情報変更イベント
        event OnLocationChangedDelegate OnLocationChanged;
        event OnLocationErrorDelegate OnLocationError;
    }
}