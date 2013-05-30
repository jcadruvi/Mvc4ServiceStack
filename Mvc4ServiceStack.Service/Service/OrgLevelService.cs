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
    public class OrgLevelService : IService
    {
        public IEnumerable<KeyValuePair<string, string>> Get(OrgLevelRequest request)
        {
            ICollection<KeyValuePair<string, string>> response = new Collection<KeyValuePair<string, string>>();

            response.Add(new KeyValuePair<string, string>("1", "Bay Area"));
            response.Add(new KeyValuePair<string, string>("2", "Los Angelos"));
            response.Add(new KeyValuePair<string, string>("3", "San Diego"));

            return response;
        } 
    }
}
