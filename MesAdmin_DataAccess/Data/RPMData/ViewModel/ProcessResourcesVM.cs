using MesAdmin_DataAccess.Data.SOADB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_DataAccess.Data.RPMData.ViewModel
{
    public class ProcessResourcesVM
    {
        public ProcessResources ProcessResources { get; set; }
        public string EquipmentsString { get; set; }
        public IEnumerable<Equipment> Equipments { get; set; }
    }
}
