using System;
using System.Linq;
using System.Reflection;
using BlueLizard.Data.Interfaces;
using BlueLizard.Domain;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace BlueLizard.Tests.Data
{
    [TestClass]
    public class DemoTests
    {
        [TestInitialize]
        public void Init()
        {
            IoC.Init();
        }

        [TestMethod]
        public void CanCreateDemoRecord()
        {
            IGenericDataRepository<Demo> _DemoRepo = ObjectFactory.GetInstance<IGenericDataRepository<Demo>>();
            Demo x = new Demo
            {
                //guid to satisfy unique constraint
        
                ColumnOne = Guid.NewGuid().ToString()
            };
            _DemoRepo.Add(x);
            Assert.AreNotEqual(null, x.DemoId);
        }
    }
}
