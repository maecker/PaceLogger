class GoogleMap extends React.Component {

    constructor() {
        super();
        this.state = { data: null };
    }

    componentWillMount() {
        var self = this;
        $.getJSON('/api/activity/' + window['activityId'] + '/map', function (data) {
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

            var path = new google.maps.Polyline({
                path: this.state.data,
                geodesic: true,
                strokeColor: '#FF0000',
                strokeOpacity: 1.0,
                strokeWeight: 2
            });

            path.setMap(this.map);
        }
        return (<div ref="map" style={mapStyle}></div>);
    }
}