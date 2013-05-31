using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Mvc4.ServiceStack.ServiceModel.Request;
using Mvc4.ServiceStack.ServiceModel.Response;
using ServiceStack.ServiceHost;

namespace Mvc4.ServiceStack.Service
{
    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class StoreService : IService
    {
        private IEnumerable<StoreResponse> _stores;
 
        public StoreService()
        {
            _stores = Stores();
        }

        // Gets a list of all stores. 
        public IEnumerable<StoreResponse> Get(GetOnlyStore store)
        {
            return Stores();
        }

        public StoreResponse Get(StoreRequest store)
        {
            return (from s in Stores()
                    where s.Id == store.Id
                    select s).First();
        }

        public object Post(StoreRequest store)
        {
            return null;
        }

        public void Delete(StoreRequest store)
        {
        }

        private IEnumerable<StoreResponse> Stores()
        {
            ICollection<StoreResponse> response = new Collection<StoreResponse>();
            response.Add(new StoreResponse
            {
                RetailerId = 1,
                RetailerName = "Best Buy",
                Id = 1,
                Name = "Store 1",
                Number = "1",
                City = "San Jose",
                State = "CA",
                OrgLevelId = 1,
                OrgLevelName = "1 - Bay Area",
                SubOrgLevelId = 2,
                SubOrgLevelName = "2 - San Jose"
            });
            response.Add(new StoreResponse
            {
                RetailerId = 1,
                RetailerName = "Best Buy",
                Id = 2,
                Name = "Store 2",
                Number = "2",
                City = "San Jose",
                State = "CA",
                OrgLevelId = 1,
                OrgLevelName = "1 - Bay Area",
                SubOrgLevelId = 2,
                SubOrgLevelName = "2 - San Jose"
            });
            response.Add(new StoreResponse
            {
                RetailerId = 1,
                RetailerName = "Best Buy",
                Id = 3,
                Name = "Store 3",
                Number = "3",
                City = "San Jose",
                State = "CA",
                OrgLevelId = 1,
                OrgLevelName = "1 - Bay Area",
                SubOrgLevelId = 2,
                SubOrgLevelName = "2 - San Jose"
            });
            return response;
        } 
    }
}