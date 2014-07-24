using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using BlueLizard.Data.Interfaces;
using BlueLizard.Domain;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace BlueLizard.Tests.Data
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
            IGenericDataRepository<Person> _repo = ObjectFactory.GetInstance<IGenericDataRepository<Person>>();
            Person[] list = _repo.GetAll().ToArray<Person>();
            Assert.AreNotEqual(0, list.Count<Person>());
        
        }

        [TestMethod]
        public void CanSaveOrUpdate()
        {
            IGenericDataRepository<Person> _repo = ObjectFactory.GetInstance<IGenericDataRepository<Person>>();

            Person x = new Person
            {
                 FirstName="Justin",
                 LastName="Thyme",
                 MiddleName="Nick",
                 StreetAddress1="Any St",
                 StreetAddress2="Apt 1",
                 City="Sometown",
                 State="VA",
                 Zip="22031",
                 Phone="111-222-3333",
                 Email="justatest@icfi.com",
                 CreateDate=DateTime.Now,
                 CreatedBy="Test1",
                 UpdateDate=DateTime.Now,
                 UpdateBy ="Test1"

            };

            _repo.Add(x);
            Assert.AreNotEqual(null, x.PersonId);
        }

        [TestMethod]
        public void CanGetById()
        {
            int id = 1;
            IGenericDataRepository<Person> _repo = ObjectFactory.GetInstance<IGenericDataRepository<Person>>();
            Person p = _repo.GetSingle(x=>x.PersonId == id);
            Assert.AreEqual(id, p.PersonId);

        }
        [TestMethod]
        public void CanDeletePerson()
        {
            throw new NotImplementedException();
        }
    }
}