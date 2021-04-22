using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class Car:IEntity
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public string LicensePlate { get; set; }
		public string Brand{ get; set; }
	}
}
