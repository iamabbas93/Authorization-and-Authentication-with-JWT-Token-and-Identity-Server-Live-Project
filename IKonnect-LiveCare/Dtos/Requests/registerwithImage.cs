using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKonnect_LiveCare.Dtos.Requests
{
    public class registerwithImage
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public IFormFile Profile { get; set; }
        public string file { get; set; }
      


    }
}
