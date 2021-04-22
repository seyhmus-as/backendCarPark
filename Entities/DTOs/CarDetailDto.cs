using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
		public int Id { get; set; }
		public string LicensePlate { get; set; }
		public string Brand { get; set; }
		public DateTime EntryTime { get; set; }
		public DateTime ExitTime { get; set; }
		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

	}
}
