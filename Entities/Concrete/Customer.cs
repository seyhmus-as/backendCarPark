using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class Customer:IEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Price { get; set; }
		public DateTime AbonnementBeginTime { get; set; }
		public DateTime AbonnementFinalTime { get; set; }
	}
}
