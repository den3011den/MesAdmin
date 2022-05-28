using AutoMapper;
using MesAdmin_Business.Repository.IRepository;
using MesAdmin_Common;
using MesAdmin_DataAccess.Data.RPMData;
using MesAdmin_DataAccess.Data.RPMData.ViewModel;
using MesAdmin_DataAccess.Data.SOADB;
using MesAdmin_Models.ResourceManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_Business.Repository
{
    public class ProcessResourcesVMRepository : IProcessResourcesVMRepository
    {

        private readonly SOADBApplicationDbContext _dbSAODB;
        private readonly RPMDataАpplicationDbContext _dbRPMData;
        private readonly IMapper _mapper;

        public ProcessResourcesVMRepository(SOADBApplicationDbContext dbSAODB, RPMDataАpplicationDbContext dbRPMData, IMapper mapper)
        {
            _dbSAODB = dbSAODB;
            _dbRPMData = dbRPMData;
            _mapper = mapper;
        }


        public async Task<ProcessResourcesVMDTO> AddEquipment(string ParentId, string InsideId, Guid EquipGuid)
        {
            throw new NotImplementedException();
        }

        public async Task<ProcessResourcesVMDTO> Create(ProcessResourcesVMDTO objDTO)
        {
            try
            {
                var obj = _mapper.Map<ProcessResourcesVMDTO, ProcessResourcesVM>(objDTO);
                _dbRPMData.ProcessResourcesDbSet.Add(obj.ProcessResources);                 
                await _dbRPMData.SaveChangesAsync();

                return new ProcessResourcesVMDTO()
                {
                    ProcessResources = _mapper.Map<ProcessResources, ProcessResourcesDTO>(obj.ProcessResources),
                    EquipmentsString = "",
                    Equipments = _mapper.Map<IEnumerable<Equipment>, IEnumerable<EquipmentDTO>>(obj.Equipments).ToList()
                };                
            }
            catch (Exception ex)
            {
                return new ProcessResourcesVMDTO();
            }            
        }

        public async Task<int> Delete(string ParentId, string InsideId)
        {
            var objProcessResourceFromDb = _dbRPMData.ProcessResourcesDbSet.FirstOrDefault(u => (u.ParentId == ParentId && u.InsideId == InsideId));                                 
            if (objProcessResourceFromDb != null)
            {
                _dbRPMData.ProcessResourcesDbSet.Remove(objProcessResourceFromDb);                
                return await _dbRPMData.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ProcessResourcesVMDTO> DeleteEquipment(string ParentId, string InsideId, Guid EquipGuid)
        {
            throw new NotImplementedException();
        }

        public async Task<ProcessResourcesVMDTO> Get(string ParentId, string InsideId)
        {

            ProcessResourcesVM processResourcesVM = new();

            ProcessResources processResourcesFromDb = _dbRPMData.ProcessResourcesDbSet.FirstOrDefault(u => (u.ParentId == ParentId) && (u.InsideId == InsideId));
            if (processResourcesFromDb == null)
            {
                return new ProcessResourcesVMDTO();
            }

            processResourcesVM.ProcessResources = processResourcesFromDb;

            if (!String.IsNullOrEmpty(processResourcesFromDb.EquipmentsData))
            {
                string tempString = processResourcesFromDb.EquipmentsData;

                List<Guid> EquipmentsData = SD.GetEquipmentListFromEquipmentsDataString(tempString);

                List<Equipment> equipmentListFromDb = new();

                foreach(var guid in EquipmentsData)
                {
                    Equipment equipmentFromDb = _dbSAODB.EquipmentDbSet.FirstOrDefault(u => u.EquipmentId == guid);
                    if (equipmentFromDb != null)
                    {
                        equipmentListFromDb.Add(equipmentFromDb);
                        processResourcesVM.EquipmentsString = processResourcesVM.EquipmentsString +  (String.IsNullOrEmpty(equipmentFromDb.S95Id) ? "" : String.IsNullOrEmpty(equipmentFromDb.S95Id)) + Environment.NewLine; 
                    }
                }
                processResourcesVM.Equipments = equipmentListFromDb;
            }
            
            if (processResourcesVM != null)
            {
                return _mapper.Map<ProcessResourcesVM, ProcessResourcesVMDTO>(processResourcesVM);
            } 

            return new ProcessResourcesVMDTO();
        }

        public async Task<IEnumerable<ProcessResourcesVMDTO>> GetAll()
        {
            List<ProcessResourcesVM> ProcessResourcesVMFromDb = new List<ProcessResourcesVM>();
            IEnumerable<ProcessResources> processResourcesList = _dbRPMData.ProcessResourcesDbSet;            

            foreach (ProcessResources processResources in processResourcesList)
            {
                ProcessResourcesVM processResourcesVM = new ProcessResourcesVM();

                processResourcesVM.ProcessResources = processResources;

                string tempString = processResources.EquipmentsData;

                List<Guid> EquipmentsDataList = SD.GetEquipmentListFromEquipmentsDataString(tempString);

                List<Equipment> equipmentListFromDb = new();

                foreach (var guid in EquipmentsDataList)
                {
                    Equipment equipmentFromDb = _dbSAODB.EquipmentDbSet.FirstOrDefault(u => u.EquipmentId == guid);
                    if (equipmentFromDb != null)
                    {
                        equipmentListFromDb.Add(equipmentFromDb);
                        processResourcesVM.EquipmentsString = processResourcesVM.EquipmentsString + (String.IsNullOrEmpty(equipmentFromDb.S95Id) ? "" : String.IsNullOrEmpty(equipmentFromDb.S95Id)) + Environment.NewLine;
                    }
                }
                processResourcesVM.Equipments = equipmentListFromDb;

                ProcessResourcesVMFromDb.Add(processResourcesVM);
            }             
            return _mapper.Map<IEnumerable<ProcessResourcesVM>, IEnumerable<ProcessResourcesVMDTO>>(ProcessResourcesVMFromDb);
        }

        public async Task<ProcessResourcesVMDTO> UpdateResource(ProcessResourcesDTO objDTO)
        {
            throw new NotImplementedException();
        }
    }
}
