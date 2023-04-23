using EMarketAlex2.Core.Aplication.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.Interfaces.Services
{
    public interface IUserServices:IGenericServices<SaveUserViewModel,UserViewModel>
    {

        Task<UserViewModel> LoginAsync(LoginUserViewModel vm);


    }
}
