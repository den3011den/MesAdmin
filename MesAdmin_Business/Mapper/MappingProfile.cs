using AutoMapper;
using MesAdmin_DataAccess.Data.RPMData;
using MesAdmin_DataAccess.Data.SOADB;
using MesAdmin_Models.ResourceManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Equipment, EquipmentDTO>().ReverseMap();
            CreateMap<ProcessResources, ProcessResourcesDTO>().ReverseMap();
        }
    }
}
