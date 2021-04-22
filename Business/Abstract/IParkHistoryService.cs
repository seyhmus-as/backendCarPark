using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IParkHistoryService
	{
		IResult Add(ParkHistory parkHistory);
		IResult Delete(int id);
		IResult Update(ParkHistory parkHistory);
		IDataResult<List<ParkHistory>> GetAll();
		IDataResult<List<ParkHistory>> GetById(int carId);
	}
}
