import React, { Component } from 'react';
import { AssetDetail } from './AssetDetail';
import { Link } from 'react-router-dom';
import Pagination from "react-js-pagination";

export class Assets extends Component {
    static displayName = Assets.name;

    constructor(props) {
        super(props);
        this.state = { assets: [], loading: true, activePage: 1, pageSize: 10, rowCount: 0, errorMessage: null };
    }

    componentDidMount() {
        this.populateAssetData();
    }

    handlePageChange(pageNumber) {
        this.state.activePage = pageNumber;
        this.populateAssetData();
    }

    static renderAssetsTable(assets, activePage) {
        return (
            <div>
                <table className='table table-striped' aria-labelledby="tableLabel">
                    <thead>
                        <tr>
                            <th>File Name</th>
                            <th>Created On</th>
                        </tr>
                    </thead>
                    <tbody>
                        {assets.map(asset =>
                            <tr key={asset.fileName}>
                                <td>
                                    <Link to={{
                                        pathname: '/AssetDetail',
                                        id: asset.assetId,
                                        activePage: activePage,
                                    }}>
                                        {asset.fileName}
                                    </Link>
                                </td>
                                <td>{new Date(asset.createdOn).toLocaleDateString()}&nbsp;
                                    {new Date(asset.createdOn).toLocaleTimeString()}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    render() {
        let errorBlock = this.state.errorMessage
            ? <div className="error">{this.state.errorMessage}</div>
            : "";

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Assets.renderAssetsTable(this.state.assets, this.state.activePage);

        return (
            <div>
                <h1 id="tableLabel" >Assets</h1>

                {errorBlock}

                {contents}
                <Pagination
                    itemClass="page-item"
                    linkClass="page-link"
                    activePage={this.state.activePage}
                    itemsCountPerPage={this.state.pageSize}
                    totalItemsCount={this.state.rowCount}
                    pageRangeDisplayed={10}
                    onChange={this.handlePageChange.bind(this)}
                />
            </div>
        );
    }

    async populateAssetData() {
        let activePage = this.props.location.activePage ? this.props.location.activePage : this.state.activePage;
        this.props.location.activePage = null;

        await fetch('assetapi?' + new URLSearchParams({
            page: activePage,
            pageSize: this.state.pageSize,
        })
        )
            .then(response => response.json())
            .then((data) => {
                this.setState({
                    assets: data.results,
                    activePage: data.activePage,
                    pageSize: data.pageSize,
                    rowCount: data.rowCount,
                    loading: false,
                    errorMessage: null
                });
            })
            .catch(() => {
                this.setState({ assets: [], loading: true, errorMessage: "Failed to get data from assets." });
            });
    }
}
