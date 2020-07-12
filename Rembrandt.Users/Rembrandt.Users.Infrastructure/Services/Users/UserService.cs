using System;
using System.Threading.Tasks;
using AutoMapper;
using Rembrandt.Contracts.Classes.Jwt;
using Rembrandt.Users.Core.Models;
using Rembrandt.Users.Core.Repositories;

namespace Rembrandt.Users.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;

        public UserService(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encrypter = encrypter;
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            var user = await _userRepository.GetUserAsync(email);

            if(user == null)
                throw new Exception("No user in database with this email address!");

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            if(String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("One of username or login should not be null!");

            var user = await _userRepository.GetUserAsync(email);
            if(user == null)
                throw new ArgumentNullException($"Invalid credentials!");

            var hash = _encrypter.GetHash(password, user.Salt);
            if(user.Password == hash)
                return;

            throw new ArgumentNullException($"Invalid credentials!");
        }

        public async Task RegisterAsync(string email, string password)
        {
            if(await _userRepository.GetUserAsync(email) != null)
                throw new Exception("User already exists!");

            var salt = _encrypter.GetSalt();
            var hashPassowrd = _encrypter.GetHash(password, salt);

            await _userRepository.AddUserAsync(new User(email, hashPassowrd, salt));
        }
    }
}