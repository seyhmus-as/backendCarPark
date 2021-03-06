using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IPriceService
	{
		IResult Add(Price price);
		IResult Delete(int minute);
		IResult Update(Price price);
		IDataResult<List<Price>> GetAll();
		IDataResult<Price> GetById(int MinuteBegin);
	}
}
