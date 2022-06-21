using AutoMapper;
using MesAdmin_Business.Repository.IRepository;
using MesAdmin_DataAccess.Data.RPMData;
using MesAdmin_Models.ResourceManagementModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_Business.Repository
{
    public class ProcessResourcesRepository : IProcessResourcesRepository
    {

        private readonly RPMDataАpplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProcessResourcesRepository(RPMDataАpplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProcessResourcesDTO> Create(ProcessResourcesDTO objDTO)
        {
            var obj = _mapper.Map<ProcessResourcesDTO, ProcessResources>(objDTO);
            var addedObj = _db.ProcessResourcesDbSet.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<ProcessResources, ProcessResourcesDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(string InsideId, string ParentId)
        {
            var obj = await _db.ProcessResourcesDbSet.FirstOrDefaultAsync(u => ((u.InsideId.ToLower() == InsideId.ToLower()) && (u.ParentId.ToLower() == ParentId.ToLower())));
            if (obj != null)
            {
                _db.ProcessResourcesDbSet.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ProcessResourcesDTO> Get(string InsideId, string ParentId)
        {
            var obj = await _db.ProcessResourcesDbSet.FirstOrDefaultAsync(u => ((u.InsideId.ToLower() == InsideId.ToLower()) && (u.ParentId.ToLower() == ParentId.ToLower())));
            if (obj != null)
            {
                return _mapper.Map<ProcessResources, ProcessResourcesDTO>(obj);
            }
            return new ProcessResourcesDTO();
        }

        public async Task<IEnumerable<ProcessResourcesDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProcessResources>, IEnumerable<ProcessResourcesDTO>>(_db.ProcessResourcesDbSet);
        }

        public async Task<ProcessResourcesDTO> Update(ProcessResourcesDTO objDTO, string oldParentId, string oldInsideId)
        {
            var objDromDb = await _db.ProcessResourcesDbSet.FirstOrDefaultAsync(u => ((u.InsideId.ToLower() == oldInsideId.ToLower()) && (u.ParentId.ToLower() == oldParentId.ToLower())));
            
            if (objDromDb != null)
            {

                if (objDromDb.ParentId != objDTO.ParentId || objDromDb.InsideId != objDTO.InsideId)
                {
                    _db.ProcessResourcesDbSet.Remove(objDromDb);
                    _db.SaveChanges();
                    var newObj = _mapper.Map<ProcessResourcesDTO, ProcessResources>(objDTO);
                    _db.ProcessResourcesDbSet.Add(newObj);
                    _db.SaveChanges();
                    return objDTO;
                }
                else
                {
                    objDromDb.InsideId = objDTO.InsideId;
                    objDromDb.ParentId = objDTO.ParentId;
                    objDromDb.Description = objDTO.Description;
                    objDromDb.IsStorage = objDTO.IsStorage;
                    objDromDb.ResourceName = objDTO.ResourceName;
                    objDromDb.EquipmentsData = objDTO.EquipmentsData;
                    objDromDb.Department = objDTO.Department;
                    objDromDb.IsProduction = objDTO.IsProduction;
                    _db.ProcessResourcesDbSet.Update(objDromDb);
                    _db.SaveChanges();
                    return _mapper.Map<ProcessResources, ProcessResourcesDTO>(objDromDb);
                }                                                 
            }
            return objDTO;
        }
    }
}
