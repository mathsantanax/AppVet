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
        public void CadastrarPetETutor(Tutor tutor);
        public void CadastrarServico(Service service);
        public void CadastrarRaca(Raca raca);
        Task<List<Tutor>> ListarPetETutor();
        Task<List<Raca>> ListarRaca();
        List<Service> ListarServico();
        List<PetServico> ListarServicoPet();
    }
}
