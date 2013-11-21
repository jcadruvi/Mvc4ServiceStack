Mvc4ServiceStack
================

This is a project that I used to learn more about Service Stack. This project initially shows a list of stores. If the user clicks on a row in the grid the detail section will be displayed. The detail section will allow the user to save or delete the store. All saves or deletes are made to a singleton repository and they will only persist while the user is on the page. This project uses MVC for the view and Web API for the AJAX calls. The view contains the main and detail html.

Since we are using Service Stack with MVC in order to avoid conflicts with MVC a custom route for Service Stack needs to create. This can be done by adding a location to the web.config. The following is the location this project uses:

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

(new StoreAppHost()).Init();

