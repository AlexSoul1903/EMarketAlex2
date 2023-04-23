using EMarketAlex2.Core.Aplication.Helpers;
using EMarketAlex2.Core.Aplication.Interfaces.Repositories;
using EMarketAlex2.Core.Aplication.ViewModels.Users;
using EMarketAlex2.Core.Domain.Entities;
using EMarketAlex2.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Infraestructure.Persistence.Repositories
{
    public class UserRepository: GenericRepository <Users>, IUserRepository
    {
        private readonly Context _dbContext;


        public UserRepository(Context dbContext): base(dbContext)
        {

            _dbContext = dbContext;


        }

        public override async Task <Users>AddAsync(Users user)
        {

            user.Password = PasswordEncryptation.ComputeSha256HashEncrypt(user.Password);

            await base.AddAsync(user);

            return user;

        }

        public async Task<Users> LogAsync(LoginUserViewModel user) {

            string pass = user.Password = PasswordEncryptation.ComputeSha256HashEncrypt(user.Password);



            Users usData = await _dbContext.Set<Users>().FirstOrDefaultAsync(us => us.Username == user.Username && us.Password == pass);
            return usData;
        
        }

    }

}
