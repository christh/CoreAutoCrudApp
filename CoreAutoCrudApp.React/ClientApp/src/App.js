import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Assets } from './components/Assets';
import { AssetDetail } from './components/AssetDetail';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/assets' component={Assets} />
        <Route path='/assetdetail' component={AssetDetail} />
      </Layout>
    );
  }
}
