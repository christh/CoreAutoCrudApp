using System;
using System.Collections.Generic;
using CoreAutoCrudApp.Data.Models;
using CoreAutoCrudApp.Data.Repositories;

namespace CoreAutoCrudApp.Business
{

    public class BusinessLayer : IBusinessLayer
    {
        private readonly AssetRepository _assetRepository;

        public BusinessLayer()
        {
            _assetRepository = new AssetRepository();
        }

        public BusinessLayer(AssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public IList<Asset> GetAllAssets()
        {
            return _assetRepository.GetAll();
        }

        public Asset GetAssetById(Guid id)
        {
            /* Validation and error handling omitted */
            return _assetRepository.GetSingle(
                a => a.AssetId.Equals(id));
        }

        public void CreateAsset(params Asset[] Assets)
        {
            /* Validation and error handling omitted */
            _assetRepository.Add(Assets);
        }

        public void UpdateAsset(params Asset[] Assets)
        {
            /* Validation and error handling omitted */
            _assetRepository.Update(Assets);
        }

        public void DeleteAsset(params Asset[] Assets)
        {
            /* Validation and error handling omitted */
            _assetRepository.Delete(Assets);
        }
    }
}
