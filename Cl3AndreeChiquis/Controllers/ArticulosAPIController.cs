using Cl3AndreeChiquis.Dao;
using Cl3AndreeChiquis.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cl3AndreeChiquis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosAPIController : ControllerBase
    {

        private readonly ArticulosDAO dao_articulos;

        public ArticulosAPIController(ArticulosDAO _dao)
        {
            dao_articulos = _dao;
        }
        // GET: api/<ArticulosAPIController>
        [HttpGet("GetArticulos")]
        public List<Articulos> Get()
        {
            return dao_articulos.ListarArticulos();
        }

        [HttpGet("GetArticulos/{filtro}")]
        public async Task<List<Articulos>> GetArticulos(string filtro)
        {
            var resultado = await Task.Run( () => dao_articulos.ListArticulosfiltro(filtro));
            return resultado;
        }

        // GET api/<ArticulosAPIController>/5
        [HttpGet("GetArticulo/{id}")]
        public Articulos Get(string id)
        {
            Articulos? obj = dao_articulos.ListarArticulos()
                .Find(m => m.cod_art.Equals(id));
            return obj;
        }

        // POST api/<ArticulosAPIController>
        [HttpDelete("DardeBaja/{id}")]
        public string Delete(string id)
        {
            string mensaje = dao_articulos.DardeBaja(id);
            return mensaje;
        }

        /*// PUT api/<ArticulosAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticulosAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
