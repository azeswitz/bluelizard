using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueLizard.Business.Dto;
using BlueLizard.Business.Interfaces;
using BlueLizard.Business;
using StructureMap;
using log4net;
using System.Reflection;

namespace BlueLizard.Tests.Business
{
    [TestClass]
    public class PersonTests
    {
        [TestInitialize]
        public void Init()
        {
            IoC.Init();
        }

        [TestMethod]
        public void CanGetList()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void CanSaveOrUpdate()
        {
            IPersonManager _mgr = ObjectFactory.GetInstance<IPersonManager>();

            PersonDto x = new PersonDto
            {
                FirstName = "Justin",
                LastName = "Thyme",
                MiddleName = "Nick",
                StreetAddress1 = "Any St",
                StreetAddress2 = "Apt 1",
                City = "Sometown",
                State = "VA",
                Zip = "22031",
                Phone = "111-222-3333",
                Email = "justatest@icfi.com",
                CreateDate = DateTime.UtcNow,
                CreatedBy = "Test1",
                UpdateDate = DateTime.UtcNow,
                UpdateBy = "Test1"
            };
            x = _mgr.SaveOrUpdate(x);

            Assert.AreNotEqual(0, x.PersonId);
        }

        [TestMethod]
        public void CanGetById(int id)
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public void CanDeletePerson()
        {
            throw new NotImplementedException();
        }
    }
}
