using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_Models.ResourceManagementModels
{
    public class ProcessResourcesDTO
    {
		[Required(ErrorMessage = "Код ресурса SAP не может быть пустым")]
		[Display(Name = "Код ресурса в SAP")]
		[StringLength(50, ErrorMessage = "Код ресурса SAP может быть от {1} до {2} символов", MinimumLength = 1)]
		public string InsideId { get; set; }

		[Required(ErrorMessage = "Код завода SAP не может быть пустым")]
		[Display(Name = "Код завода в SAP")]
		[StringLength(50, ErrorMessage = "Код завода SAP может быть от {1} до {2} символов", MinimumLength = 1)]
		public string ParentId { get; set; }

		[Display(Name = "Описание ресурса SAP")]
		[Required(ErrorMessage = "Описание ресурса SAP не может быть пустым")]
		public string Description { get; set; }

		[Display(Name = "Складской ресурс")]
		public bool IsStorage { get; set; }

		[Display(Name = "Наименование ресурса в SAP")]
		[Required(ErrorMessage = "Наименование ресурса SAP не может быть пустым")]
		[StringLength(50, ErrorMessage = "Наименование ресурса SAP может быть длинной от {1} до {2} символов", MinimumLength = 1)]
		public string ResourceName { get; set; }

		public string EquipmentsData { get; set; }

		public string Department { get; set; }

		[Display(Name = "Производственный ресурс")]
		public bool IsProduction { get; set; }

	}
}
