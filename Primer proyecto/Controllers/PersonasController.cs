using Primer_proyecto.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Primer_proyecto.Controllers
{
    public class PersonasController
    {
        private readonly DatabaseServices _databaseServices;

        public PersonasController()
        {
            _databaseServices = new DatabaseServices();
        }
        public async Task GuardarPerson(Models.Personas personas)
        {
            await _databaseServices.InsertPersona(personas);
        }
        public async Task<List<Models.Personas>> ObtenerPersonas()
        {
            return await _databaseServices.ObtenerListaPersonas();
    
        }

        public async Task ActualizarPersona(Models.Personas personas)
        {
            await _databaseServices.UpdatePersona(personas);
        }

        public async Task EliminarPersona(Models.Personas personas)
        {
            await _databaseServices.DeletePersona(personas);
        }
    }
}