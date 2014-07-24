using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using StructureMap;
using BlueLizard.Domain;

namespace BlueLizard.Tests.Business
{
    public class IoC
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        [TestMethod]
        public static void Init()
        {
            log4net.Config.XmlConfigurator.Configure();
            ObjectFactory.Configure(x =>
            {
                x.For<System.Data.Entity.DbContext>().Singleton().Use<BlueLizard.Data.Entities>();
                x.For<BlueLizard.Data.Interfaces.IGenericDataRepository<Demo>>().Use<BlueLizard.Data.Repositories.GenericDataRepository<Demo>>();
                x.For<BlueLizard.Data.Interfaces.IGenericDataRepository<Person>>().Use<BlueLizard.Data.Repositories.GenericDataRepository<Person>>();

                x.For<BlueLizard.Business.Interfaces.IPersonManager>().Use<BlueLizard.Business.Managers.PersonManager>();


            });
        }
    }
}
