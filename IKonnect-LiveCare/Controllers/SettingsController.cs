using BusinessLogic.Interface;
using DataAccess.Models.VM;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IKonnect_LiveCare.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class SettingsController : ControllerBase
    {
        private readonly ISettings _repo;
      

        public SettingsController(ISettings repo)
        {
        
            _repo = repo;

        }
        // GET: api/<SettingsController>
        [HttpGet]
        [Route("api/GetAuthToken")]
        public async  Task<AuthTokenVM> Get()
        {
            AuthTokenVM data =await _repo.getAuthTokenLC();
            return data;
        }

       

       
    }
}
