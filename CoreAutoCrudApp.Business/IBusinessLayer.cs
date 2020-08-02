using System;
using System.Collections.Generic;
using System.Text;
using CoreAutoCrudApp.Data.Models;

namespace CoreAutoCrudApp.Business
{
    public interface IBusinessLayer
    {
        IList<Asset> GetAllAssets();
        Asset GetAssetById(Guid id);
        void CreateAsset(params Asset[] assets);
        void UpdateAsset(params Asset[] assets);
        void DeleteAsset(params Asset[] assets);
    }
}
