using BusinessLogic.Interface;
using DataAccess.Models;
using DataAccess.Models.VM;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    class FacilitiesRepo : IFacilities
    {
        private  RestClient _client;
        private readonly ISettings _settings;
        private readonly IConfiguration _configuration;

        public FacilitiesRepo(ISettings settings,IConfiguration configuration)
        {
            
            _settings = settings;
            _configuration = configuration;
          
        }
       public async Task<FacilityVM> getTblFacilities()
        {
            FacilityVM facilities = new FacilityVM();
            AuthTokenVM authToken =await _settings.getAuthTokenLC();
            
            var baseURL = _configuration["LiveCareBaseURL"];
            var clientKey = _configuration["LiveCareClientKey"];
            var accessCode = _configuration["LiveCareAccessCode"];


            _client = new RestClient(baseURL);

            var request = new RestRequest("api/" + clientKey + "/facilities", Method.Get);
            request.AddHeader("Authorization", $"Bearer {authToken.data}");

            RestResponse response = await _client.ExecuteAsync(request);

            facilities = JsonConvert.DeserializeObject<FacilityVM>(response.Content);

            return facilities;

            
        }
    }
}
