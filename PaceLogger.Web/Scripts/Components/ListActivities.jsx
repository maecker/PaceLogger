class ListActivities extends React.Component {

    constructor() {
        super();
        this.state = { data: [] };
        this.handleActivityClick = this.handleActivityClick.bind(this);
    }

    componentWillMount() {
        var self = this;        
        $.getJSON('/api/activities/a/b', function (data) {
            self.setState({ data: data });
        });
    }

    handleActivityClick(e) {
        e.preventDefault();
        var target = e.srcElement || e.target;
        while (target && target.nodeName !== "TR") {
            target = target.parentNode;
        }
        if (target) {
            var index = parseInt(target.getAttribute('data-index'));
            if ($.isFunction(this.props.onActivityClick)) {
                this.props.onActivityClick(this.state.data[index]);
            }
        }
    }

    render() {
        const rows = this.state.data.map((act, index) => {
            return (
                <tr key={index} data-index={index} >
                    <td>{act.Sport}</td>
                    <td><ValueFormatter type="datetime">{act.StartTime}</ValueFormatter></td>
                    <td><ValueFormatter type="integer">{act.DistanceMeters}</ValueFormatter></td>
                    <td>{act.Time}</td>
                    <td>{act.Pace}</td>                    
                    <td><ValueFormatter type="int">{act.AverageHeartRate}</ValueFormatter></td>                    
                    <td><ValueFormatter type="float">{act.AltitudeMeters}</ValueFormatter></td>  
                    <td><ValueFormatter type="int">{act.Calories}</ValueFormatter></td>
                </tr>
            );
        });

        return (
            <table className="table table-striped table-hover">
                <thead>                
                    <tr>
                        <th>Sportart</th>
                        <th>Start-Zeit</th>
                        <th>Distanz in m</th>
                        <th>Zeit</th>
                        <th>Pace</th>
                        <th>Puls (Durchschnitt)</th>
                        <th>Höhenmeter</th>
                        <th>Kalorien</th>
                    </tr>
                </thead>
                <tbody onClick={this.handleActivityClick}>{rows}</tbody>
            </table>
        );
    }
}