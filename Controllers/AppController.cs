using ComponentesMVC._1_Entities;
using ComponentesMVC._2_Conexion.Contextos;
using ComponentesMVC._2_Conexion.Repositorios;
using ComponentesMVC._3_Servicios.Servicios;
using ComponentesMVC.Models;
using ComponentesMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ComponentesMVC.Controllers
{
    public static class Message
    {

        public static string msj;
        

    }

    public class AppController : Controller
    {
        private readonly ILogger<AppController> _logger;       


        public AppController(ILogger<AppController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            ViewBag.SuccessMessage = Message.msj;
            Message.msj = null;
            return View();
            
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            ViewBag.SuccessMessage = "Account created successfully...";

            if (model.Email.Equals("johan@gmail.com") && model.Password.Equals("1234"))
            {
                return RedirectToAction("Index", "App");

            }
            else
            {
                ViewBag.UserMessage = "Wrong........";
                return View();
            }   
        }

        [HttpGet("account")]
        public IActionResult Account()
        {
            return View();
        }

        [HttpPost("account")]
        public IActionResult Account(AccountViewModel model)
        {
            Usuario user = new Usuario();
            Mascota pet = new Mascota();
            user.nombre = model.Name;
            user.correo = model.Email;
            user.telefono = model.PhoneNumber;
            user.buscar_tipo = model.PetKind;
            user.buscar_raza = model.PetBreed;
            user.contrasenia = model.Password;
            pet.correoUsuraio = model.Email;
            pet.nombre = model.PetName;
            pet.raza = model.Breed;
            pet.tipo = model.Kind;
            pet.sexo = model.Sex;

            if (!model.Password.Equals(model.ConfirmPassword))
            {
                ViewBag.WrongPass = "The password is not the same";

            }
            else {
              
            Message.msj = "Account created successfully...";
            ModelState.Clear();
            Post(user);
            PostMascota(pet);
            // Login(msj);
            return RedirectToAction("Login", "App");


                
            }


            return View();
        }




        /*
        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
        ////////////////////CONTROLADORES DEL API///////////////
        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
        */
        [Route("api/[controller]")]
        /*
        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
        /////////////////CONTROLADORES DEL USUARIO//////////////
        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
        */
        UsuarioServicio CrearServicio()
        {
            Conexion db = new Conexion();
            UsuarioRepositorio repo = new UsuarioRepositorio(db);
            UsuarioServicio servicio = new UsuarioServicio(repo);
            return servicio;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.seleccionarPorId(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            var servicio = CrearServicio();
            servicio.Agregar(usuario);
            return Ok("Agregar Satisfactoriamente");
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            var servicio = CrearServicio();
            usuario._id = id;
            servicio.Editar(usuario);
            return Ok("Editado correctamennte");

        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Eliminado correctamente");

        }


        /*
        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
        /////////////////CONTROLADORES DE LA MASCOTA////////////
        ////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////
        */

        MascotaServicio CrearServicioMascota()
        {
            Conexion db = new Conexion();
            MascotaRepositorio repo = new MascotaRepositorio(db);
            MascotaServicio servicio = new MascotaServicio(repo);
            return servicio;
        }
        // GET: api/<MascotaController>
        [HttpGet]
        public ActionResult<List<Mascota>> GetMascota()
        {
            var servicio = CrearServicioMascota();
            return Ok(servicio.Listar());
        }

        // GET api/<MascotaController>/5
        [HttpGet("{id}")]
        public ActionResult<Mascota> GetMascota(Guid id)
        {
            var servicio = CrearServicioMascota();
            return Ok(servicio.seleccionarPorId(id));
        }

        // POST api/<MascotaController>
        [HttpPost]
        public ActionResult PostMascota([FromBody] Mascota pMascota)
        {
            var servicio = CrearServicioMascota();
            servicio.Agregar(pMascota);
            return Ok("Agregada Satisfactoriamente");
        }

        // PUT api/<MascotaController>/5
        [HttpPut("{id}")]
        public ActionResult PutMascota(Guid id, [FromBody] Mascota mascota)
        {
            var servicio = CrearServicioMascota();
            mascota._id = id;
            servicio.Editar(mascota);
            return Ok("Editado correctamennte");

        }

        // DELETE api/<MascotaController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMascota(Guid id)
        {
            var servicio = CrearServicioMascota();
            servicio.Eliminar(id);
            return Ok("Eliminado correctamente");

        }

    }
}