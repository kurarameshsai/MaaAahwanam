using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
   public class VendorWeddingCollectionService
    {
        VendormasterRepository vendorMasterRepository = new VendormasterRepository();
        VendorWeddingCollectionsRepository vendorsWeddingCollectionsRepository = new VendorWeddingCollectionsRepository();
        public VendorsWeddingCollection AddWeddingCollection(VendorsWeddingCollection vendorsWeddingCollection, Vendormaster vendorMaster)
       {
           vendorsWeddingCollection.Status = "Active";
           vendorsWeddingCollection.UpdatedDate = DateTime.Now;
           vendorMaster.Status = "Active";
           vendorMaster.UpdatedDate = DateTime.Now;
           vendorMaster.ServicType = "WeddingCollection";
           vendorMaster = vendorMasterRepository.AddVendorMaster(vendorMaster);
           vendorsWeddingCollection.VendorMasterId = vendorMaster.Id;
           vendorsWeddingCollection = vendorsWeddingCollectionsRepository.AddWeddingCollections(vendorsWeddingCollection);
           return vendorsWeddingCollection;
       }
        public VendorsWeddingCollection GetVendorWeddingCollection(long id)
        {
            return vendorsWeddingCollectionsRepository.GetVendorWeddingCollection(id);
        }

        public VendorsWeddingCollection UpdateWeddingCollection(VendorsWeddingCollection vendorsWeddingCollection, Vendormaster vendorMaster, long masterid)
        {
            vendorsWeddingCollection.Status = "Active";
            vendorsWeddingCollection.UpdatedDate = DateTime.Now;
            vendorMaster.Status = "Active";
            vendorMaster.UpdatedDate = DateTime.Now;
            vendorMaster.ServicType = "WeddingCollection";
            vendorMaster = vendorMasterRepository.UpdateVendorMaster(vendorMaster, masterid);
            vendorsWeddingCollection = vendorsWeddingCollectionsRepository.UpdateWeddingCollection(vendorsWeddingCollection, masterid);
            return vendorsWeddingCollection;
        }
    }
}
