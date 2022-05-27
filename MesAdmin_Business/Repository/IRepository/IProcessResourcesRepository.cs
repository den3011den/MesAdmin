using MesAdmin_Models.ResourceManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_Business.Repository.IRepository
{
    public interface IProcessResourcesRepository
    {
        public Task<ProcessResourcesDTO> Create(ProcessResourcesDTO objDTO);
        public Task<ProcessResourcesDTO> Update(ProcessResourcesDTO objDTO);
        public Task<int> Delete(string InsideId, string ParentId);
        public Task<ProcessResourcesDTO> Get(string InsideId, string ParentId);
        public Task<IEnumerable<ProcessResourcesDTO>> GetAll();
    }
}
