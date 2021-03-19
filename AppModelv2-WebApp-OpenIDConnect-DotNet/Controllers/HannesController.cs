using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppModelv2_WebApp_OpenIDConnect_DotNet.Controllers
{
    public class HannesController : Controller
    {
        // GET: Hannes
        // GET: Hannes
        public async Task<ActionResult> Index()
        {
                  var scopes = new string[] { "https://graph.microsoft.com/.default" };

            var cca = ConfidentialClientApplicationBuilder
                .Create(System.Configuration.ConfigurationManager.AppSettings["ClientId"])
                .WithClientSecret(System.Configuration.ConfigurationManager.AppSettings["ClientSecret"])
               .WithTenantId(System.Configuration.ConfigurationManager.AppSettings["Tenant"])
               .Build();

        
                   var authenticationProvider = new AuthorizationCodeProvider(cca,scopes);
     
    
            GraphServiceClient graphClient2 = new GraphServiceClient(null);
            graphClient2.AuthenticationProvider = new DelegateAuthenticationProvider(async (request) =>
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Request.Cookies.Get("b").Value);
                await Task.FromResult<object>(null);
            });




            var user2 = await graphClient2.Me
               .Request()
               .GetAsync();
            
            return View();

            //https://github.com/microsoftgraph/msgraph-sdk-dotnet-auth
        }
    }
}