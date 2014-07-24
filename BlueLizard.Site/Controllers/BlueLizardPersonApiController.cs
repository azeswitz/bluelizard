using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Reflection;
using BlueLizard.Business;
using BlueLizard.Business.Dto;
using BlueLizard.Business.Interfaces;
using log4net;

namespace BlueLizard.Site.Controllers
{
    public class BlueLizardPersonApiController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        IPersonManager _mgr;

        public BlueLizardPersonApiController(IPersonManager mgr)
        {
            this._mgr = mgr;
        }

        [HttpGet]
        public PersonDto Get(int id=0)
        {
            PersonDto p;
            if (id > 0)
                p = this._mgr.GetById(id);
            else
                p = new PersonDto();

            return p;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]PersonDto p)
        {
            try
            {
                PersonDto x = this._mgr.SaveOrUpdate(p);
                return Request.CreateResponse(HttpStatusCode.Created, x);
            }
            catch(Exception ex)
            {
                log.Error(ex);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
           
        }
    }
}
