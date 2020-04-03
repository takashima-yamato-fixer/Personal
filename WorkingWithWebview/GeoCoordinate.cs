using System;
using System.Collections.Generic;
using System.Text;

namespace AppName.ViewModels
{
    /// <summary>
    /// 位置情報格納クラス
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough()]
    public class GeoCoordinate
    {
        /// <summary>
        /// 緯度
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// 経度
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public double Altitude { get; set; }

        /// <summary>
        /// 取得時間
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }
    }
}