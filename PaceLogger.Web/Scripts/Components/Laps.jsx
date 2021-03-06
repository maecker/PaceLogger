﻿class Laps extends React.Component {

    constructor() {
        super();
        this.state = { data: [] };
    }

    componentWillMount() {
        var self = this;        
        $.getJSON(`/api/activities/${this.props.activityId}/laps`, function (data) {
            self.setState({ data: data });
        });
    }

    render() {
        const rows = this.state.data.map((lap, index) => {
            return (
                <tr key={index}>
                    <td><ValueFormatter type="datetime">{lap.StartTime}</ValueFormatter></td>
                    <td><ValueFormatter type="integer">{lap.DistanceMeters}</ValueFormatter></td>
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
                    <tr>
                        <th>Start-Zeit</th>
                        <th>Distanz in m</th>
                        <th>Maximale Geschwindigkeit</th>
                        <th>verbrauchte Kalorien</th>
                        <th>Puls (Durchschnitt)</th>
                        <th>Puls (Maximum)</th>
                    </tr>
                </thead>
                <tbody>{rows}</tbody>
            </table>
        );
    }
}