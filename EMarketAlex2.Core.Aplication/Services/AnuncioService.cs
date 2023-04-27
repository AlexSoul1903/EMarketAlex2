using AutoMapper;
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
    public class AnuncioService:GenericService<SaveAnuncioViewModel,AnuncioViewModel,Anuncios>,IAnunciosServices

    {

        private readonly IAnuncioRepository _anuncioRepository;
        private readonly UserViewModel _UserViewModel;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public AnuncioService(IAnuncioRepository anuncioRepository, IHttpContextAccessor httpContextAccessor,IMapper mapper):base(anuncioRepository,mapper)
        {
            _anuncioRepository = anuncioRepository;
            _httpContextAccessor = httpContextAccessor;
            _UserViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("usuario");
            _mapper=mapper;

        }


        public override async Task <SaveAnuncioViewModel> add(SaveAnuncioViewModel vm)
       {



            vm.miUserId = _UserViewModel.Id;
           
            return await base.add(vm);


        }

       

        public async Task<List<AnuncioViewModel>> GetAllViewModelWithInclude()
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

       

        public override async Task Update(SaveAnuncioViewModel vm,int id)
        {


            vm.miUserId = _UserViewModel.Id;

            await base.Update(vm,id);
           
        }

   
  

        public async Task<List<AnuncioViewModel>>GetAllModelFilter()
        {

            var anuncioList = await _anuncioRepository.GetAllWithIncludeAsync(new List<string> { "categorias","user"});

           return anuncioList.Where(anuncio => anuncio.miUserId != _UserViewModel.Id).Select(anuncio => new AnuncioViewModel
            {
                nombre_anuncio = anuncio.nombre_anuncio,
                IdAnuncio = anuncio.IdAnuncio,
                descripcion = anuncio.descripcion,
                Imagen1 = anuncio.Imagen1,
                Imagen2 = anuncio.Imagen2,
                Imagen3 = anuncio.Imagen3,
                Imagen4 = anuncio.Imagen4,
                CategoryName = anuncio.categorias.Name,
               miCategoriaId = anuncio.miCategoriaId,
                Imagen5 = anuncio.Imagen5,
                precio = anuncio.precio,
                CreatedDate = anuncio.CreatedDate,
                CreatedBy = anuncio.CreatedBy,
                miUserId=anuncio.miUserId,
                



            }).ToList();


        }

        public async Task<List<AnuncioViewModel>> Filtro (List<int> IdCategorias)
        {

            List<AnuncioViewModel> anuncioViewModelsSinFiltro = await GetAllModelFilter();
            List<AnuncioViewModel> anuncioViewModelsFiltro = new();

            anuncioViewModelsFiltro = anuncioViewModelsSinFiltro.Where(anuncio => IdCategorias.Contains(anuncio.miCategoriaId)).ToList();

            return anuncioViewModelsFiltro;
        }
    }
}
