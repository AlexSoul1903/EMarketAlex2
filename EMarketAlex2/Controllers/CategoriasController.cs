using EMarketAlex2.Core.Aplication.Interfaces.Services;
using EMarketAlex2.Core.Aplication.Services;
using EMarketAlex2.Core.Aplication.ViewModels.Anuncios;
using EMarketAlex2.Core.Aplication.ViewModels.Categorias;
using EMarketAlex2.Middlewares;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EMarketAlex2.Controllers
{
    public class CategoriasController : Controller
    {

        private readonly ICategoriasServices _categoriasServices;

        private readonly ValidarSession _validarSession;

        public CategoriasController(ICategoriasServices categoriasServices, ValidarSession validarSession)
        {
            _categoriasServices = categoriasServices;
            _validarSession = validarSession;
        }


        public async Task <IActionResult> Index()
        {
            if (!_validarSession.VerificarUsuario())
            {


                return RedirectToRoute(new { controller = "User", action = "Index" });


            }



            return View(await _categoriasServices.GetAllViewModeWithIncludel());
        }

        public IActionResult Create()
        {

            if (!_validarSession.VerificarUsuario())
            {


                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            return View("SaveCategorias", new SaveCategoriaViewModel());

        }


        [HttpPost]

        public async Task<IActionResult> Create(SaveCategoriaViewModel vm)
        {
            if (!_validarSession.VerificarUsuario())
            {


                return RedirectToRoute(new { controller = "User", action = "Index" });


            }
            if (!ModelState.IsValid)
            {
                return View("SaveCategorias", vm);

            }

            await _categoriasServices.add(vm);



            return RedirectToRoute(new { controller = "Categorias", action = "Index" });

        }

        public async Task<IActionResult>Edit(int Id)
        {

            if (!_validarSession.VerificarUsuario())
            {


                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            return View("SaveCategorias", await _categoriasServices.GetByIdAnuncioViewModel(Id));

        }

        [HttpPost]

        public async Task<IActionResult> Edit(SaveCategoriaViewModel vm)
        {

            if (!_validarSession.VerificarUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }
            if (!ModelState.IsValid)
            {
                return View("SaveCategorias", vm);

            }

            await _categoriasServices.Update(vm,vm.IdCategoria);



            return RedirectToRoute(new { controller = "Categorias", action = "Index" });



        }

        public async Task<IActionResult> Delete(int Id)
        {

            if (!_validarSession.VerificarUsuario())
            {


                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            return View(await _categoriasServices.GetByIdAnuncioViewModel(Id));

        }

        [HttpPost]

        public async Task<IActionResult>Delete(SaveCategoriaViewModel vm)
        {

            if (!_validarSession.VerificarUsuario())
            {


                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            await _categoriasServices.Delete(vm,vm.IdCategoria);


            return RedirectToRoute(new { controller = "Categorias", action = "Index" });

        }


    }
}
