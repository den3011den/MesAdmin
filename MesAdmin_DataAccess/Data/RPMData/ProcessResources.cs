using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_DataAccess.Data.RPMData
{

	[Table("ProcessResources", Schema = "dbo")]
	public class ProcessResources
    {
        [Key, Column(Order = 0)]
		public string InsideId { get; set; }

		[Key, Column(Order = 1)]
		public string ParentId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
		public bool IsStorage { get; set; }

		[Required]
		public string ResourceName { get; set; }

		[Required]
		public string EquipmentsData { get; set; }

		public string? Department { get; set; }

		public bool IsProduction { get; set; }

	}

}
