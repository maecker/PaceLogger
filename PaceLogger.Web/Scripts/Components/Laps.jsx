class Laps extends React.Component {

    constructor() {
        super();
        this.state = { data: [] };
    }

    componentWillMount() {
        var self = this;
        $.getJSON(this.props.rest, function (data) {
            self.setState({ data: data });
        });
    }

    render() {
        const rows = this.state.data.map((lap, index) => {
            return (
                <tr key={index }>
                    <td><ValueFormatter type="datetime">{lap.StartTime}</ValueFormatter></td>
                    <td><ValueFormatter type="float">{lap.DistanceMeters}</ValueFormatter></td>
                    <td><ValueFormatter type="float">{lap.MaximumSpeed}</ValueFormatter></td>
                    <td><ValueFormatter type="float">{lap.Calories}</ValueFormatter></td>
                    <td><ValueFormatter type="float">{lap.AverageHeartRate}</ValueFormatter></td>
                    <td><ValueFormatter type="float">{lap.MaximumHeartRate}</ValueFormatter></td>
                </tr>
            );
        });

        return (
            <table className="table">
                <thead>
                    <th>Start-Zeit</th>
                    <th>Distanz in m</th>
                    <th>Maximale Geschwindigkeit</th>
                    <th>verbraucte Kalorien</th>
                    <th>Puls (Durchschnitt)</th>
                    <th>Puls (Maximum)</th>
                </thead>
                <tbody>{rows}</tbody>
            </table>
        );
    }
}