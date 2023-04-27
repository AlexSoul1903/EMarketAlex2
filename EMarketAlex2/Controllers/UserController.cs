using EMarketAlex2.Core.Aplication.Helpers;
using EMarketAlex2.Core.Aplication.Interfaces.Services;
using EMarketAlex2.Core.Aplication.ViewModels.Users;
using EMarketAlex2.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace EMarketAlex2.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserServices _userServices;
        
        private readonly ValidarSession _validarSession;

        public UserController(IUserServices userServices, ValidarSession validarSession)
        {
            _userServices = userServices;
            _validarSession = validarSession;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUserViewModel logVm)
        {
            if (_validarSession.VerificarUsuario())
            {

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (!ModelState.IsValid)
            {

                return View(logVm);

            }

            UserViewModel usVM = await _userServices.LoginAsync(logVm);

            if (usVM == null)
            {

                ModelState.AddModelError("errorDeValidacion", "Los datos son incorrectos");

                return View(logVm);

            }
            else
            {

                HttpContext.Session.Set<UserViewModel>("usuario", usVM);

                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }

        }

            public IActionResult Register(){

                if (_validarSession.VerificarUsuario())
                {

                    return RedirectToRoute(new { controller = "Home", action = "Index" });

                }

                return View("Register");


            }

        public IActionResult CerrarSession()
        {

            HttpContext.Session.Remove("usuario");

            return RedirectToRoute(new { controller = "User", action = "Index" });

        }

        [HttpPost]

        public async Task<IActionResult>Register(SaveUserViewModel RegisUservm)
        {

            if (_validarSession.VerificarUsuario())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });


            }

            if (!ModelState.IsValid)
            {

                return View("Register", RegisUservm);

            }

            SaveUserViewModel userVm = await _userServices.add(RegisUservm);

            if(userVm.Id!=0 && userVm != null)
            {

                userVm.ImgRoute = SubirArchivo(RegisUservm.File, userVm.Id);

                await _userServices.Update(userVm,userVm.Id);


            }


            return RedirectToRoute(new { controller = "User", action = "Index" });


        }

        private string SubirArchivo(IFormFile file, int id)
        {
            //Obtener la ruta del directorio

            string BaseRute = "/css/assets/imgs/UserPhoto/" + id;

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

            return Path.Combine(BaseRute, FN);

        }



    }

    }
