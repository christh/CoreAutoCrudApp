import React, { Component } from 'react';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import AssetThumb from './assetdb.png';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div className="container">
                <div className="row">

                    <h1 className="jumbotron col-12 shadow-lg p-3 mb-5 bg-white rounded">Welcome to the .NET Core Auto Crud App</h1>
                </div>
                <div className="row">
                    <h2>This is the React implementation, including:</h2>
                </div>
                <div className="row shadow p-3 mb-5 bg-white rounded">

                    <ul className="list-group col-lg-6 ">
                        <li className="list-group-item">Backend: <a href='https://get.asp.net/'>ASP.NET Core 3.1</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a></li>
                        <li className="list-group-item">Frontend: <a href='https://facebook.github.io/react/'>React</a></li>
                        <li className="list-group-item">Data access: <a href='https://dotnet.microsoft.com/apps/aspnet/apis'>ASP.NET Web API</a></li>
                    </ul>
                    <ul className="list-group col-lg-6">
                        <li className="list-group-item">ORM: <a href='https://docs.microsoft.com/en-us/ef/core/'>Entity Framework Core</a></li>
                        <li className="list-group-item">Database: <a href="https://docs.microsoft.com/en-us/ef/core/providers/sqlite/?tabs=dotnet-core-cli">SQLlite</a></li>
                        <li className="list-group-item">'Theme': <a href='http://getbootstrap.com/'>Bootstrap 4</a> for layout and styling</li>
                    </ul>
                </div>
                
                <div className="row">
                    <h2>Try the Demo</h2>
                </div>
                <div className="card-group  shadow p-3 mb-5 bg-white rounded ">
                    <div className="card">
                        <div className="card-body">
                            <h5 className="card-title">Asset Database Viewer</h5>
                            <p className="card-text">Click the link below to access the React Asset database viewer.</p>
                            <NavLink tag={Link} className="btn btn-primary" to="/assets">Assets</NavLink>
                        </div>
                    </div>
                    <div className="card">
                        <div className="card-body">
                            <h5 className="card-title">Screenshot</h5>
                            <div className="w-300">
                                <img src={AssetThumb} alt="Asset Thumbnail" />
                            </div>
                        </div>
                    </div>
                </div>


                <div className="row">
                    <h2>Implementation Details</h2>
                </div>

                    <div className="card-group shadow p-3 mb-5 bg-white rounded">
                        <div className="card">
                            <h5 className="card-header">Overview</h5>
                            <div className="card-body">
                                <h5 className="card-title">Assets</h5>
                                <p className="card-text">Assets are displayed in a paged overview, each asset
                                displaying two fields: title and created on.<br /><br />

                                    An <em>Assets</em> component pulls data 10 records at a time
                                    to the frontend via calls to the Web API. Pagination is implemented
                                    via a React package and a generic backend pagination implementation
                                that interacts with Entity Framework.<br /><br />A <em>created on</em> field in
                                    the CSV import schema is auto-computed by the Database.
                                    Queries are evaluated on the Database, this is important as there are 100,000 rows.
                        </p>

                            </div>
                            <div className="card-footer text-muted">
                                Todo: implement frontend caching via localstorage and some server side caching.
                        </div>
                        </div>
                        <div className="card">
                            <h5 className="card-header">Overview</h5>
                            <div className="card-body">
                                <h5 className="card-title">Asset Details</h5>
                                <p className="card-text">
                                    Clicking an asset navigates the user to a detail page showing all properties.<br /><br />
                                    This has been implemented with an <em>AssetDetails</em> component. The location in
                                     the pagination is retained when clicking back to the list.
                            </p>
                            </div>
                            <div className="card-footer text-muted">
                                Todo: implement better history support via the browser's back and forward commands.
                        </div>
                        </div>
                    </div>

                    <div className="card-group shadow p-3 mb-5 bg-white rounded">
                        <div className="card">
                            <h5 className="card-header">Data</h5>
                            <div className="card-body">
                                <h5 className="card-title">CSV Loading into Database</h5>
                                <p className="card-text">
                                    A large CSV file is used as the source data for seeding the Database.
                                    If no database exists, then Entity Framework will trigger the CSV import
                                    routine. CSV handling is implemented via the excellent
                                <a href='https://joshclose.github.io/CsvHelper/'> CSVHelper </a> package.
                                This is then loaded into a SQLite database.<br /><br />
                                    Code-first migrations have also been made use of.
                            </p>

                            </div>
                            <div className="card-footer text-muted">
                                Todo: include interstitial page during EF initial import.
                        </div>
                        </div>
                        <div className="card">
                            <h5 className="card-header">Data</h5>
                            <div className="card-body">
                                <h5 className="card-title">Data Access</h5>
                                <p className="card-text">
                                    A DAL project <em>CoreAutoCrudApp.Data</em> is used to access the
                                    via Entity Framework and the beginnings of a Business Layer is provided
                                in the <em>CoreAutoCrudApp.Business</em> project. <br /><br />
                                    The two functions in the React site (viewing list of assets and individual detail pages)
                                    are fully asynchronous.
                            </p>
                            </div>
                            <div className="card-footer text-muted">
                                Todo: Abstract the direct DAL calls using a Business Logic layer.
                        </div>
                        </div>
                    </div>

                    <div className="card-group shadow p-3 mb-5 bg-white rounded">
                        <div className="card">
                            <h5 className="card-header">Web API</h5>
                            <div className="card-body">
                                <h5 className="card-title">CRUD Methods</h5>
                                <p className="card-text">This sample provides an API controller
                                to perform CRUD operations on asset objects.<br /><br />

                                    A very basic scaffold of API CRUD tools has been implemented on the <em>AssetAPIController</em>.
                                These use async calls to get data.<br /><br />A fuller implementation including
                                    working MVC components for Create, Update and Delete is present in the
                                <em>CoreAutoCrudApp.Mvc</em> project.<br /><br />

                                    The React frontend is limited to read-only operations for now.
                            </p>
                            </div>
                            <div className="card-footer text-muted">
                                Todo: implement Create, Update and Delete on the React frontend.
                        </div>
                        </div>
                        <div className="card">
                            <h5 className="card-header">Web API</h5>
                            <div className="card-body">
                                <h5 className="card-title">API Access</h5>
                                <p className="card-text">
                                    Access is performed using promises, with error handling.
                            </p>
                            </div>
                            <div className="card-footer text-muted">
                                Todo: as the project grows, move code into utility classes.
                        </div>
                        </div>
                    </div>
                    <div className="card-group shadow p-3 mb-5 bg-white rounded">
                        <div className="card">
                            <h5 className="card-header">Logging</h5>
                            <div className="card-body">
                                <h5 className="card-title">Windows Event Log</h5>
                                <p className="card-text">Event log logging implemented via Microsoft's Logging Framework
                                using dependency injection.<br /><br />

                                Requires creation of log container beforehand via PowerShell commands.
                            </p>
                            </div>
                        </div>
                        <div className="card">
                            <h5 className="card-header">Logging</h5>
                            <div className="card-body">
                                <h5 className="card-title">Console Logging</h5>
                                <p className="card-text">Console logging implemented via Microsoft's Logging Framework
                                using dependency injection.<br /><br />

                                Requires launching of dotnet console to view these logs.
                            </p>
                            </div>
                        </div>
                    </div>
                </div>
        );
    }
}
