using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{

  
    //Cuando trabajamos con vistas (MVC de ASP.NET) heredamos de  Controller (La cual tiene más caracteristicas algunas orientadas a las vistas )
    //Cuando trabajamos o creamos una web API se hereda de ControllerBase que hereda de controller 
    public class HomeController : Controller
    {

        //Al importar "using Microsoft.EntityFrameworkCore;" podemos usar tambien métodos async

        public readonly ApplicationDBContext _contextDB;

        public HomeController(ApplicationDBContext contextDB)
        {

            _contextDB = contextDB;

           
        }

        //Renderiza vista principal o home

        //Estos son métodos que se invoca mediante el asp-action="NombreMétodo"
        //Pueden tener sobrecargas
        //Poniendo como ejemplo el método create
        //Cuando no le enviamos nada por parametros lo unico que hace es renderizar una vista, invocada desde un botón que se encuentra en el Index
        /*En cambio cuando si recibe un parametro en la otra sobre carga que tiene, donde se recibe un parametro
         * de tipo Usuario (modelo que creamos) 
         * lo que hace es validar la información he insertar un nuevo usuario
         * por lo cual decimos que la segunda sobrecarga es de tipo POST

        */

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            return View(await _contextDB.Usuario.ToListAsync());
        }

        [HttpGet]
        //Renderiza pagina o componente de Create
        public IActionResult Create()
        {
            //Dentro de la vista se valida si vienen registros de la BD

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Usuario user)
        {
            //Valida que la información se encuentre justo como se expuso en el modelo
            if (ModelState.IsValid){

                _contextDB.Usuario.Add(user);
               await _contextDB.SaveChangesAsync();

                //Ejecuta el método Index() de este controller el cual regresa a la vista princippal
                return RedirectToAction(nameof(Index));


            }


            //Retorna a la misma vista de agrgegar Usuario diciendole que campos son necesarios
            return View();

                }



        [HttpGet]
        //Con este método unicamente validamos que un  registro exista para poder renderizar la vista
        public IActionResult Edit(int? Id) { 
        

            if(Id == null)
            {
                return NotFound();

            }

            //Se verifica si en BD esta el registro buscandole por el Id
            var user = _contextDB.Usuario.Find(Id);

            if(user == null)
            {
                return NotFound();

            }
            //Cuando viene nulos la respuesta es un NotFound


            //Cuando se encuentra se renderiza la  vista y se le pasa el usuario por parametro
            return View(user);
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Usuario user)
        {
            //Valida que la información se encuentre justo como se expuso en el modelo
            if (ModelState.IsValid)
            {

                _contextDB.Update(user);
                await _contextDB.SaveChangesAsync();

                //Ejecuta el método Index() de este controller el cual regresa a la vista princippal
                return RedirectToAction(nameof(Index));


            }


            //Regresa en caso de fallo a la misva vista de Editar junto con los datos que se ivan a agregar, para que no se pierda la info
            return View(user);

        }




        [HttpGet]
        
        public IActionResult Details(int? Id)
        {


            if (Id == null)
            {
                return NotFound();

            }

            //Se verifica si en BD esta el registro buscandole por el Id
            var user = _contextDB.Usuario.Find(Id);

            if (user == null)
            {
                return NotFound();

            }
            //Cuando viene nulos la respuesta es un NotFound


            //Cuando se encuentra se renderiza la  vista y se le pasa el usuario por parametro
            return View(user);



        }



        [HttpGet]
  
        //Con este método unicamente validamos que un  registro exista para poder renderizar la vista
        public IActionResult Delete(int? Id)
        {


            if (Id == null)
            {
                return NotFound();

            }

            //Se verifica si en BD esta el registro buscandole por el Id
            var user = _contextDB.Usuario.Find(Id);

            if (user == null)
            {
                return NotFound();

            }
            //Cuando viene nulos la respuesta es un NotFound


            //Cuando se encuentra se renderiza la  vista y se le pasa el usuario por parametro
            return View(user);

        }



        [HttpPost,ActionName("Delete")]//Esta cabecera indica que aunque dentro del Controller este método tiene otro nombre, en la vista el nomre es el que se indica en la etiqueta
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRegistro(int? Id)
        {

            var user = await _contextDB.Usuario.FindAsync(Id);

            if(user == null){

                return View();

            }

            _contextDB.Usuario.Remove(user);
            await _contextDB.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
