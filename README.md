Mvc4ServiceStack
================

This is a project that I used to learn more about Service Stack. This project initially shows a list of stores. If the user clicks on a row in the grid the detail section will be displayed. The detail section will allow the user to save or delete the store. All saves or deletes are made to a singleton repository and they will only persist while the user is on the page. This project uses MVC for the view and Service Stack for the AJAX calls. The view contains the main and detail html.

Since we are using Service Stack with MVC in order to avoid conflicts with MVC a custom route for Service Stack needs to created. This can be done by adding a location to the web.config. The following is the location this project uses:

<location path="servicestack">
    <system.web>
      <httpHandlers>
        <add path="*" type="ServiceStack.WebHost.Endpoints.ServiceStackHttpHandlerFactory, ServiceStack" verb="*"/>
      </httpHandlers>
    </system.web>

    <!-- Required for IIS 7.0 -->
    <system.webServer>
      <modules runAllManagedModulesForAllRequests="true"/>
      <validation validateIntegratedModeConfiguration="false" />
      <handlers>
        <add path="*" name="ServiceStack.Factory" type="ServiceStack.WebHost.Endpoints.ServiceStackHttpHandlerFactory, ServiceStack" verb="*" preCondition="integratedMode" resourceType="Unspecified" allowPathInfo="true" />
      </handlers>
    </system.webServer>
</location>

This location allows the custom path of "servicestack" to be used in the URL for Service Stack API calls.

The next step is to tell Service Stack where to find your web service. In the global.asax.cs file the StoreAppHost class is used to create the Service Stack Web Application. The application is initialized in Application_Start by the following line:

(new StoreAppHost()).Init()

Routes are configured in the StoreAppHost Configure method. The following are the Routes for this application:

	Routes
        .Add<OrgLevelRequest>("/orglevel")
        .Add<RetailerRequest>("/retailer")
        .Add<StoreRequest>("/store")
        .Add<GetOnlyStore>("/storeall")
        .Add<SubOrgLevelRequest>("/suborglevel");
		
Service Stack is a message based web service which means that it uses messages to facilitate its communication. The route is bound to the message which is the Request Data Transfer Object. The Request can be filtered before it goes to the Service. Service Stack uses the Request DTO and the Request's HTTP Verb to determine which API method is called. The Service method will then return the Response DTO. An example of how this would work is a HTTP Get Request with a route of "servicestack/store" will bind to the following Request Data Transfer Object:

public class StoreRequest
{
    public int? RetailerId { get; set; }
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int? OrgLevelId { get; set; }
    public int? SubOrgLevelId { get; set; }
}

Once the StoreRequest has been bound then Service Stack will look through all of the services that inherit from IService that have StoreRequest as a parameter and is a HTTP Get method. In this application we only have one service called StoreService and there is only one Get method that has StoreRequest as the parameter which is the following:

public StoreResponse Get(StoreRequest store)
{
	return (from s in _repository.GetStores()
            where s.Id == store.Id
            select s).First();
}

The Get method will return the following Response Data Transfer Object:

public class StoreResponse
{
    public int? RetailerId { get; set; }
    public string RetailerName { get; set; }
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int? OrgLevelId { get; set; }
    public string OrgLevelName { get; set; }
    public int? SubOrgLevelId { get; set; }
    public string SubOrgLevelName { get; set; }
}

This completes the life cycle of a Service Stack Request. 

The Service Stack message based approach doesn't smoothly handle no parameter API's. In Service Stack the route is bound to a Request Data Transfer Object but an API without a parameter will not have a Request Data Trasnfer Object. In Service Stack you will need to create an empty Request Data Transfer Object for the prameterless API. In this application getting retailers are an example of a parameterless API. A route of "servicestack/retailer" will be bound to the following RetailerRequest:

public class RetailerRequest
{
}

Notice that the RetailerRequest is simply a class with nothing in it. After RetailerRequest is bound Servive Stack will then look for a Service that has a method with a parameter of RetailerRequest and is HTTP Get to determine which API method is called. In Service Stack a Request Data Transfer Object is always required.