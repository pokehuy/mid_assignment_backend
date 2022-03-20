using mid_assignment_backend.Models;
using mid_assignment_backend.Repositories;

namespace mid_assignment_backend.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<ResponseUser> Login(AuthenticationRequest model)
        {
            return await _authenticationRepository.Login(model);
        }

        // public async Task<ResponseUser> Logout()
        // {
        //     return await _authenticationRepository.Logout();
        // }
    }
}