using DataAccess.Models;
using DataAccess.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
   public interface IFacilities
    {
        Task<FacilityVM> getTblFacilities();
    }
}
