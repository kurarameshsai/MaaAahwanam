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
       public VendorsWeddingCollection AddWeddingCollection(VendorsWeddingCollection vendorsWeddingCollection, Vendormaster vendorMaster)
       {
           VendormasterRepository vendorMasterRepository = new VendormasterRepository();
           VendorWeddingCollectionsRepository vendorsWeddingCollectionsRepository = new VendorWeddingCollectionsRepository();
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
    }
}
