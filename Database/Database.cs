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
                //_database.DropTableAsync<Raca>().Wait();
                //_database.DropTableAsync<Tutor>().Wait();
                //_database.DropTableAsync<Pet>().Wait();
                //_database.DropTableAsync<Service>().Wait();
                //_database.DropTableAsync<PetServico>().Wait();

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

        public async Task<Pet> SelectPet(int petId)
        {
            return await _database.Table<Pet>().FirstOrDefaultAsync(p => p.Id == petId);
        }
        public async Task<Pet> SelectedPet(Pet pet)
        {
            return await _database.Table<Pet>().FirstOrDefaultAsync(p => p.nomePet == pet.nomePet && p.especie ==pet.especie && p.idade == pet.idade);
        }

        public async Task<List<Tutor>> ListarTutor()
        {
            return await _database.Table<Tutor>().ToListAsync();
        }
        public async Task<List<Pet>> ListarPet()
        {
            return await _database.Table<Pet>().ToListAsync();
        }

        public Task<List<Raca>> ListarRaca()
        {
            return _database.Table<Raca>().ToListAsync();
        }

        public async Task<int> SaveTutor(Tutor tutor)
        {
            return await _database.InsertAsync(tutor);
        }        
        public Task<int> SavePet(Pet pet)
        {
            return _database.InsertAsync(pet);
        }
        public Task<int> SaveRaca(Raca raca)
        {
            return _database.InsertAsync(raca);
        }
        public async Task<Raca> SelectRaca(int racaId)
        {
            return await _database.Table<Raca>().FirstOrDefaultAsync(p => p.Id == racaId);
        }
    }
}
