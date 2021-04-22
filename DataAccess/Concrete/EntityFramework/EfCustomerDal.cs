using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarParkContext>, ICustomerDal
	{
		public List<CustomerDetailDto> GetCustomerDetails()
		{
			using (CarParkContext context = new CarParkContext())
			{
				var result = from c in context.Customers
							 join p in context.Cars
							 on c.Id equals p.CustomerId
							 select new CustomerDetailDto
							 {
								 CustomerId = c.Id,
								 FirstName = c.FirstName,
								 LastName = c.LastName,
								 AbonnementBegin = c.AbonnementBeginTime,
								 AbonnementFinal = c.AbonnementFinalTime,

								 Brand = p.Brand,
								 CarId = p.Id,
								 LicensePlate = p.LicensePlate

							 };
				return result.ToList();
			}
		}
	}
}
