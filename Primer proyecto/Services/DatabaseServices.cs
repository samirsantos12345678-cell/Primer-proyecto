using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Linq;
using Primer_proyecto.Models;


namespace Primer_proyecto.Services
{
    public class DatabaseServices
    {
        private SQLiteAsyncConnection _connection;

        public async Task Init ()
        {
            if (_connection != null)
            {
                return;

            }
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "DBPersonas.db3");
            _connection = new SQLiteAsyncConnection(dbPath);

            await _connection.CreateTableAsync<Personas>();

        }
        //Crud 
        public async Task<int> InsertPersona(Models.Personas personas)
        {
            await Init();
            return await _connection.InsertAsync(personas);
        }

        public async Task<List<Models.Personas>> ObtenerListaPersonas()
        {
            await Init();
            return await _connection.Table<Models.Personas>().ToListAsync();
        }

        public async Task<int> UpdatePersona(Models.Personas personas)
        {
            await Init();
            return await _connection.UpdateAsync(personas);
        }

        public async Task<int> DeletePersona(Models.Personas personas)
        {
            await Init();
            return await _connection.DeleteAsync(personas);
        }
    }
}
