using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Mc4.ServiceStack.ServiceModel.Request;
using Mc4.ServiceStack.ServiceModel.Response;
using ServiceStack.ServiceHost;

namespace Mvc4.ServiceStack.Service
{
    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class StoreService : IService
    {
        // Gets a list of all stores. 
        public IEnumerable<StoreResponse> Get(GetOnly store)
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