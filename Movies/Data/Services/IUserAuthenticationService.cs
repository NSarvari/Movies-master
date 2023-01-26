using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Data.Services
{
    public interface IUserAuthenticationService
    {
        Task<Status> Login(Login login);
        Task<Status> Registration(Registration registration);
        Task Logout();
    }
}
