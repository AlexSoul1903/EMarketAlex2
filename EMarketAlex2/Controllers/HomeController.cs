using EMarketAlex2.Core.Aplication.Interfaces.Services;
using EMarketAlex2.Core.Aplication.Services;
using EMarketAlex2.Core.Aplication.ViewModels.Anuncios;
using EMarketAlex2.Core.Aplication.ViewModels.Users;
using EMarketAlex2.Core.Domain.Entities;
using EMarketAlex2.Middlewares;
using EMarketAlex2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EMarketAlex2.Controllers
{
    public class HomeController : Controller
    {

        private readonly AnuncioService  _anuncioServices;
        private readonly IUserServices _userServices;
        private readonly ICategoriasServices _categoriasService;
        private readonly ValidarSession _validarSession;
        private readonly FilterAnuncioViewModel _filterAnuncioViewModel;
   
        public HomeController(IAnunciosServices anunciosServices, ICategoriasServices categoriasServices, ValidarSession validarSession, IUserServices userServices)
        {

            _anuncioServices = (AnuncioService)anunciosServices;
            _categoriasService = categoriasServices;
            _validarSession = validarSession;
            _userServices = userServices;
            _filterAnuncioViewModel = new();
       }

        public async Task<IActionResult> Index(List<int> IdCategorias)
        {

            if (!_validarSession.VerificarUsuario())
            {

                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            if (IdCategorias.Count != 0)
            {
                _filterAnuncioViewModel.anuncioslist = await _anuncioServices.Filtro(IdCategorias);
            }
            else
            {
                _filterAnuncioViewModel.anuncioslist = await _anuncioServices.GetAllModelFilter();

            }

            _filterAnuncioViewModel.Categorias = await _categoriasService.GetAllViewModel();



            ViewBag.CategoriasList = await _categoriasService.GetAllViewModel();
            return View(_filterAnuncioViewModel);
         

        }
        public async Task<IActionResult>Detalles (int id)
        {
            if (!_validarSession.VerificarUsuario())
            {

                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            ViewBag.CategoriasList = await _categoriasService.GetAllViewModel();
           var catList = await _categoriasService.GetAllViewModel();
            var anunOne= await _anuncioServices.GetByIdAnuncioViewModel(id);
            var user = await _userServices.GetAllViewModel();

            ViewBag.Correo = user.FirstOrDefault(us => us.Username == anunOne.CreatedBy)?.Email;
            ViewBag.CategoryNam = catList.FirstOrDefault(categoria => categoria.IdCategoria == anunOne.miCategoriaId)?.Name;
            ViewBag.Telefono = user.FirstOrDefault(us => us.Username == anunOne.CreatedBy)?.Phone;
            ViewBag.Date = anunOne.CreatedDate.Date;
            return View(await _anuncioServices.GetByIdAnuncioViewModel(id));


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
