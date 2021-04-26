using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class Price:IEntity
	{
		public int Id { get; set; }
		public int MinuteBegin{ get; set; }
		public int MinuteFinal { get; set; }
		public int PriceOfPark{ get; set; }
	}
}
