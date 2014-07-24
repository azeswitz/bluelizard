using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueLizard.Business.Interfaces;
using BlueLizard.Business.Dto;
using BlueLizard.Domain;
using BlueLizard.Data.Interfaces;
using AutoMapper;
using AutoMapper.Mappers;
using log4net;
using System.Reflection;

namespace BlueLizard.Business.Managers
{
    public class PersonManager : IPersonManager
    {
        
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        IGenericDataRepository<Person> _repo;

        //Initialize manager, inject repository instance and configure automapper
        public PersonManager(IGenericDataRepository<Person> repo)
        {
            this._repo = repo;
            AutoMapperConfig.Init();
        }

        //Return a list of objects.  Intentional return of IList vs. IQueryable to 
        //more cleanly keep application layers clean.  
        //Developer may apply Linq Expressions as parameters to "GetAll" method to return child objects
        //or filter results to a subset of the list
        public IList<PersonDto> GetList()
        {
            IList<Person> _list;
            _list = _repo.GetAll().ToList<Person>();
            return Mapper.Map<IList<Person>, IList<PersonDto>>(_list);
        }

        //Could be split into two methods.  Based on the database paradigm, an ID will
        //only exist after the object has been atomically saved once and persisted
        public PersonDto SaveOrUpdate(PersonDto x)
        {
            Person p = Mapper.Map<Person>(x);
            try
            {
                if (p.PersonId > 0)
                {
                    _repo.Update(p);
                }
                else
                {
                    _repo.Add(p);
                }

            }
            catch (Exception e)
            {
                log.Error(e);
            }
            return Mapper.Map<PersonDto>(p);
        }

        public PersonDto GetById(int id)
        {
            Person p = _repo.GetSingle(x => x.PersonId == id);
            return Mapper.Map<PersonDto>(p);
        }

        //Intentionally not implemented
        public bool DeletePerson(PersonDto x)
        {
            throw new NotImplementedException();
        }
    }
}
