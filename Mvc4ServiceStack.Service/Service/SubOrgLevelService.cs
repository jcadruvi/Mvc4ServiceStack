using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc4.ServiceStack.ServiceModel.Request;
using ServiceStack.ServiceHost;

namespace Mvc4ServiceStack.Service.Service
{
    public class SubOrgLevelService : IService
    {
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
    }
}
