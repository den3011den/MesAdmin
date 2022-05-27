using AutoMapper;
using MesAdmin_Business.Repository.IRepository;
using MesAdmin_DataAccess.Data.SOADB;
using MesAdmin_Models.ResourceManagementModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_Business.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {

        private readonly SOADBApplicationDbContext _db;
        private readonly IMapper _mapper;

        public EquipmentRepository(SOADBApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<EquipmentDTO> Get(Guid EquipmentId)
        {
            var obj = await _db.EquipmentDbSet.FirstOrDefaultAsync(u => (u.EquipmentId == EquipmentId));
            if (obj != null)
            {
                return _mapper.Map<Equipment, EquipmentDTO>(obj);
            }
            return new EquipmentDTO();

        }

        public async Task<IEnumerable<EquipmentDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Equipment>, IEnumerable<EquipmentDTO>>(_db.EquipmentDbSet);
        }
    }
}
