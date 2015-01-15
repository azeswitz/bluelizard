using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Mappers;
using BlueLizard.Business.Dto;
using BlueLizard.Business.Interfaces;
using BlueLizard.Domain;
using BlueLizard.Data.Interfaces;
using System.Reflection;


namespace BlueLizard.Site
{
    public static class AutoMapperConfig
    {
        public static void Init()
        {
            try
            {
                var useless = new ListSourceMapper();
                Mapper.Initialize(cfg =>
                    {
                        //Automapper config for Client section
                        cfg.CreateMap<Person, PersonDto>()
                            .ReverseMap();
                    });
            }
            catch (AutoMapperConfigurationException ace)
            {
                throw ace;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
