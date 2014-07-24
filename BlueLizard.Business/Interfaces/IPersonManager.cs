using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueLizard.Business.Dto;

namespace BlueLizard.Business.Interfaces
{
    public interface IPersonManager
    {

        IList<PersonDto> GetList();
        PersonDto SaveOrUpdate(PersonDto x);
        PersonDto GetById(int id);
        bool DeletePerson(PersonDto x);
    }
}
