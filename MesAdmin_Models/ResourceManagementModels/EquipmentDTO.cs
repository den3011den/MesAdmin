using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_Models.ResourceManagementModels
{
    public class EquipmentDTO
    {
        [Display(Name = "Код оборудования")]        
        public Guid EquipmentId { get; set; }

        [Display(Name = "Наименование оборудования s95Id")]
        [StringLength(50, ErrorMessage = "Наименование не может быть больше 50 символов")]

        public string? S95Id { get; set; }
        [Display(Name = "Описание оборудования")]
        [StringLength(255, ErrorMessage = "Описание оборудования не может быть больше 255 символов")]

        public string? Description { get; set; }
        [Display(Name = "Тип")]
        [StringLength(255, ErrorMessage = "Тип не может быть больше 255 символов")]

        public string? Type { get; set; }
        [Display(Name = "Версия")]
        public long? Version { get; set; }

        [Display(Name = "Родитель")]
        public EquipmentDTO ParentEquipment { get; set; }
    }
}
