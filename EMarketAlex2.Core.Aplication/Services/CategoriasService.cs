using AutoMapper;
using EMarketAlex2.Core.Aplication.Helpers;
using EMarketAlex2.Core.Aplication.Interfaces.Repositories;
using EMarketAlex2.Core.Aplication.Interfaces.Services;
using EMarketAlex2.Core.Aplication.ViewModels.Categorias;
using EMarketAlex2.Core.Aplication.ViewModels.Users;
using EMarketAlex2.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Core.Aplication.Services
{
    public class CategoriasService :GenericService<SaveCategoriaViewModel,CategoriasViewModel,Categorias> ,ICategoriasServices
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly UserViewModel _userViewModel;
        private readonly CategoriasViewModel _categoriasViewModel;
        private readonly IMapper _mapper;

        public CategoriasService(ICategoriesRepository categoriesRepository, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IMapper mapper): base(categoriesRepository, mapper)
        {
            _categoriesRepository = categoriesRepository;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _categoriasViewModel = new CategoriasViewModel();
            _userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("usuario");
            _mapper = mapper;
        }


    

        public async Task<List<CategoriasViewModel>> GetAllViewModeWithIncludel()
        {
            var categoriaList = await _categoriesRepository.GetAllWithIncludeAsync(new List<string> { "Anuncios" });
          
            return categoriaList.Select(categoria => new CategoriasViewModel
          
            {

               

                IdCategoria=categoria.IdCategoria,
                Descripcion=categoria.Descripcion,
                Name=categoria.Name,
                CantidadAnunciosCate= categoria.Anuncios.Where(anuncio => anuncio.miUserId==_userViewModel.Id).Count(),
                CantidadUsuarioAnun = categoria.Anuncios.Select(anuncio=> anuncio.miUserId).Distinct().Count()
              
            }).ToList();

        }
     
    }
}
