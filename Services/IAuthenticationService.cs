using mid_assignment_backend.Models;

namespace mid_assignment_backend.Services
{
    public interface IAuthenticationService
    {
        Task<ResponseUser> Login(AuthenticationRequest model);
        //Task<ResponseUser> Logout();
    }
}