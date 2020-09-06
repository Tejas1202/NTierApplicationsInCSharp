using JustShowMeMyFriends.WebApiServices;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Infrastructure.Data;
using PluralSightBook.Infrastructure.Services;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JustShowMeMyFriends
{
    public class StructureMapBootStrap
    {
        public static void Configure()
        {
            ObjectFactory.Configure(c =>
            {
                c.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                    x.AssemblyContainingType<IFriendsService>(); // Core
                });

                // Configure WebAPI
                c.For<HttpClient>().Singleton().Use(() => ApiConfig.GetClient());

                // Configure Implementations
                //c.For<ISendEmail>().Use<DebugEmailSender>();
                //c.For<IQueryUsersByEmail>().Use<EfQueryUserByEmail>();
                //c.For<IFriendRepository>().Use<EfFriendRepository>();

                // Now we don't need all of the above configure implementations as now we're talking to the api through the below implementations
                // Hence no need to add reference to infrastructure project in this case
                c.For<IUserService>().Use<WebApiUserService>();
                c.For<IFriendsService>().Use<WebApiFriendsService>();
            });
        }
    }
}
