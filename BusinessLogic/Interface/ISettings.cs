using DataAccess.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface ISettings
    {
        Task<AuthTokenVM> getAuthTokenLC();

        Task<string> SendEmail(string host, int port, string username, string password, string from, string to, string subject, string html);

    }
}
