using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;
using System;
using System.Threading;

namespace PluralSightBook.IntegrationTests.Spikes.IOC
{
    [TestClass]
    class RepoContainerTests : BaseTransactionalTestClass
    {
        //[ClassInitialize]
        //public static void TestRunInitialize(TestContext context)
        //{
        //    ObjectFactory.Configure(c =>
        //    {
        //        c.Scan(x =>
        //        {
        //            x.TheCallingAssembly();
        //            x.WithDefaultConventions();
        //            x.AssemblyContainingType<EfFriendRepository>();
        //        });
        //        c.For<DbContext>().HybridHttpOrThreadLocalScoped()
        //            .Use<PluralSightBookContext>();
        //    });
        //}
    }

}
