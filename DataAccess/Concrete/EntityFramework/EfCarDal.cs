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
    public class EfCarDal : EfEntityRepositoryBase<Car, CarParkContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarParkContext context = new CarParkContext())
            {
                var result = from p in context.Cars
                             join c in context.Customers
                             on p.CustomerId equals c.Id
                             select new CarDetailDto
                             {
                                 Id = p.Id,
                                 Brand = p.Brand,
                                 FirstName = c.FirstName
                             };
                return result.ToList();
            }
        }
    }
}
