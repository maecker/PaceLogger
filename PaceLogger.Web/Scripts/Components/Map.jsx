class GoogleMap extends React.Component {

    constructor() {
        super();
        this.state = { data: null };
    }

    componentWillMount() {
        var self = this;      

        $.getJSON(`/api/activity/${this.props.activityId}/map`, function (data) {
            self.setState({ data: data });
        });
    }

    componentDidMount() {        
        this.map = new google.maps.Map(this.refs.map, {            
            zoom: 16
        });            
    }

    render() {
        const mapStyle = {
            width: 500,
            height: 500
        }        

        if (this.state.data != null) {
            this.map.setCenter(this.state.data[0]);
            this._setPath();
            this._setMarker();
        }

        return (<div ref="map" style={mapStyle}></div>);
    }

    _setPath() {
        var path = new google.maps.Polyline({
            path: this.state.data,
            geodesic: true,
            strokeColor: '#FF0000',
            strokeOpacity: 1.0,
            strokeWeight: 2
        });

        path.setMap(this.map);
    }

    _setMarker() {
        var self = this;

        for (var i = 0; i < this.state.data.length; i += 2) {
            var m = new google.maps.Marker({
                position: this.state.data[i],
                icon: {
                    path: google.maps.SymbolPath.CIRCLE,
                    scale: 5
                },
                index: i,
                opacity: 0.0,
                map: this.map
            });

            m.addListener('mouseover', function (e) {
                this.setOpacity(1.0);
                self.props.onTrackpointHover({ 'index': this.index, 'position': this.position });
            });
            m.addListener('mouseout', function (e) {
                this.setOpacity(0.0);
            });
        }
    }
}