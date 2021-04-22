using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto : IDto
    {
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int CarId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string LicensePlate { get; set; }
		public string Brand { get; set; }
		public DateTime AbonnementBegin { get; set; }
		public DateTime AbonnementFinal { get; set; }


	}
}
