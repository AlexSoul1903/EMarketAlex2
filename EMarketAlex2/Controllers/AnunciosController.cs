using EMarketAlex2.Core.Aplication.Interfaces.Services;
using EMarketAlex2.Core.Aplication.ViewModels.Anuncios;
using EMarketAlex2.Core.Domain.Entities;
using EMarketAlex2.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EMarketAlex2.Controllers
{




    public class AnunciosController : Controller
    {

        private readonly IAnunciosServices _anunciosServices;
        private readonly ICategoriasServices _categoriesServices;
        private readonly ValidarSession _validarSession;

        public AnunciosController(IAnunciosServices anunciosServices, ICategoriasServices categoriesServices, ValidarSession validarSession)
        {
            _anunciosServices = anunciosServices;
            _categoriesServices = categoriesServices;
            _validarSession = validarSession;
        }

        public async Task<IActionResult> Index()
        {

            if (!_validarSession.VerificarUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            return View(await _anunciosServices.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {

            SaveAnuncioViewModel vm = new();

            vm.CategoriaList = await _categoriesServices.GetAllViewModel();

            return View("SaveAnuncio", vm);


        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveAnuncioViewModel vm)
        {
            if (!_validarSession.VerificarUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }
            if (!ModelState.IsValid)
            {
                vm.CategoriaList = await _categoriesServices.GetAllViewModel();
                return View("SaveAnuncio", vm);

            }

            SaveAnuncioViewModel anuncioVm = await _anunciosServices.add(vm);

            if (anuncioVm.IdAnuncio != 0 && anuncioVm != null)
            {

                
                anuncioVm.Imagen1 = SubirArchivo(vm.File1, anuncioVm.IdAnuncio);

                    anuncioVm.Imagen2 = SubirArchivo(vm.File2, anuncioVm.IdAnuncio);
                

               
                    anuncioVm.Imagen3 = SubirArchivo(vm.File3, anuncioVm.IdAnuncio);
                
               
                    anuncioVm.Imagen4 = SubirArchivo(vm.File4, anuncioVm.IdAnuncio);
                

                    anuncioVm.Imagen5 = SubirArchivo(vm.File5, anuncioVm.IdAnuncio);
                
                await _anunciosServices.Update(anuncioVm);
            }
            


            return RedirectToRoute(new { controller = "Anuncios", action = "Index" });


        }

        public async Task<IActionResult> Edit(int Id)
        {

            if (!_validarSession.VerificarUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }


            SaveAnuncioViewModel vm = await _anunciosServices.GetByIdAnuncioViewModel(Id);
            vm.CategoriaList = await _categoriesServices.GetAllViewModel();
            return View("SaveAnuncio", vm);

        }


        [HttpPost]

        public async Task<IActionResult> Edit(SaveAnuncioViewModel vm)
        {

            if (!_validarSession.VerificarUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });


            }

            if (!ModelState.IsValid)
            {
                vm.CategoriaList = await _categoriesServices.GetAllViewModel();

                return View("SaveAnuncio", vm);

            }

            SaveAnuncioViewModel anuncioVm = await _anunciosServices.GetByIdAnuncioViewModel(vm.IdAnuncio);

            if (anuncioVm.Imagen1 != null)
            {

                vm.Imagen1 = SubirArchivo(vm.File1, vm.IdAnuncio, true, anuncioVm.Imagen1);
            }
            else if (anuncioVm.Imagen1 == null)
            {

                vm.Imagen1 = anuncioVm.Imagen1;
            }
            if (anuncioVm.Imagen2 != null)
            {
                vm.Imagen2 = SubirArchivo(vm.File2, vm.IdAnuncio, true, anuncioVm.Imagen2);
            }else if(anuncioVm.Imagen2 == null)
            {

                vm.Imagen2 = anuncioVm.Imagen2;
            }

            if (anuncioVm.Imagen3 != null)
            {

                vm.Imagen3 = SubirArchivo(vm.File3, vm.IdAnuncio, true, anuncioVm.Imagen3);
            }
            else if (anuncioVm.Imagen3 == null)
            {

                vm.Imagen3 = anuncioVm.Imagen3;
            }

            if (anuncioVm.Imagen4 != null)
            {

                vm.Imagen4 = SubirArchivo(vm.File4, vm.IdAnuncio, true, anuncioVm.Imagen4);
            }
            else if (anuncioVm.Imagen4 == null)
            {

                vm.Imagen4 = anuncioVm.Imagen4;
            }
            if (anuncioVm.Imagen5 != null)
            {


                vm.Imagen5 = SubirArchivo(vm.File5, vm.IdAnuncio, true, anuncioVm.Imagen5);
            }
            else if (anuncioVm.Imagen5 == null)
            {

                vm.Imagen5 = anuncioVm.Imagen5;
            }

            await _anunciosServices.Update(vm);


            return RedirectToRoute(new { controller = "Anuncios", action = "Index" });


        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!_validarSession.VerificarUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            return View(await _anunciosServices.GetByIdAnuncioViewModel(Id));


        }

        [HttpPost]
        public async Task<IActionResult>Delete(SaveAnuncioViewModel vm)
        {

            if (!_validarSession.VerificarUsuario())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });

            }

            await _anunciosServices.Delete(vm);

            string basePath= "/css/assets/imgs/AnunciosPhotos/" + vm.IdAnuncio;

            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (Directory.Exists(path))
            {

                DirectoryInfo directory = new(path);

                foreach(FileInfo file in directory.GetFiles())
                {

                    file.Delete();

                }

                foreach(DirectoryInfo folder in directory.GetDirectories())
                {

                    folder.Delete(true);
                }

                Directory.Delete(path);


            }

            return RedirectToRoute(new { controller = "Anuncios", action = "Index" });



        }


        private string SubirArchivo(IFormFile file, int id, bool isEditMode=false, string imagePath="")
        {

            if (isEditMode)
            {
                if (file == null)
                {

                    return imagePath;
                }


            }

            //Obtener la ruta del directorio

            string BaseRute = "/css/assets/imgs/AnunciosPhotos/" + id;

            string rute = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + BaseRute);


            //Crar folder en caso de que no exista

            if (!Directory.Exists(rute))
            {

                Directory.CreateDirectory(rute);

            }


            //Obtener la ruta del archivo
            Guid guid = Guid.NewGuid();

            FileInfo infofile = new(file.FileName);

            string FN = guid + infofile.Extension;

            string finalroute = Path.Combine(rute, FN);

            using (var stream = new FileStream(finalroute, FileMode.Create))
            {

                file.CopyTo(stream);

            }

            if (isEditMode)
            {
                string[] oldImagePart = imagePath.Split("/");
                string oldImagePath = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(rute, oldImagePath);

                if (System.IO.File.Exists(completeImageOldPath))
                {

                    System.IO.File.Delete(completeImageOldPath);

                }


            }

            return $"{BaseRute}/{FN}";

        }




    }
}
