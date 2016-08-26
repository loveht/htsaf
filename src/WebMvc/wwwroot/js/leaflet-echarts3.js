//LeafletEcharts Created by HuangTao.
(function(root, factory) {
  if (typeof define === 'function' && define.amd) {
    // AMD. Register as an anonymous module.
    define(['leaflet'], factory);
  } else if (typeof module === 'object' && module.exports) {
    // Node. Does not work with strict CommonJS, but
    // only CommonJS-like environments that support module.exports,
    // like Node.
    module.exports = factory(require('leaflet'), require('echarts'));
  } else if (typeof root !== 'undefined' && root.L && root.echarts) {
    // Browser globals (root is window)
    LeafletEcharts = factory(L, echarts);
  }
}(this, function(L, echarts) {
    var maps = {};
    var MAP_ATTRIBUTE_KEY = '_lmap_';
    var mapidBase = new Date() - 0;

    //define LMapModel
	var LMapModel = echarts.extendComponentModel({
        type: 'lmap',

        getLMap : function() {
            return this.__lmap;
        },
        
				
		defaultOption: {
            mapOptions : {
                center: [37.550339,104.114129],
                zoom: 5
            }
		}
    });
	
    //define LMapView
	var LMapView = echarts.extendComponentView({
        type: 'lmap',

        render: function (lMapModel, ecModel, api) {
		}
	});
	
	//define EchartLayer
	L.EchartLayer = L.Class.extend({
		includes:[L.Mixin.Events],
		_echartsContainer:null,
		_map:null,
		_api:null,
		_ecModel:null,
        _resizing:false,
		
		initialize:function(api, root) {
            this._api = api;
			this._echartsContainer= root ? root: api.getDom();
		},
		
		getMap: function() {
			return this._map;
		},

        getOverLayer : function() {
            return this.__overlayer;
        },

        setModel:function(ecModel) {
            this._ecModel = ecModel;
        },
		
		onAdd: function (map) {
			this._map = map;
			var size = map.getSize();
			
			map.getPanes().overlayPane.appendChild(this._echartsContainer);
			
			map.on('moveend', this._moveend, this);
			map.on('resize', this._resize, this);
		},
		
		_resize:function() {
			var domPosition = this._map._getMapPanePos();
			this._mapOffset = [-parseInt(domPosition.x) || 0, -parseInt(domPosition.y) || 0];
			this._echartsContainer.style.left = this._mapOffset[0] + 'px';
			this._echartsContainer.style.top = this._mapOffset[1] + 'px';
			var size = this._map.getSize();
			this._echartsContainer.style.height = size.y + 'px';
			this._echartsContainer.style.width = size.x + 'px';
            //resize over will moveend;
			this._resizing=true;
		},
		

		_moveend : function() {
			var domPosition = this._map._getMapPanePos();
			this._mapOffset = [-parseInt(domPosition.x) || 0, -parseInt(domPosition.y) || 0];
			this._echartsContainer.style.left = this._mapOffset[0] + 'px';
			this._echartsContainer.style.top = this._mapOffset[1] + 'px';
			if (this._resizing == true)
            {
                this._resizing = false;
                var ec = echarts.getInstanceByDom(this._api.getDom());
                ec.resize();
            } else {
                this._api.dispatchAction({
                    type: 'mapMoveEnd'
                });
            }
		},
		
		onRemove: function (map) {
			// remove layer's DOM elements and listeners
			map.getPanes().overlayPane.removeChild(this._echartsContainer);
			map.off('viewreset', this._viewreset, this);
			map.off('resize', this._resize, this);
		}
		
	});
		

	function LMapCoordSys(lmap, api) {
        this._lmap = lmap;
        this.dimensions = ['lng', 'lat'];
        this._mapOffset = [0, 0];

        this._api = api;
    }
	
	LMapCoordSys.prototype.dimensions = ['lng', 'lat'];

    LMapCoordSys.prototype.setMapOffset = function (mapOffset) {
        this._mapOffset = mapOffset;
    };

    LMapCoordSys.prototype.getLMap = function () {
        return this._lmap;
    };

    LMapCoordSys.prototype.dataToPoint = function (data) {
        var point = new L.latLng(data[1], data[0]);
        // TODO pointToOverlayPixel is toooooooo slow, cache the transform
        var px = this._lmap.latLngToContainerPoint(point);
        var mapOffset = this._mapOffset;
        return [px.x - mapOffset[0], px.y - mapOffset[1]];
    };

    LMapCoordSys.prototype.pointToData = function (pt) {
        var mapOffset = this._mapOffset;
        var pt = this._lmap.containerPointToLatLng({
            x: pt[0] + mapOffset[0],
            y: pt[1] + mapOffset[1]
        });
        return [pt.lat, pt.lng];
    };

    LMapCoordSys.prototype.getViewRect = function () {
        var api = this._api;
        return new echarts.graphic.BoundingRect(0, 0, api.getWidth(), api.getHeight());
    };

    LMapCoordSys.prototype.getRoamTransform = function () {
        return echarts.matrix.create();
    };
	
	// For deciding which dimensions to use when creating list data
    LMapCoordSys.dimensions = LMapCoordSys.prototype.dimensions;
	
	LMapCoordSys.create = function (ecModel, api) {
        var lmapCoordSys;

		ecModel.eachComponent('lmap', function (lmapModel) {
			if (lmapCoordSys) {
                throw new Error('Only one lmap component can exist');
            }

            var root = api.getDom();
            var key = root.getAttribute(MAP_ATTRIBUTE_KEY);
            var viewportRoot;

            if (!key) {
                
                viewportRoot = api.getZr().painter.getViewportRoot();
                if (typeof L === 'undefined') {
                    throw new Error('LMap api is not loaded');
                }

                // Not support IE8
                var lmapRoot = root.querySelector('.ec-extension-lmap');
                if (lmapRoot) {
                    // Reset viewport left and top, which will be changed
                    // in moving handler in BMapView
                    viewportRoot.style.left = '0px';
                    viewportRoot.style.top = '0px';
                    root.removeChild(lmapRoot);
                }
                lmapRoot = document.createElement('div');
                lmapRoot.style.cssText = 'width:100%;height:100%';
                // Not support IE8
                lmapRoot.classList.add('ec-extension-lmap');
                root.appendChild(lmapRoot);
                var opts = lmapModel.get('mapOptions');
                if (typeof opts == "function")
                    opts = opts();
                var lmap = lmapModel.__lmap = new L.map(lmapRoot, opts);

                var mapid = 'map_' + mapidBase++;
                maps[mapid] = lmap;
                root.setAttribute && root.setAttribute(MAP_ATTRIBUTE_KEY, mapid);
            } else {
                lmapModel.__lmap = maps[key];
            }


            if (!lmapModel.__overlayer)
            {
                var overlayer = lmapModel.__overlayer = new L.EchartLayer(api, viewportRoot);
                lmapModel.__lmap.addLayer(overlayer);
                lmapModel.__overlayer.setModel(lmapModel);
            }

			lmapCoordSys = new LMapCoordSys(lmapModel.__lmap, api);
            lmapCoordSys.setMapOffset(lmapModel.__mapOffset || [0, 0]);
            lmapModel.coordinateSystem = lmapCoordSys;
		});
		
		ecModel.eachComponent('geo', function (geoModel) {
            var root = api.getDom();
            var key = root.getAttribute(MAP_ATTRIBUTE_KEY);
            if (!key)
                throw new Error('Must Init LeafletMap First!');
            
            var leafletMap = geoModel.__lmap = maps[key];
			if (!lmapCoordSys) {
    		   lmapCoordSys = new LMapCoordSys(leafletMap, api);
               lmapCoordSys.setMapOffset(geoModel.__mapOffset || [0, 0]);
            }
            
            if (!geoModel.__overlayer)
            {
                var overlayer = geoModel.__overlayer = new L.EchartLayer(api);
                leafletMap.addLayer(overlayer);
                overlayer.setModel(geoModel);
            }
		});
		
		ecModel.eachSeries(function (seriesModel) {
			var coordSys = seriesModel.get('coordinateSystem');
            //series Lines only support geo coordSys;
            if (coordSys === 'geo' || coordSys === 'lmap') {
                seriesModel.coordinateSystem = lmapCoordSys;
            }
        });
		
	};
	
    //register lmap coordinateSystem
	echarts.registerCoordinateSystem(
        'lmap', LMapCoordSys
    );
	
    //register map moveend Action to UpdateLayout
	echarts.registerAction({
        type: 'mapMoveEnd',
        event: 'mapMoveEnd',
        update: 'updateLayout'
    }, function (payload, ecModel) {
        ecModel.eachComponent('lmap', function (lmapModel) {
        });
    });
	
    function LEResult(ec, dom, map)
    {
        this._ec = ec;
        this._dom = dom;
        this._map = map;
    }

    LEResult.prototype.getMap = function() {
        if (this._map)
                return this._map;
        var mapid = this._dom.getAttribute(MAP_ATTRIBUTE_KEY);    
        return maps[mapid];
    } 

    LEResult.prototype.getEcharts = function() {
        return this._ec;
    }

    LEResult.prototype.getEchartLayer = function() {
        var ec = this.getEcharts();
        var mapModel = ec.getModel().getComponent('lmap');
        if (!mapModel)
            mapModel = ec.getModel().getComponent('geo');
        return mapModel.__overlayer;
    } 

    LEResult.prototype.setOption = function(option, notMerge, lazyUpdate) { 
        this._ec.setOption(option,notMerge, lazyUpdate);
    }

	return {
        initMap : function(id, options) {
			var map = L.map(id, options);
            var mapid = 'map_' + mapidBase++;
            maps[mapid] = map;
			var div =  document.createElement('div');
			var size = map.getSize();
			div.style.position = "absolute";
			div.style.height = size.y + 'px';
			div.style.width = size.x + 'px';
			div.style.top = 0;
			div.style.left = 0;
            div.style.zIndex = 999;
			var ec =  echarts.init(div);
            div.setAttribute && div.setAttribute(MAP_ATTRIBUTE_KEY, mapid);
			return new LEResult(ec, div, map);
		},
        initEcharts:function(dom) {
            var ec = echarts.init(dom);
            return new LEResult(ec, dom);
        },
        version: "1.0.0"
    };

}));