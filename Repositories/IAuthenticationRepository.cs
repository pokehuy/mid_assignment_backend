using mid_assignment_backend.Models;

namespace mid_assignment_backend.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<ResponseUser> Login(AuthenticationRequest model);
    }
}