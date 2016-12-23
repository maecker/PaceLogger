var Laps = React.createClass({

    getInitialState: function () {
        return { data: [] };
    },

    componentWillMount: function () {        
        var self = this;
        $.getJSON(this.props.rest, function (data) {
            self.setState({ data: data });
        });        
    },

    render: function () {
        console.log(this.state.data);
        var rows = this.state.data.map(function (lap, index) {
            var d = new Date(parseInt(lap.StartTime.substr(6)));
            lap.StartTime = d.toLocaleDateString() + ' ' + d.toLocaleTimeString();
            return (
                <tr key={index}>
                    <td>{lap.StartTime}</td>
                    <td>{lap.DistanceMeters}</td>
                    <td>{lap.MaximumSpeed}</td>
                    <td>{lap.Calories}</td>
                    <td>{lap.AverageHeartRate}</td>
                    <td>{lap.MaximumHeartRate}</td>
                </tr>     
            );
        });

        return (
            <table className="table"><tbody>{rows}</tbody></table>
        );
    }
});