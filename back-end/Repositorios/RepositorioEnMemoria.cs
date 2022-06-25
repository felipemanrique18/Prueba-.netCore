using back_end.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Repositorios
{
    public class RepositorioEnMemoria : IRepositorio
    {

        private List<Genero> _generos;

        public RepositorioEnMemoria()
        {
            _generos = new List<Genero>()
            {
                new Genero(){Id = 1, Nombre = "Comedia"},
                new Genero(){Id = 2, Nombre = "Accion"},

            };

            _guid = Guid.NewGuid(); // identificador aleatorio
        }

        public List<Genero> ObtenerTodosLosGeneros()
        {
            return _generos;
        }

        public Guid _guid;

        public async Task<Genero> ObtenerPorId(int Id)
        {
            await Task.Delay(1);
            return _generos.FirstOrDefault(x => x.Id == Id);
        }

        public void CrearGenero(Genero genero)
        {
            genero.Id = _generos.Count() + 1;
            _generos.Add(genero);
        }
        public Guid obtenerGuid()
        {
            return _guid;
        }
    }
}
