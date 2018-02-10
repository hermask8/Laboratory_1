using Lab1_Edwin_Ana.Models;
using System;
using System.Collections.Generic;
using System.IO;
using directorios = System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1_Edwin_Ana.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new List<Jugador>());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase archivoBase)
        {
            List<Jugador> jugadores = new List<Jugador>();
            string pathArchivo = string.Empty;
            if (archivoBase != null)
            {
                string path = Server.MapPath("~/Cargas/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                pathArchivo = path + Path.GetFileName(archivoBase.FileName);
                string extension = Path.GetExtension(archivoBase.FileName);
                archivoBase.SaveAs(pathArchivo);
                Random miRandom = new Random();
                string archivoCsv = directorios.File.ReadAllText(pathArchivo);
                foreach (string lineas in archivoCsv.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(lineas))
                    {
                        jugadores.Add(new Jugador
                        {
                            Club = Convert.ToString(lineas.Split(',')[0]),
                            Apellido = Convert.ToString(lineas.Split(',')[1]) ,
                            Nombre = Convert.ToString(lineas.Split(',')[2]) ,
                            Posicion = Convert.ToString(lineas.Split(',')[3]) ,
                            Salario = (lineas.Split(',')[4]),
                            Compensaciones = (lineas.Split(',')[5])
                        });
                    }
                }

            }
            return View(jugadores);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}