using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PricesController : ControllerBase
	{
		IPriceService _priceService;

		public PricesController(IPriceService pricesService)
		{
			_priceService = pricesService;
		}
		[HttpPost("add")]
		public IActionResult Add(Price price)
		{
			var result = _priceService.Add(price);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("update")]
		public IActionResult Update(Price price)
		{
			var result = _priceService.Update(price);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("delete")]
		public IActionResult Delete(int id)
		{
			var result = _priceService.Delete(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _priceService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _priceService.GetById(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
