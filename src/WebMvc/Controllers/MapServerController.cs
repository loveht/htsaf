using Ataoge.Services;
using Ataoge.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ataoge.GIS.Controllers
{
    public class MapServerController
    {
        private readonly ILogger<MapServerController> _logger;
        private readonly IQueryContextService _queryContext;

        public MapServerController(IQueryContextService queryContext, ILogger<MapServerController> logger)
        {
            _queryContext = queryContext;
            _logger = logger;
        }

        [HttpGet("/{serviceName}/MapServer")]
        public IActionResult Index(string serviceName)
        {
            var f = _queryContext.GetString("f");
            _logger.LogInformation($"Value is: {f}");
            return new OkResult();
        }

        [HttpGet("/{serviceName}/MapServer/tile/{level}/{row}/{col}")]
        public IActionResult Tile(string serviceName, int level, int row,  int col)
        {
            //_logger.LogInformation($"Value is: {serviceName}");

            switch (serviceName)
            {
                case "vec_w":
                    string tileUrl = TileUrlHelper.BuildTianDiTuTileUrl(level, row, col, serviceName);
                    return new RedirectResult(tileUrl);
            }
            byte[] bytes = new byte[5];
            return new FileContentResult(bytes, "application/png");
        }


    }
}