using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataPal.Interfaces;
using DataPal.Models;

namespace DataPal.Repositories
{
    public class RepositoryFactory
    {
        private IRepository<SimKimNews> simKimNewsRep;
        private IRepository<XTNAd> xtnAdsRep;

        public IRepository<SimKimNews> GetSimKimRepository()
        {
            if (simKimNewsRep == null)
            {
                simKimNewsRep = new SimKimNewsRepository();
            }

            return simKimNewsRep;
        }

        public IRepository<XTNAd> GetXTNAdsRepository()
        {
            if (xtnAdsRep == null)
            {
                xtnAdsRep = new XTNAdsRepository();
            }

            return xtnAdsRep;
        }
    }
}