class ValueFormatter extends React.Component {

    constructor() {
        super();
        this.numberFormat = new Intl.NumberFormat("de-DE");        
    }

    render() {
        let v = this.props.children;
        switch (this.props.type) {
            case 'datetime':
                v = moment(v).format('DD.MM.YYYY HH:mm:ss');
                break;
            case 'float':
                v = this.numberFormat.format(parseFloat(v));
                break;
            case 'integer':
                v = this.numberFormat.format(parseInt(v));
                break;
        }
        return (<span>{v}</span>);
    } 
}





