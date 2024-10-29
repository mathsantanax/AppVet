using AppVet.DTO;
using AppVet.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVet.Models
{
    class ServicoModel : IService
    {
        public void CadastrarPetETutor(Pet pet)
        {
            
        }

        public void CadastrarServico(Pet pet)
        {
            throw new NotImplementedException();
        }

        public List<Pet> ListarPetETutor()
        {
            throw new NotImplementedException();
        }

        public List<Service> ListarServico()
        {
            throw new NotImplementedException();
        }

        public List<PetServico> ListarServicoPet()
        {
            throw new NotImplementedException();
        }
    }
}
