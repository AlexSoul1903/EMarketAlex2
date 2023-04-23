using EMarketAlex2.Core.Aplication.Interfaces.Services;
using EMarketAlex2.Core.Aplication.Services;
using EMarketAlex2.Core.Aplication.ViewModels.Anuncios;
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

        private readonly AnuncioService _anuncioServices;
        private readonly CategoriasService _categoriasService;
        private readonly ValidarSession _validarSession;
   
        public HomeController(IAnunciosServices anunciosServices, ICategoriasServices categoriasServices, ValidarSession validarSession)
        {

            _anuncioServices = (AnuncioService)anunciosServices;
            _categoriasService = (CategoriasService)categoriasServices;
            _validarSession = validarSession;
           
        }

        public async Task<IActionResult> Index(FilterAnuncioViewModel vm)
        {

            if (!_validarSession.VerificarUsuario())
            {

                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            ViewBag.CategoriasList = await _categoriasService.GetAllViewModel();

            return View(await _anuncioServices.GetAllModelFilter(vm));
         

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
