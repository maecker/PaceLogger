ReactDOM.render(
    <ListActivities onActivityClick={onActivityClick } />, document.getElementById('list')
);

function onActivityClick(activity) {
    //console.log('ActivityId:' + activity.Id);
    window.location += '/' + activity.Id;
}



