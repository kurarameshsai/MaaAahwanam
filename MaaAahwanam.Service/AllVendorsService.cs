using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Repository.db;
using MaaAahwanam.Models;

namespace MaaAahwanam.Service
{
    public class AllVendorsService
    {
        public List<dynamic> VendorsPhotographyList()
        {
            VendorsPhotographyRepository vendorsPhotographyRepository=new VendorsPhotographyRepository();
            var l1 = vendorsPhotographyRepository.PhotographersList();
            return l1;
        }
        public List<dynamic> VendorsBeautyList()
        {
            VendorsBeautyServiceRepository vendorsBeautyServiceRepository = new VendorsBeautyServiceRepository();
            var l1 = vendorsBeautyServiceRepository.VendorsBeautyServiceList();
            return l1;
        }
        public List<dynamic> VendorsDecoratorList()
        {
            VendorsDecoratorRepository vendorsDecoratorRepository = new VendorsDecoratorRepository();
            var l1 = vendorsDecoratorRepository.VendorsDecoratorList();
            return l1;
        }
        public List<dynamic> VendorsTravelandAccomodationList()
        {
            VendorsTravelandAccomodationRepository vendorsTravelandAccomodationRepository = new VendorsTravelandAccomodationRepository();
            var l1 = vendorsTravelandAccomodationRepository.VendorsTravelandAccomodationList();
            return l1;
        }
        public List<dynamic> VendorsList()
        {
            VendormasterRepository vendormasterRepository = new VendormasterRepository();
            var l1 = vendormasterRepository.VendormasterList().Select(i => i.Address + "," + i.Landmark + "</br>" + i.City);
            return l1.ToList<dynamic>();
        }
    }
}
