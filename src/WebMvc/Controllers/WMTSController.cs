using Microsoft.AspNetCore.Mvc;

namespace Ataoge.GIS.Controllers
{
    public class WMTSController //: Controller
    {
        [HttpGet("/{serviceName}/wmts")]
        public IActionResult Index(string serviceName)
        {
            return new OkResult();
        }

        [HttpGet("/{serviceName}/wmts/tile/{version}/{layerName}/{style}/{tileMatrixSet}/{tileMatrix}/{tileRow}/{tileCol}")]
        public IActionResult Tile(string serviceName, string version, string layerName, string style,  string tileMatrixSet, int tileMatrix, int tileRow,  int tileCol)
        {
            return new OkResult();
        }
    }
}