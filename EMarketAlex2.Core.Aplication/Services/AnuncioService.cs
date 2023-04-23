using EMarketAlex2.Core.Aplication.Helpers;
using EMarketAlex2.Core.Aplication.Interfaces.Repositories;
using EMarketAlex2.Core.Aplication.Interfaces.Services;
using EMarketAlex2.Core.Aplication.ViewModels.Anuncios;
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
    public class AnuncioService:IAnunciosServices

    {

        private readonly IAnuncioRepository _anuncioRepository;
        private readonly UserViewModel _UserViewModel;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AnuncioService(IAnuncioRepository anuncioRepository, IHttpContextAccessor httpContextAccessor)
        {
            _anuncioRepository = anuncioRepository;
            _httpContextAccessor = httpContextAccessor;
            _UserViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("usuario");

        }


        public async Task <SaveAnuncioViewModel> add(SaveAnuncioViewModel vm)
       {



            Anuncios anuncio = new();

            
            anuncio.precio = vm.precio;
            anuncio.descripcion = vm.descripcion;
            anuncio.miCategoriaId = vm.miCategoriaId;
            anuncio.nombre_anuncio = vm.nombre_anuncio;
            anuncio.Imagen1 = vm.Imagen1;
            anuncio.Imagen2 = vm.Imagen2;
            anuncio.Imagen3 = vm.Imagen3;
            anuncio.Imagen4 = vm.Imagen4;
            anuncio.Imagen5 = vm.Imagen5;
            anuncio.miUserId = _UserViewModel.Id;

            anuncio = await _anuncioRepository.AddAsync(anuncio);

            SaveAnuncioViewModel anuncioVm = new SaveAnuncioViewModel();

            anuncioVm.precio = anuncio.precio;
            anuncioVm.descripcion = anuncio.descripcion;
            anuncioVm.miCategoriaId = anuncio.miCategoriaId;
            anuncioVm.IdAnuncio = anuncio.IdAnuncio;
            anuncioVm.nombre_anuncio = anuncio.nombre_anuncio;

            anuncioVm.Imagen1= vm.Imagen1;
            anuncioVm.Imagen2 =vm.Imagen2;
            anuncioVm.Imagen3 = vm.Imagen3;
            anuncioVm.Imagen4 = vm.Imagen4;
            anuncioVm.Imagen5 = vm.Imagen5;

           return anuncioVm;


        }

        public async Task Delete(SaveAnuncioViewModel vm)
        {

            Anuncios anuncios = new();
            anuncios.IdAnuncio = vm.IdAnuncio;
            anuncios.descripcion = vm.descripcion;
            anuncios.miCategoriaId=vm.miCategoriaId;
            anuncios.nombre_anuncio=vm.nombre_anuncio;
            anuncios.precio = vm.precio;

            anuncios.Imagen1 = vm.Imagen1;
            anuncios.Imagen2 = vm.Imagen2;
            anuncios.Imagen3 = vm.Imagen3;
            anuncios.Imagen4 = vm.Imagen4;
            anuncios.Imagen5 = vm.Imagen5;

            anuncios = await _anuncioRepository.GetByIdAsync(vm.IdAnuncio);
            await _anuncioRepository.DeleteAsync(anuncios);

        }

        public async Task<List<AnuncioViewModel>> GetAllViewModel()
        {
            var anuncioList = await  _anuncioRepository.GetAllWithIncludeAsync(new List<string> { "categorias" });

          return anuncioList.Where(anuncio => anuncio.miUserId == _UserViewModel.Id).Select(anuncio => new AnuncioViewModel
            {

                IdAnuncio = anuncio.IdAnuncio,
                descripcion = anuncio.descripcion,
                Imagen1 = anuncio.Imagen1,
                Imagen2 = anuncio.Imagen2,
                Imagen3 = anuncio.Imagen3,
                nombre_anuncio=anuncio.nombre_anuncio,
                Imagen4=anuncio.Imagen4,
                precio=anuncio.precio,
                CategoryName=anuncio.categorias.Name,
                Imagen5=anuncio.Imagen5,
                CreatedDate = anuncio.CreatedDate,
                CreatedBy = anuncio.CreatedBy


            }).ToList();
        }

        public Task<List<AnuncioViewModel>> GetAnuncioViewModels(FilterAnuncioViewModel filter)
        {
            throw new NotImplementedException();
        }

        public async Task<SaveAnuncioViewModel> GetByIdAnuncioViewModel(int Id)
        {
            var anuncio = await _anuncioRepository.GetByIdAsync(Id);

            SaveAnuncioViewModel vm = new();

            vm.IdAnuncio = anuncio.IdAnuncio;
            vm.miCategoriaId = anuncio.miCategoriaId;
            vm.descripcion = anuncio.descripcion;
            vm.precio = anuncio.precio;
            vm.nombre_anuncio = anuncio.nombre_anuncio;
            vm.Imagen1 = anuncio.Imagen1;
            vm.Imagen2 = anuncio.Imagen2;
            vm.Imagen3 = anuncio.Imagen3;
            
            vm.Imagen4 = anuncio.Imagen4;
            vm.Imagen5 = anuncio.Imagen5;
            vm.CreatedDate = anuncio.CreatedDate;
            vm.CreatedBy = anuncio.CreatedBy;

            return vm;

        }

        public async Task Update(SaveAnuncioViewModel vm)
        {

            Anuncios anuncio = await _anuncioRepository.GetByIdAsync(vm.IdAnuncio);

            anuncio.IdAnuncio = vm.IdAnuncio;
            anuncio.Imagen1 = vm.Imagen1;
            anuncio.Imagen2 = vm.Imagen2;
            anuncio.Imagen3 = vm.Imagen3;
            anuncio.Imagen4 = vm.Imagen4;
            anuncio.Imagen5 = vm.Imagen5;
            anuncio.miCategoriaId = vm.miCategoriaId;
            anuncio.nombre_anuncio = vm.nombre_anuncio;
            anuncio.precio = vm.precio;
            vm.descripcion = vm.descripcion;
           
            await _anuncioRepository.UpdateAsync(anuncio);
           
        }

        public async Task<List<AnuncioViewModel>>GetAllModelFilter(FilterAnuncioViewModel filter)
        {

            var anuncioList = await _anuncioRepository.GetAllWithIncludeAsync(new List<string> { "categorias" });

            var Lista = anuncioList.Where(anuncio => anuncio.miUserId != _UserViewModel.Id).Select(anuncio => new AnuncioViewModel
            {
                nombre_anuncio = anuncio.nombre_anuncio,
                IdAnuncio = anuncio.IdAnuncio,
                descripcion = anuncio.descripcion,
                Imagen1 = anuncio.Imagen1,
                Imagen2 = anuncio.Imagen2,
                Imagen3 = anuncio.Imagen3,
                Imagen4 = anuncio.Imagen4,
                CategoryName = anuncio.categorias.Name,
                CategoryId = anuncio.miCategoriaId,
                Imagen5 = anuncio.Imagen5,
                precio = anuncio.precio,
                CreatedDate = anuncio.CreatedDate,
                CreatedBy = anuncio.CreatedBy,
                miUserId=anuncio.miUserId,
                




            }).ToList();

            if (filter.IdCategoria != null)
            {
                Lista = Lista.Where(anuncio => anuncio.CategoryId == filter.IdCategoria.Value).ToList();

            }
           

            return Lista;

        }
    }
}
