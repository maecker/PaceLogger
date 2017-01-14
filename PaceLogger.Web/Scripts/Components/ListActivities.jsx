class ListActivities extends React.Component {

    constructor() {
        super();
        this.state = { data: [] };
    }

    componentWillMount() {
        var self = this;        
        $.getJSON('/api/activities/a/b', function (data) {
            self.setState({ data: data });
        });
    }

    

    render() {
        const rows = this.state.data.map((act, index) => {
            return (
                <tr key={index}>
                    <td>{act.Sport}</td>
                    <td><ValueFormatter type="datetime">{act.StartTime}</ValueFormatter></td>
                    <td><ValueFormatter type="integer">{act.DistanceMeters}</ValueFormatter></td>
                    <td>{act.Time}</td>
                    <td>{act.Pace}</td>                    
                    <td><ValueFormatter type="float">{act.AverageHeartRate}</ValueFormatter></td>                    
                    <td><ValueFormatter type="float">{act.AltitudeMeters}</ValueFormatter></td>  
                    <td><ValueFormatter type="float">{act.Calories}</ValueFormatter></td>
                </tr>
            );
        });

        return (
            <table className="table">
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
                <tbody>{rows}</tbody>
            </table>
        );
    }
}