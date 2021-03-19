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
    public class Hannes2Controller : Controller
    {
        // GET: Hannes2
        public async Task<ActionResult> Index()
        {
            var scopes = new string[] { "https://graph.microsoft.com/.default" };

            var cca = ConfidentialClientApplicationBuilder
                .Create(System.Configuration.ConfigurationManager.AppSettings["ClientId"])
                 .WithRedirectUri(System.Configuration.ConfigurationManager.AppSettings["redirectUri"])
                .WithClientSecret(System.Configuration.ConfigurationManager.AppSettings["ClientSecret"])
                .WithAuthority(System.Configuration.ConfigurationManager.AppSettings["Authority"])
                 .Build();
            var authenticationProvider = new AuthorizationCodeProvider(cca,scopes);
            GraphServiceClient graphClient = new GraphServiceClient(authenticationProvider);
var user2 = await graphClient.Me
               .Request()
               .GetAsync();
            return View();

            //https://github.com/microsoftgraph/msgraph-sdk-dotnet-auth
        }
    }
}