using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Mvc4.ServiceStack.ServiceModel.Request;
using Mvc4.ServiceStack.ServiceModel.Response;
using Mvc4.ServiceStack.Repository;
using ServiceStack.ServiceHost;

namespace Mvc4.ServiceStack.Service
{
    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class StoreService : IService
    {
        private IStoreRepository _repository;
        private IEnumerable<StoreResponse> _stores;
 
        public StoreService()
        {
            _repository = new StoreRepository();
            _stores = Stores();
        }

        // Gets a list of all stores. 
        public IEnumerable<StoreResponse> Get(GetOnlyStore store)
        {
            return Stores();
        }

        public IEnumerable<KeyValuePair<string, string>> Get(OrgLevelRequest request)
        {
            ICollection<KeyValuePair<string, string>> response = new Collection<KeyValuePair<string, string>>();

            response.Add(new KeyValuePair<string, string>("1", "Bay Area"));
            response.Add(new KeyValuePair<string, string>("2", "Los Angelos"));
            response.Add(new KeyValuePair<string, string>("3", "San Diego"));

            return response;
        }

        public IEnumerable<KeyValuePair<string, string>> Get(RetailerRequest request)
        {
            ICollection<KeyValuePair<string, string>> response = new Collection<KeyValuePair<string, string>>();
            response.Add(new KeyValuePair<string, string>("1", "Best Buy"));
            response.Add(new KeyValuePair<string, string>("2", "Frys"));
            response.Add(new KeyValuePair<string, string>("3", "Wal Mart"));
            response.Add(new KeyValuePair<string, string>("4", "Target"));
            response.Add(new KeyValuePair<string, string>("5", "Safeway"));
            response.Add(new KeyValuePair<string, string>("6", "Knob Hill"));
            response.Add(new KeyValuePair<string, string>("7", "Luckys"));
            return response;
        }

        public StoreResponse Get(StoreRequest store)
        {
            return (from s in Stores()
                    where s.Id == store.Id
                    select s).First();
        }

        public IEnumerable<KeyValuePair<string, string>> Get(SubOrgLevelRequest request)
        {
            ICollection<KeyValuePair<string, string>> response = new Collection<KeyValuePair<string, string>>();

            switch (request.OrgLevelId)
            {
                case 1:
                    response.Add(new KeyValuePair<string, string>("1", "San Fransisco"));
                    response.Add(new KeyValuePair<string, string>("2", "San Jose"));
                    response.Add(new KeyValuePair<string, string>("3", "Oakland"));
                    break;
                case 2:
                    response.Add(new KeyValuePair<string, string>("4", "Los Angelos"));
                    response.Add(new KeyValuePair<string, string>("5", "Glendale"));
                    response.Add(new KeyValuePair<string, string>("6", "Simi Valley"));
                    break;
                case 3:
                    response.Add(new KeyValuePair<string, string>("7", "San Diego"));
                    response.Add(new KeyValuePair<string, string>("8", "Oceanside"));
                    response.Add(new KeyValuePair<string, string>("9", "Escondido"));
                    break;
            }

            return response;
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