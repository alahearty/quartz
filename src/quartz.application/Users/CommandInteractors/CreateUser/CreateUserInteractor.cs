using MediatR;
using quartz.application.Users.Interfaces;
using quartz.application.Users.QueryInteractors.UserLogin;
using Quartz.Application;
using Quartz.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace quartz.application.Users.CommandInteractors.CreateUser
{

    public class CreateUserInteractor : IRequestHandler<CreateUserRequest, UserLoginDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public CreateUserInteractor(IUserRepository userRepository, IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        public Task<UserLoginDto> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                UserName = request.UserName
            };

            try
            {
                _userRepository.Save(user);
                _userRepository.Transaction.Commit();
            }
            catch (Exception e)
            {
                throw new InvalidQuartzOperationException($"Oops, Something went wrong. Please try again. Inner Error Message: {e.Message}");
            }

            var userLoginDTO = UserLoginDto.From(user);

            _authenticationService.Authenticate(userLoginDTO);
            return Task.FromResult(userLoginDTO);
        }

         
    }
}
