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
    public class HomeController : Controller
    {

        //Al importar "using Microsoft.EntityFrameworkCore;" podemos usar tambien métodos async

        public readonly ApplicationDBContext _contextDB;

        public HomeController(ApplicationDBContext contextDB)
        {

            _contextDB = contextDB;

           
        }

        //Renderiza vista principal o home

        public async Task<IActionResult> Index()
        {
            return View(await _contextDB.Usuario.ToListAsync());
        }

        //Renderiza pagina o componente de privacy
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
