using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;
		ICustomerDal _customerDal;
		IParkHistoryDal _parkHistoryDal;
		IPriceDal _priceDal;
		public CarManager(ICarDal carDal, IParkHistoryDal parkHistoryDal, IPriceDal priceDal, ICustomerDal customerDal)
		{
			_carDal = carDal;
			_parkHistoryDal = parkHistoryDal;
			_customerDal = customerDal;
			_priceDal = priceDal;
		}
		[SecuredOperation("personnel,admin")]
		//[ValidationAspect(typeof(ProductValidator))]
		public IResult Add(Car car)
		{
			_carDal.Add(car);
			DateTime myDateTime = DateTime.Now;

			_parkHistoryDal.Add(new ParkHistory()
			{
				CarId = car.Id,
				EntryTime = myDateTime,
			});
			return new SuccessResult(Messages.CarAdded);
		}
		[SecuredOperation("personnel,admin")]
		public IResult TakeOut(int carId)
		{
			var takeOutPark = _parkHistoryDal.Get(p => p.CarId == carId);
			DateTime TimeNow = DateTime.Now;
			int duration = Math.Abs(TimeNow.Second - takeOutPark.EntryTime.Value.Second);
			int priceOfPark = CalculatePrice(duration, takeOutPark.CarId).Data;

			_parkHistoryDal.Update(new ParkHistory()
			{
				Id = takeOutPark.Id,
				Price = priceOfPark,
				CarId = takeOutPark.CarId,
				EntryTime = takeOutPark.EntryTime,
				ExitTime = TimeNow,
			});
			return new SuccessResult(Messages.CarTakeOut);
		}
		[SecuredOperation("personnel,admin")]
		public IResult Delete(int carId)
		{
			_carDal.Delete(_carDal.Get(p => p.Id == carId));
			return new SuccessResult(Messages.CarDeleted);
		}
		[SecuredOperation("personnel,admin")]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdate);
		}
		[SecuredOperation("personnel,admin")]
		[CacheAspect]
		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
		}
		[SecuredOperation("personnel,admin")]
		[CacheAspect]
		public IDataResult<Car> GetById(int carId)
		{
			return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == carId));
		}
		[SecuredOperation("personnel,admin")]
		[CacheAspect]
		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
		}
		public IDataResult<int> CalculatePrice(int duration, int carId)
		{
			var customerDetail = _customerDal.GetCustomerDetails().FirstOrDefault(p => p.CarId == carId);
			if (customerDetail != null)
			{
				return new SuccessDataResult<int>(999, Messages.AbonnementPriceCalculated);
			}
			else
			{
				Price calculatedPrice = _priceDal.Get(p => p.MinuteFinal > duration && p.MinuteBegin < duration);
				return new SuccessDataResult<int>(calculatedPrice.PriceOfPark, Messages.PriceCalculated);
			}
		}
	}
}
