using MesAdmin_Models.ResourceManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_Business.Repository.IRepository
{
    public interface IEquipmentRepository
    {                 
        public Task<EquipmentDTO> Get(Guid EquipmentId);
        public Task<IEnumerable<EquipmentDTO>> GetAll();

    }
}
