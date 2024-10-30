using AppVet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.Interface
{
    interface IService
    {
        public void CadastrarTutor(Tutor tutor);
        public void CadastrarPet(Pet pet);
        public void CadastrarServico(Service service);
        public void CadastrarRaca(Raca raca);
        Task<Pet> SelectPet(int id);
        Task<Pet> SelectedPet(Pet pet);
        Task<Raca> SelectRaca(int id);
        Task<List<Tutor>> ListarTutor();
        Task<List<Pet>> ListarPet();
        Task<List<Raca>> ListarRaca();
        List<Service> ListarServico();
        List<PetServico> ListarServicoPet();
    }
}
