using Xunit;
using Ataoge.Utility;

namespace Ataoge.SafSystem.Tests
{
    public class CoordiateTransformTests
    {
        [Fact]
        public void TestWGS84ToGCJ02()
        {
            double lat = 23.156;
            double lon = 113.2314;

            double gcjLat;
            double gcjLon;
            CoordinateTransform.WGS84ToGCJ02(lat, lon, out gcjLat, out gcjLon);
            
            double wgsLat;
            double wgsLon;
            CoordinateTransform.GCJ02ToWGS84Exact(gcjLat, gcjLon, out wgsLat, out wgsLon);
            
            System.Console.WriteLine(wgsLat);
            System.Console.WriteLine(wgsLon);
            Assert.Equal(lat, wgsLat, 3);
            Assert.Equal(lon, wgsLon, 4);

        }
    }
}