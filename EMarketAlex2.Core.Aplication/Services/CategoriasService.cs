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
    public class CategoriasService : ICategoriasServices
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly UserViewModel _userViewModel;
        private readonly CategoriasViewModel _categoriasViewModel;

        public CategoriasService(ICategoriesRepository categoriesRepository, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _categoriesRepository = categoriesRepository;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _categoriasViewModel = new CategoriasViewModel();
            _userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("usuario");
        }

        public async Task<SaveCategoriaViewModel> add(SaveCategoriaViewModel vm)
        {
            Categorias categorias = new();

            categorias.Descripcion = vm.Descripcion;
            categorias.Name = vm.Name;
            categorias = await _categoriesRepository.AddAsync(categorias);

            SaveCategoriaViewModel saveCategoriaViewModel = new SaveCategoriaViewModel();

            saveCategoriaViewModel.IdCategoria = categorias.IdCategoria;
            saveCategoriaViewModel.Descripcion = categorias.Descripcion;
            saveCategoriaViewModel.Name = categorias.Name;
            return saveCategoriaViewModel;


        }

        public async Task Delete(SaveCategoriaViewModel vm)
        {
            Categorias categorias = new();

            categorias = await _categoriesRepository.GetByIdAsync(vm.IdCategoria);
            await _categoriesRepository.DeleteAsync(categorias);
        }

        public async Task<List<CategoriasViewModel>> GetAllViewModel()
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

        public async Task<SaveCategoriaViewModel> GetByIdAnuncioViewModel(int Id)
        {
            
            var categoria = await _categoriesRepository.GetByIdAsync(Id);

            SaveCategoriaViewModel vm = new();
            vm.IdCategoria= categoria.IdCategoria;
            vm.Descripcion = categoria.Descripcion;
            vm.Name = categoria.Name;

            return vm;


        }

        public async Task Update(SaveCategoriaViewModel vm)
        {
            Categorias categorias = await _categoriesRepository.GetByIdAsync(vm.IdCategoria);
            categorias.Descripcion = vm.Descripcion;
            categorias.IdCategoria = vm.IdCategoria;
            categorias.Name = vm.Name;

            await _categoriesRepository.UpdateAsync(categorias);

        }
    }
}
