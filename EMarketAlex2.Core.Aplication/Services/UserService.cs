using EMarketAlex2.Core.Aplication.Interfaces.Repositories;
using EMarketAlex2.Core.Aplication.Interfaces.Services;
using EMarketAlex2.Core.Aplication.ViewModels.Users;
using EMarketAlex2.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.Services
{
    public class UserService : IUserServices
    {

        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {

            _userRepository = userRepository;

        }

        public async Task<SaveUserViewModel> add(SaveUserViewModel vm)
        {



            Users user = new();

            user.Edad = vm.Edad;
            user.Email = vm.Email;
            user.Nombre = vm.Nombre;
            user.Phone = vm.Phone;
            user.Username = vm.Username;
            user.Password = vm.Password;
            user.ImgRoute = vm.ImgRoute;


            user = await _userRepository.AddAsync(user);

            SaveUserViewModel userVm = new();


            userVm.Id = user.Id;
            userVm.Edad = user.Edad;

            userVm.Email = user.Email;
            userVm.Nombre = user.Nombre;
            userVm.Phone = user.Phone;
            userVm.Username = user.Username;
            userVm.Password = user.Password;
            userVm.ImgRoute = user.ImgRoute;
            return userVm;



        }

        public async Task<SaveUserViewModel> GetByIdAnuncioViewModel(int Id)
        {


            var user = await _userRepository.GetByIdAsync(Id);

            SaveUserViewModel vm = new();

            vm.Id = user.Id;
            vm.Email = user.Email;
            vm.Edad = user.Edad;
            vm.Phone = user.Phone;
            vm.Password = user.Password;
            vm.Username = user.Username;
            vm.Nombre = user.Nombre;
            vm.ImgRoute = user.ImgRoute;

            return vm;

        }

        public async Task Update(SaveUserViewModel vm)
        {



            Users user = await _userRepository.GetByIdAsync(vm.Id);
            user.Id = vm.Id;
            user.Edad = vm.Edad;
            user.Email = vm.Email;
            user.Nombre = vm.Nombre;
            user.Phone = vm.Phone;
            user.Username = vm.Username;
            user.Password = vm.Password;
            user.ImgRoute = vm.ImgRoute;

            await _userRepository.UpdateAsync(user);


        }


        public async Task<UserViewModel> LoginAsync(LoginUserViewModel vm)
        {

            Users user = await _userRepository.LogAsync(vm);

            if (user == null)
            {

                return null;

            }

            UserViewModel userVm = new();
            userVm.Id = user.Id;
            userVm.Edad = user.Edad;
            userVm.Email = user.Email;
            userVm.Nombre = user.Nombre;
            userVm.Phone = user.Phone;
            userVm.Username = user.Username;
            userVm.Password = user.Password;
            userVm.ImgRoute = user.ImgRoute;

            return userVm;


        }


        public async Task Delete(SaveUserViewModel vm)
        {

            Users user = new();
            user.Id = vm.Id;
            user.Edad = vm.Edad;
            user.Email = vm.Email;
            user.Nombre = vm.Nombre;
            user.Phone = vm.Phone;
            user.Username = vm.Username;
            user.Password = vm.Password;

            await _userRepository.DeleteAsync(user);

        }



        public async Task<List<UserViewModel>> GetAllViewModel()
        {

            var userList = await _userRepository.GetAllWithIncludeAsync(new List<string> { "anuncios" });

            return userList.Select(user => new UserViewModel
            {
                Edad = user.Edad,
                Email = user.Email,
                Id = user.Id,
                Nombre = user.Nombre,
                Password = user.Password,
                Phone = user.Phone,
                Username = user.Username,
                ImgRoute = user.ImgRoute
            }).ToList();




        }


    }
}
