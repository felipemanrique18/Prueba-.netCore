using back_end.Entidades;
using back_end.Filtros;
using back_end.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace back_end.Controllers
{
    [Route("api/generos")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class GenerosController: ControllerBase
    {
        private readonly IRepositorio repositorio;
        private readonly ILogger<GenerosController> logger;

        public GenerosController(IRepositorio repositorio,
                                 ILogger<GenerosController> logger)
        {
            this.repositorio = repositorio;
            this.logger = logger;
        }

        [HttpGet] // api/generos
        [HttpGet("listado")] // api/generos/listado
        [HttpGet("/listado")] // /listado
        [ResponseCache(Duration = 60 )]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ServiceFilter(typeof(MiFiltroDeAccion))]
        public List<Genero> Get()
        {
            logger.LogInformation("Vamos a mostrar los generos");
            return repositorio.ObtenerTodosLosGeneros();
        }

        [HttpGet("guid")] // /api/generos/guid
        public ActionResult<Guid> GetGuid()
        {
            return repositorio.obtenerGuid();
        }

        [HttpGet("{Id:int}")]
        //[HttpGet("{Id:int/nombre=Roberto}")]  /// api/generos/2/felipe
        public async Task<ActionResult<Genero>> Get(int Id, [FromHeader] string nombre)
        {

            logger.LogDebug($"Obteniendo genero por el id {Id}");
            var genero = await repositorio.ObtenerPorId(Id);

            if(genero == null)
            {
                throw new ApplicationException($"El genero de iD {Id} no fue encontrado");
                logger.LogWarning($"No encontramos el genero {Id}");
                return NotFound();
            }
            return genero;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            repositorio.CrearGenero(genero);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            return NoContent();


        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();

        }
    }
}
