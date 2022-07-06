using BusinessLogic.Interface;
using DataAccess.Models;
using DataAccess.Models.VM;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IKonnect_LiveCare.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        private IFacilities _facility;

        public FacilitiesController(IFacilities facilities)
        {
            _facility = facilities;
        }

        // GET: api/<FacilitiesController>
       
        [HttpGet]
        [Route("api/getFacilities")]
        public async  Task<FacilityVM> Get()
        {

            var data =await _facility.getTblFacilities();

            return data;
        }

       

  
    }
}
