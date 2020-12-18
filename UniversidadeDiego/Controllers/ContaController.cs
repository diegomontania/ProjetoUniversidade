using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversidadeDiego.Controllers
{
    public class ContaController : Controller
    {
        //retorna view Registrar
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        //retorna view Login
        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return View();
        }
    }
}
