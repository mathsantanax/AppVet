﻿using AppVet.DTO;
using AppVet.Interface;
using AppVet.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.Models
{
    class ServicoModel : IService
    {
        private readonly Data _data;

        public ServicoModel()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appvet.db3");
            _data = new Data(dbPath);

        }
        public async void CadastrarTutor(Tutor tutor)
        {
            await _data.SaveTutor(tutor);
        }
        public async void CadastrarPet(Pet pet)
        {
            await _data.SavePet(pet);
        }

        public async void CadastrarRaca(Raca raca)
        {
            await _data.SaveRaca(raca);
        }

        public void CadastrarServico(Service service)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tutor>> ListarTutor()
        {
            return await _data.ListarTutor();
        }

        public async Task<List<Raca>> ListarRaca()
        {
            return await _data.ListarRaca();
        }

        public List<Service> ListarServico()
        {
            throw new NotImplementedException();
        }

        public List<PetServico> ListarServicoPet()
        {
            throw new NotImplementedException();
        }

        public async Task<Pet> SelectPet(int id)
        {
            return await _data.SelectPet(id);
        }

        public async Task<Raca> SelectRaca(int id)
        {
            return await _data.SelectRaca(id);
        }

        public async Task<List<Pet>> ListarPet()
        {
            return await _data.ListarPet();
        }

        public async Task<Pet> SelectedPet(Pet pet)
        {
            return await _data.SelectedPet(pet);
        }

    }
}
