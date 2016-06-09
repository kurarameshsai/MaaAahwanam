using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;

namespace MaaAahwanam
{
    public class SiteFaqBal
    {
        Maa_AhwaanamBase _Repositories = new Maa_AhwaanamBase();
        public void Savefaq(SiteFaq sitefaq)
        {
            MaaAahwanam.Dal.MA_SiteFaq faq = new MA_SiteFaq();
            if (sitefaq.FaqId != 0) faq = _Repositories.sitefaq.Get().SingleOrDefault(i => i.FaqId == sitefaq.FaqId);
            faq.Category = "General";
            faq.Question = sitefaq.Question;
            faq.Answer = sitefaq.Answer;
            faq.CreatedBy = ValidUserUtility.ValidUser();
            faq.CreatedDate = DateTime.Now;
            if (sitefaq.FaqId == 0) _Repositories.sitefaq.Add(faq);
            _Repositories.SaveChanges();
        }

        public List<MA_SiteFaq> FaqsList()
        {
            var SiteFaq = new List<MA_SiteFaq>();
            SiteFaq = _Repositories.sitefaq.Get().ToList();
            return SiteFaq;
        }
        public List<MA_SiteFaq> SiteFaq(int id)
        {
            List<MA_SiteFaq> faqdetail = _Repositories.sitefaq.Get().Where(p => p.FaqId == id).ToList();
            return faqdetail;
        }

    }
}
