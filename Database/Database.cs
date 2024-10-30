using AppVet.DTO;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.Database
{
    class Data
    {
        private readonly SQLiteAsyncConnection _database;

        public Data(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            try
            {
                _database.CreateTableAsync<Raca>().Wait();
                _database.CreateTableAsync<Tutor>().Wait();
                _database.CreateTableAsync<Pet>().Wait();
                _database.CreateTableAsync<Service>().Wait();
                _database.CreateTableAsync<PetServico>().Wait();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<List<Tutor>> ListarTutor()
        {
            return await _database.Table<Tutor>().ToListAsync();
        }

        public Task<List<Raca>> ListarRaca()
        {
            return _database.Table<Raca>().ToListAsync();
        }

        public Task<int> SaveTutor(Tutor tutor)
        {
            return _database.InsertAsync(tutor);
        }        
        public Task<int> SavePet(Pet pet)
        {
            return _database.InsertAsync(pet);
        }
        public Task<int> SaveRaca(Raca raca)
        {
            return _database.InsertAsync(raca);
        }
        
        
    }
}
