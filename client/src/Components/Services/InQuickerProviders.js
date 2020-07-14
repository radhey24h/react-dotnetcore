import React, { Component } from 'react'

export class InQuickerProviders extends Component {
    constructor() {
        super()
        this.state = {
            inquickerstaging: [],
        };
    }

    componentDidMount() {
        // GET request using fetch with async/await
        const url = `https://api.inquickerstaging.com/v3/winter.inquickerstaging.com/providers?include=locations%2Cschedules.location&page%5Bnumber%5D=1&page%5Bsize%5D=10`;
        fetch(url)
            .then((response) => {
                return response.json();
            })
            .then(res => {
                this.setState({ inquickerstaging: res.data })
            });
    }

    handleClick(event) {
        console.log(event)
    }

    render() {
        return (<>
            <h2 className="heading"> Quicker Provider </h2>
            <div> {
                this.state.inquickerstaging.map(item =>
                    <div className="provider-grid" key={Math.random()}>
                        <div className="provider-img">
                            <img alt={item.attributes['card-image']} src={item.attributes['card-image']} />
                        </div>

                        <div className="provider-content">
                            <h4>{item.attributes.name} </h4>
                            <br />
                            <h4>{item.attributes['provider-type']} </h4>
                        </div>
                    </div>
                )
            }
            </div>

        </>)
    }
}
