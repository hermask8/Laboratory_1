using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab1_Edwin.Data;
using lab1_Edwin.Models;
using directorios = System.IO;
namespace lab1_Edwin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Elegir()
        {
            return View();
        }
        public ActionResult Ingresar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ingresar(FormCollection Player)
        {
            try
            {
                var model = new Jugadores
                {
                    ID = Jugador.Instance.Jugadores.Count + 1,
                    Nombre = Player["Nombre"],
                    Apellido = Player["Apellido"],
                    Posición = Player["Posicion"],
                    Salario = Convert.ToDecimal(Player["Salarios"]),
                    Club = Player["Club"]
                };
                Jugador.Instance.Jugadores.Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AgregarManual()
        {
            return View(Jugador.Instance.Jugadores);
        }

        [HttpPost]
        public ActionResult AgregarManual(HttpPostedFileBase archivo)
        {
            string pathArchivo = string.Empty;
            if (archivo != null)
            {
                string path = Server.MapPath("~/Cargas/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                pathArchivo = path + Path.GetFileName(archivo.FileName);
                string extension = Path.GetExtension(archivo.FileName);
                archivo.SaveAs(pathArchivo);
                Random miRandom = new Random();
                string archivoCsv = directorios.File.ReadAllText(pathArchivo);
                foreach (string lineas in archivoCsv.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(lineas))
                    {
                        var model = (new Jugadores
                        {
                            ID = Jugador.Instance.Jugadores.Count + 1,
                            Club = Convert.ToString(lineas.Split(',')[0]),
                            Apellido = Convert.ToString(lineas.Split(',')[1]),
                            Nombre = Convert.ToString(lineas.Split(',')[2]),
                            Posición = Convert.ToString(lineas.Split(',')[3]),
                            Salario = Convert.ToDecimal((lineas.Split(',')[4])),
                            Compensaciones = Convert.ToDecimal((lineas.Split(',')[5]))

                        });
                        Jugador.Instance.Jugadores.Add(model);
                    }
                }
            }
            //return View(Jugador.Instance.Jugadores);
            return RedirectToAction("Index");
        }
        List<Jugadores> busquedas = new List<Jugadores>();
        public ActionResult BuscarJugador()
        {
            return View(busquedas);
        }

        [HttpPost]
        public ActionResult BuscarJugador(string nombre, string apellido, string salarioIgual, string salarioMayor, string salarioMenor
            , string posicion, string club)
        {
            decimal salario = 0;
            decimal salario1 = 0;
            decimal salario2 = 0;

            foreach (var model in Data.Jugador.Instance.Jugadores)
            {
                if (model.Nombre == nombre || model.Apellido == apellido || model.Posición == posicion || model.Club == club)
                {
                    busquedas.Add(model);
                }
                if (salarioIgual != "")
                {
                    salario = Convert.ToDecimal(salarioIgual);
                    if (model.Salario == salario)
                    {
                        busquedas.Add(model);
                    }
                }
                if (salarioMayor != "")
                {
                    salario1 = Convert.ToDecimal(salarioMayor);
                    if (model.Salario > salario1)
                    {
                        busquedas.Add(model);
                    }
                }
                if (salarioMenor != "")
                {
                    salario2 = Convert.ToDecimal(salarioMenor);
                    if (model.Salario < salario2)
                    {
                        busquedas.Add(model);
                    }
                }

            }

            return View("Index", busquedas);
        }

        public ActionResult Delete(int id)
        {
            var model = Data.Jugador.Instance.Jugadores.FirstOrDefault(x => x.ID == id);
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Data.Jugador.Instance.Jugadores.Remove(Data.Jugador.Instance.Jugadores.First(x => x.ID == id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EliminarconArchivo()
        {
            return View(Jugador.Instance.JugadoresEliminar);
        }
        [HttpPost]
        public ActionResult EliminarconArchivo(HttpPostedFileBase archivo)
        {
            string pathArchivo = string.Empty;
            if (archivo != null)
            {
                string path = Server.MapPath("~/Cargas/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                pathArchivo = path + Path.GetFileName(archivo.FileName);
                string extension = Path.GetExtension(archivo.FileName);
                archivo.SaveAs(pathArchivo);
                Random miRandom = new Random();
                string archivoCsv = directorios.File.ReadAllText(pathArchivo);
                foreach (string lineas in archivoCsv.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(lineas))
                    {
                        var model = (new Jugadores
                        {
                            Club = Convert.ToString(lineas.Split(',')[0]),
                            Apellido = Convert.ToString(lineas.Split(',')[1]),
                            Nombre = Convert.ToString(lineas.Split(',')[2]),
                        });
                        Jugador.Instance.JugadoresEliminar.Add(model);
                        Jugador.Instance.Jugadores.Remove(Jugador.Instance.Jugadores.First(x => x.Nombre == model.Nombre && x.Apellido == model.Apellido && x.Club == model.Club));
                    }
                }
            }
            return View(Jugador.Instance.JugadoresEliminar);
        }

        public ActionResult LinkedList()
        {
            return View(miListaLink);
        }
        LinkedList<Jugadores> miListaLink = new LinkedList<Jugadores>();
        [HttpPost]
        public ActionResult LinkedList(HttpPostedFileBase archivo5)
        {
            ListaLink miLista = new ListaLink();

            string pathArchivo = string.Empty;
            if (archivo5 != null)
            {
                string path = Server.MapPath("~/Cargas/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                pathArchivo = path + Path.GetFileName(archivo5.FileName);
                string extension = Path.GetExtension(archivo5.FileName);
                archivo5.SaveAs(pathArchivo);
                Random miRandom = new Random();
                string archivoCsv = directorios.File.ReadAllText(pathArchivo);
                foreach (string lineas in archivoCsv.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(lineas))
                    {
                        var model = (new Jugadores
                        {
                            ID = Jugador.Instance.Jugadores.Count + 1,
                            Club = Convert.ToString(lineas.Split(',')[0]),
                            Apellido = Convert.ToString(lineas.Split(',')[1]),
                            Nombre = Convert.ToString(lineas.Split(',')[2]),
                            Posición = Convert.ToString(lineas.Split(',')[3]),
                            Salario = Convert.ToDecimal((lineas.Split(',')[4])),
                            Compensaciones = Convert.ToDecimal((lineas.Split(',')[5]))

                        });
                        miLista.agregar(model);
                    }
                }
            }
            miListaLink = miLista.retornarLista();
            //return View(Jugador.Instance.Jugadores);
            return View("Index",miListaLink);
            
        }
       

        public ActionResult Index()
        {
            return View(Jugador.Instance.Jugadores);
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