using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_Models.ResourceManagementModels
{
    public class ProcessResourcesVMDTO
    {
        public ProcessResourcesDTO ProcessResources { get; set; }
        public string EquipmentsString { get; set; }
        public IEnumerable<EquipmentDTO> Equipments { get; set; }
    }
}
