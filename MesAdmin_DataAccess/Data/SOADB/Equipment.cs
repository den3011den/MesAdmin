using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_DataAccess.Data.SOADB
{
    [Table("Equipment", Schema = "dbo")]
    public class Equipment
    {
        [Key]
        public Guid EquipmentId { get; set; }

        public string? S95Id { get; set; }

        public string? Description { get; set; }

        public string? Type { get; set; }

        public long? Version { get; set; }

        public Guid? ParentEquipmentId { get; set; }
        
        [ForeignKey("ParentEquipmentId")]
        [NotMapped]
        public virtual Equipment? ParentEquipment { get; set; }
    }
}
