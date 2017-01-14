class Charts extends React.Component {

    constructor() {
        super();
        this.state = this._getDataObject();
    }

    _getDataObject() {
        return {
            labels: null, 
            speed: null, 
            heartrate: null, 
            altitudeMeters: null
        }
    }

    componentWillMount() {
        var self = this;      

        $.getJSON(`/api/activities/${this.props.activityId}/chart`, function (data) {
            self.setState(self._convertData(data));
        });
    }

    render() {
        
        if (this.state.labels != null) {
            this._drawChart(this.state.speed, 'Geschwindigkeit');
            //drawChart(labels, heartrate, 'chartHeartrate' );
            //drawChart(labels, altitudeMeters, 'chartAltitude' );
        }

        return (<div className="chartContainer"><canvas ref="chartCanvas"></canvas></div>);        
    }

    _convertData(response) {
        var d = this._getDataObject();
        d.labels = [];
        d.speed = [];
        d.heartrate = [];
        d.altitudeMeters = [];

        response.forEach(function (item) {
            d.labels.push(item.ElapsedSeconds * 1000);
            d.speed.push(item.Speed);
            d.heartrate.push(item.Heartrate);
            d.altitudeMeters.push(item.AltitudeMeters);
        });

        return d;
    }

    _drawChart(data, label) {        
        var myChart = new Chart(this.refs.chartCanvas, {
            type: 'line',
            data: {
                labels: this.state.labels,
                datasets: [{
                    label: label,
                    data: data
                }]
            },
            options: {
                scales: {
                    xAxes: [{
                        type: 'time',
                        time: {
                            unit: 'minute',
                            unitStepSize: 5,
                            displayFormats: {
                                minute: 'hh:mm:ss'
                            }
                        },
                        ticks: {
                            callback: function (value) {
                                // eine Stunde abziehen (das Date-Objekt um 1AM startet, wenn das erste Date-Objekt mit 0 initialisiert wird)
                                var hour = parseInt(value.substring(0,2)) - 1;
                                return (hour < 10? '0' : '') + hour + value.substring(2);
                            },
                        },
                    }]
                },
                tooltips: {
                    callbacks: {
                        title: function (tti) {                                
                            return 'Zeit: ' + moment(tti[0].xLabel).subtract(1, 'hours').format('HH:mm:ss');                                
                        },
                        label: function (tti) {
                            var n = tti.yLabel;
                            return n % 1 === 0? n : (Math.round(n * 100) / 100).toFixed(2);
                        }
                    }
                },
                elements: {
                    point: {
                        radius: 0,
                        hitRadius: 5
                    }
                }
            }                
        });
    }   
}
