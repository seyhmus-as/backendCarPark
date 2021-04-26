using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class ParkHistory:IEntity
	{
		public int Id { get; set; }
		public int CarId { get; set; }
		public DateTime? EntryTime { get; set; }
		public DateTime? ExitTime { get; set; }
		public int Price { get; set; }
	}
}