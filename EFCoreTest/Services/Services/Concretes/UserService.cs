using DataAccess.Repositories.Concretes;
using DataAccess.Repositories.Interfaces;
using Domain.Models;
using Services.Mappers;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ViewModels.UserViewModels;

namespace Services.Services.Concretes
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository) // Dependency Injection
        {
            _userRepository = userRepository;
        }

        public List<UserViewModel> GetUsersForDropdown()
        {
            List<User> usersDb = _userRepository.GetAll();

            return usersDb.Select(x => x.MapToUserViewModel()).ToList();
        }
    }
}
