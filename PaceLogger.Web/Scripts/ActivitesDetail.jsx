
var onTrackpointHover = function (tp) {
    console.log(tp.index);
}

ReactDOM.render(
    <Laps activityId={window['activityId']} />, document.getElementById('content')
);

ReactDOM.render(
    <GoogleMap activityId={window['activityId']}
               onTrackpointHover={onTrackpointHover} />, document.getElementById('map')
);

ReactDOM.render(
    <Charts activityId={window['activityId']} />, document.getElementById('charts')
);



