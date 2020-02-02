using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        void Register(RegisterModel model);
    }
}
