import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class AssetDetail extends Component {
    static displayName = AssetDetail.name;

    constructor(props) {
        super(props);
        this.state = { assetDetail: null, loading: true };
    }

    componentDidMount() {
        this.populateAssetData();
    }

    static renderAssetDetail(assetDetail, activePage) {
        if (!assetDetail.errors) {
            return (
                <div>
                    <h1 id="jumbotron-heading" >Details for {assetDetail.fileName}</h1>

                    <div className="card-deck mb-2 text-center">
                        <div className="card mb-6 box-shadow">
                            <div className="card-header">
                                <h2>Author details</h2>
                            </div>
                            <div className="card-body lead text-muted">
                                <div>Created By: {assetDetail.createdBy}</div>
                                <div>Email: {assetDetail.email}</div>
                                <div>Country: {assetDetail.country}</div>
                            </div>
                        </div>
                        <div className="card mb-6 box-shadow">
                            <div className="card-header">
                                <h2>Technical Info</h2>
                            </div>
                            <div className="card-body lead text-muted">
                                <div><strong>Mime Type:</strong> {assetDetail.mimeType}</div>
                                <div><strong>Id:</strong> {assetDetail.assetId}</div>
                                <div><strong>Created On:</strong> {new Date(assetDetail.createdOn).toLocaleDateString()}&nbsp;
                                    {new Date(assetDetail.createdOn).toLocaleTimeString()}
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="card mb-4 box-shadow">
                        <div className="card-header">
                            <h2>Description</h2>
                        </div>
                        <div className="card-body">
                            <div className="lead text-muted">{assetDetail.description}
                            </div>
                        </div>
                    </div>
                </div>
            );
        }
        else {
            return (
                <h1 id="jumbotron-heading">No details found</h1>
            )
        }
    }

    render() {
        let errorBlock = this.state.errorMessage
        ? <div className="error">{this.state.errorMessage}</div>
        : "";

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : AssetDetail.renderAssetDetail(this.state.assetDetail, this.state.activePage);

        return (
            <div>
                {errorBlock}
                {contents}
                <Link to={{
                    pathname: '/assets',
                    activePage: this.state.activePage
                }}>Back to results</Link>
            </div>
        );
    }

    async populateAssetData() {
        let id = this.props.location.id;
        let url = 'assetapi/' + id;
        await fetch(url)
            .then(response => response.json())
            .then((data) => {
                this.setState({ assetDetail: data, activePage: this.props.location.activePage, loading: false, errorMessage: null });
            })
            .catch(() => {
                this.setState({ assetDetail: null, loading: false, errorMessage: "Failed to get data for asset." });
            });
    }
}
