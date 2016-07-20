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
	var LeafletMap; //Leaflet Map 
	var EchartInstance; //Echart Instance

    //define LMapModel
	var LMapModel = echarts.extendComponentModel({
        type: 'lmap',
				
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
		_ec:null,
		_ecModel:null,
        _resizing:false,
		
		initialize:function(ec, root) {
            this._ec = ec;
			this._echartsContainer= root ? root: ec.getDom();
		},
		
		getMap: function() {
			return this._map;
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
                this._ec.resize();
            } else {
                this._ec.dispatchAction({
                    type: 'mapMoveEnd'
                });
            }
		},
		
		onRemove: function (map) {
			// remove layer's DOM elements and listeners
			map.getPanes().overlayPane.removeChild(this._root);
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
	
	var OverLayer;
	LMapCoordSys.create = function (ecModel, api) {
        var lmapCoordSys;

		ecModel.eachComponent('lmap', function (lmapModel) {
			if (lmapCoordSys) {
                throw new Error('Only one lmap component can exist');
            }

            var viewportRoot;
            if (!LeafletMap) {
                var root = api.getDom();
                viewportRoot = api.getZr().painter.getViewportRoot();
                if (typeof L === 'undefined') {
                    throw new Error('LMap api is not loaded');
                }
                var root = api.getDom();
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
                LeafletMap = lmapModel.__lmap = new L.map(lmapRoot, opts);
            }

            if (!OverLayer)
            {
                var overlayer = OverLayer = new L.EchartLayer(EchartInstance, viewportRoot);
                LeafletMap.addLayer(overlayer);
            }
            OverLayer.setModel(lmapModel);

			lmapCoordSys = new LMapCoordSys(LeafletMap, api);
            lmapCoordSys.setMapOffset(lmapModel.__mapOffset || [0, 0]);
            lmapModel.coordinateSystem = lmapCoordSys;
		});
		
		ecModel.eachComponent('geo', function (geoModel) {
			if (!lmapCoordSys) {
    		   lmapCoordSys = new LMapCoordSys(LeafletMap, api);
               lmapCoordSys.setMapOffset(geoModel.__mapOffset || [0, 0]);
            }
            
            if (!OverLayer)
            {
                var overlayer = OverLayer = new L.EchartLayer(EchartInstance);
                LeafletMap.addLayer(overlayer);
            }
            OverLayer.setModel(geoModel);
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
	
	return {
        //init leaflet map, return map
		initMap : function(id, options) {
			var map = LeafletMap = L.map(id, options);
			var div =  document.createElement('div');
			var size = map.getSize();
			div.style.position = "absolute";
			div.style.height = size.y + 'px';
			div.style.width = size.x + 'px';
			div.style.top = 0;
			div.style.left = 0;
			var ec = EchartInstance = echarts.init(div);
			return map;
		},
        //get echart instance
		getEcharts:function() {
			return EchartInstance;
		},
        //get leaflet Layer for echart
        getEchartLayer:function() {
            return OverLayer;
        },
        getLMap:function() {
            return LeafletMap;
        },
        initEcharts:function(dom) {
            var ec = EchartInstance = echarts.init(dom);
            return ec;
        }
	};

}));