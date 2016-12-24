class ValueFormatter extends React.Component {
    render() {
        let v = this.props.children;
        switch (this.props.type) {
            case 'datetime':
                v = this.renderDateTime(v);
                break;
            case 'float':
                v = this.renderFloat(v);
                break;
        }
        return (<span>{v}</span>);
    }

    renderDateTime(s) {
        // yyyy-MM-ddTHH:mm:ss --> dd.MM.yyyy HH:mm:ss
        //return [s.substr(8, 2), '.', s.substr(5, 2), '.', s.substr(0, 4), ' ', s.substr(11, 8)].join('');
        var d = new Date(parseInt(s.substr(6)));
        return d.toLocaleDateString() + ' ' + d.toLocaleTimeString();
    }

    renderFloat(s) {
        return parseFloat(s).toFixed(2).toString();
    }
}





