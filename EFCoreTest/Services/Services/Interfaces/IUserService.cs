using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ViewModels.UserViewModels;

namespace Services.Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetUsersForDropdown();

    }
}
