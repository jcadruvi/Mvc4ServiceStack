using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc4ServiceStack.Service.Dto;
using ServiceStack.ServiceHost;

namespace Mvc4.ServiceStack.Service
{
    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class StoreService : IService
    {
        public object Get(StoreRequest request)
        {
            //Looks strange when the name is null so we replace with a generic name.
            var name = request.Name ?? "John Doe";
            return new StoreResponse { Result = "Hello, " + name };
        }
    }
}