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
        public void CadastrarPetETutor(Pet pet);
        public void CadastrarServico(Pet pet);
        List<Pet> ListarPetETutor();
        List<Service> ListarServico();
        List<PetServico> ListarServicoPet();
    }
}
