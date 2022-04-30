using MediatR;
using quartz.application.Users.Interfaces;
using Quartz.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace quartz.application.Users.QueryInteractors.UserLogin
{
    public class UserLoginInteractor : IRequestHandler<UserLoginRequest, UserLoginDto>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserQueries _userQueries;

        public UserLoginInteractor(IAuthenticationService authenticationService, IUserQueries userQueries)
        {
            _authenticationService = authenticationService;
            _userQueries = userQueries;
        }

        public async Task<UserLoginDto> Handle(UserLoginRequest request, CancellationToken cancellationToken)
        {
            var user = _userQueries.GetUser(request.UserName, request.Password);

            if(user == null)
            {
                throw new InvalidQuartzOperationException($"User does not exist!");
            }

            _authenticationService.Authenticate(user);

            return await Task.FromResult(user);
        }
    }
}
