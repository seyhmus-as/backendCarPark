using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class ParkHistoryManager : IParkHistoryService
	{
		IParkHistoryDal _parkHistoryDal;

		public ParkHistoryManager(IParkHistoryDal parkHistorydal)
		{
			_parkHistoryDal = parkHistorydal;
		}
		public IResult Add(ParkHistory parkHistorydal)
		{
			_parkHistoryDal.Add(parkHistorydal);
			return new SuccessResult(Messages.ParkHistoryAdded);
		}
		public IResult Delete(int id)
		{
			_parkHistoryDal.Delete(_parkHistoryDal.Get(p=>p.Id==id));
			return new SuccessResult(Messages.parkHistoryDeleted);
		}
		public IResult Update(ParkHistory parkHistory)
		{
			_parkHistoryDal.Update(parkHistory);
			return new SuccessResult(Messages.parkHistoryUpdate);
		}
		public IDataResult<List<ParkHistory>> GetAll()
		{
			return new SuccessDataResult<List<ParkHistory>>(_parkHistoryDal.GetAll(), Messages.ParkHistoryListed);
		}
		public IDataResult<List<ParkHistory>> GetById(int carId)
		{
			return new SuccessDataResult<List<ParkHistory>>(_parkHistoryDal.GetAll(p => p.CarId == carId));
		}
	}
}
