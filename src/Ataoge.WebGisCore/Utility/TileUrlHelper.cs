namespace Ataoge.Utility
{
    public static class TileUrlHelper
    {
        /// <summary>
        /// BuildTianDiTuTileUrl
        /// </summary>
        /// <param name="zoom"></param>
        /// <param name="tx"></param>
        /// <param name="ty"></param>
        /// <param name="layer">vec_w 矢量 cva_w  img_w cia_w  ter_w cta_w  vec_c cva_c img_c cia_c ter_c cta_c</param>
        /// <returns></returns>
        public static string BuildTianDiTuTileUrl(int zoom, int tx, int ty, string layer = "vec_w")
        {
            //http://t0.tianditu.com/vec_w/wmts?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER=vec&STYLE=default&TILEMATRIXSET=w&TILEMATRIX={x}&TILEROW={y}&TILECOL={x}&FORMAT=tiles
            //http://t0.tianditu.com/vec_w/wmts?SERVICE=WMTS&REQUEST=GetCapabilities&VERSION=1.0.0
            //Map: "http://t{s}.tianditu.cn/DataServer?T=vec_w&X={x}&Y={y}&L={z}",
            //Annotion: "http://t{s}.tianditu.cn/DataServer?T=cva_w&X={x}&Y={y}&L={z}",
            //Map: "http://t{s}.tianditu.cn/DataServer?T=img_w&X={x}&Y={y}&L={z}",
            //Annotion: "http://t{s}.tianditu.cn/DataServer?T=cia_w&X={x}&Y={y}&L={z}",
            //Map: "http://t{s}.tianditu.cn/DataServer?T=ter_w&X={x}&Y={y}&L={z}",
            //Annotion: "http://t{s}.tianditu.cn/DataServer?T=cta_w&X={x}&Y={y}&L={z}",
            int s = (zoom + tx + ty) % 8;//
           
            return string.Format("http://t{0}.tianditu.com/DataServer?T={1}&X={2}&Y={3}&L={4}", s, layer, tx, ty, zoom);
        }
    }
}