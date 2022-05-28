using MesAdmin_Models.ResourceManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_Business.Repository.IRepository
{
    public interface IProcessResourcesVMRepository
    {                 
        public Task<ProcessResourcesVMDTO> Get(string ParentId, string InsideId);

        public Task<IEnumerable<ProcessResourcesVMDTO>> GetAll();

        public Task<ProcessResourcesVMDTO> Create(ProcessResourcesVMDTO objDTO);

        public Task<int> Delete(string ParentId, string InsideId);

        public Task<ProcessResourcesDTO> UpdateResource(ProcessResourcesDTO objDTO);

        public Task<ProcessResourcesVMDTO> AddEquipment(string ParentId, string InsideId, Guid EquipGuid);

        public Task<ProcessResourcesVMDTO> DeleteEquipment(string ParentId, string InsideId, Guid EquipGuid);

    }
}
