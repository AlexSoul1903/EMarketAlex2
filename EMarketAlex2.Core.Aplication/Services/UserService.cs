using AutoMapper;
using EMarketAlex2.Core.Aplication.Dtos.Email;
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
    public class UserService: GenericService<SaveUserViewModel,UserViewModel,Users>, IUserServices
    {

        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IEmailService emailService,IMapper mapper): base(userRepository,mapper)
        {

            _userRepository = userRepository;
            _emailService = emailService;
            _mapper = mapper;
        }

        public override async Task<SaveUserViewModel> add(SaveUserViewModel vm)
        {


            SaveUserViewModel userVm = await base.add(vm);
           

          

         await _emailService.SendAsync(new EmailRequest
            {
                To = userVm.Email,
                Subject= "Bienvenido a la Tieda Virtual de Alex",
                Body = $"<h1>Bienvenido al EMarket donde podras vender los mejores productos </h1> <p>Tu nombre de usuario es {userVm.Username}</p>"

            });

            return userVm;



        }

    


        public async Task<UserViewModel> LoginAsync(LoginUserViewModel vm)
        {

            Users user = await _userRepository.LogAsync(vm);

            if (user == null)
            {

                return null;

            }

            UserViewModel userVm = _mapper.Map<UserViewModel>(user);
         

            return userVm;


        }


    


        public async Task<List<UserViewModel>> GetAllViewModelWithInclude()
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
