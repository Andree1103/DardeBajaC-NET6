using Cl3AndreeChiquis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Webcl3Andree.Controllers
{
    public class ArticulosController : Controller
    {
        // GET: ArticulosController
        /*public async Task<ActionResult> IndexArticulos()
        {
            var listado = new List<Articulos>();
            using (HttpClient cliente = new HttpClient())
            {
                var respuesta = await cliente.GetAsync("https://localhost:7296/api/ArticulosAPI/GetArticulos");
                string respuestaAPI =await respuesta.Content.ReadAsStringAsync();
                listado = JsonConvert.DeserializeObject<List<Articulos>>(respuestaAPI);
            } 
            return View(listado);
        }*/

        public async Task<ActionResult> IndexArticulos(string filtro)
        {
            var listado = new List<Articulos>();
            using (HttpClient cliente = new HttpClient())
            {
                var respuesta = await cliente.GetAsync("https://localhost:7296/api/ArticulosAPI/GetArticulos/" + filtro);
                string respuestaAPI = await respuesta.Content.ReadAsStringAsync();
                listado = JsonConvert.DeserializeObject<List<Articulos>>(respuestaAPI);
            }
            ViewBag.Filtro = filtro;
            return View(listado);
        }

        // GET: ArticulosController/Details/5
        public async Task<ActionResult> DetailsArticulos(string id)
        {
            Articulos? obj = new Articulos();
            using (var cliente = new HttpClient())
            {
                var respuesta = await cliente.GetAsync("https://localhost:7296/api/ArticulosAPI/GetArticulo/" + id);
                string respuestaAPI = await respuesta.Content.ReadAsStringAsync();
                obj = JsonConvert.DeserializeObject<Articulos>(respuestaAPI);
            }
            return View(obj);
        }

        // GET: ArticulosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticulosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticulosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticulosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticulosController/Delete/5
        public async Task<ActionResult> DeleteArticulos(string id)
        {
            Articulos? obj = new Articulos();
            using (var cliente = new HttpClient())
            {
                var respuesta = await cliente.GetAsync("https://localhost:7296/api/ArticulosAPI/GetArticulo/" + id);
                string respuestaAPI = await respuesta.Content.ReadAsStringAsync();
                obj = JsonConvert.DeserializeObject<Articulos>(respuestaAPI);

                ViewBag.CodigoArticulo = id;
            }
            return View(obj);
        }

        // POST: ArticulosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteArticulos(string id, IFormCollection collection)
        {
           using (var cliente = new HttpClient())
            {
                var respuesta = await cliente.DeleteAsync("https://localhost:7296/api/ArticulosAPI/DardeBaja/" + id);
                string respuestaAPI = await respuesta.Content.ReadAsStringAsync();
                ViewBag.MENSAJE = respuestaAPI;
            }
            return View();
        }
    }
}
