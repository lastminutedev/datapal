using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using DataPal.Controllers;
using DataPal.Repositories.Public;

namespace DataPal.DependencyResolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(SimKimWebApiController))
            {
                var repository = new SimKimNewsPublicRepository();

                return new SimKimWebApiController(repository);
            }
            else if (serviceType == typeof(XTNAdsWebApiController))
            {
                var repository = new XTNAdsPublicRepository();

                return new XTNAdsWebApiController(repository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {}
    }
}