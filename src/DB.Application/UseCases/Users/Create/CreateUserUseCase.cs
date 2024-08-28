using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Application.Communications.Requests.Users;
using DB.Application.Communications.Resposes.Tokens;
using DB.Application.Communications.Resposes.Users;
using DB.Domain.Cryptography;
using DB.Domain.Entities;
using DB.Domain.Repositories;
using DB.Domain.Token;
using DB.Exceptions;

namespace DB.Application.UseCases.Users.Create
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccessTokenGenerator _accessTokenGenerator;


        public CreateUserUseCase(IUserRepository userRepository, IPasswordEncripter passwordEncripter, IUnitOfWork unitOfWork, IAccessTokenGenerator accessTokenGenerator)
        {
            _userRepository = userRepository;
            _passwordEncripter = passwordEncripter;
            _unitOfWork = unitOfWork;
            _accessTokenGenerator = accessTokenGenerator;
        }

        public async Task<CreateUserResponseJson> Execute(CreateUserRequestJson request)
        {
            Validate(request);
            var passwordEncrypted = _passwordEncripter.Encrypt(request.Password);
            var user = new User(request.FirstName, request.LastName, request.Email, passwordEncrypted, request.Avatar);
            var token = _accessTokenGenerator.Generate(user.Id);
            await _userRepository.AddAsync(user);
            var response = new CreateUserResponseJson
            {
                Name = user.GetFullName(),
                Token = new ResponseTokenJson
                {
                    AccessToken = token
                }
            };
            return response;
        }

        private async Task Validate(CreateUserRequestJson request)
        {
            var validator = new CreateUserValidator();
            var result = await validator.ValidateAsync(request);
            var emailExists = await _userRepository.ExistActiveUserWithEmail(request.Email);
            if (emailExists)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure("Email", ResourceMessagesException.EMAIL_ALREADY_EXISTS));
            }
            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            }
        }
    }
}