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
	public class ParkHistoriesController : ControllerBase
	{
		IParkHistoryService _parkHistoryService;

		public ParkHistoriesController(IParkHistoryService parkHistoryService)
		{
			_parkHistoryService = parkHistoryService;
		}
		[HttpPost("add")]
		public IActionResult Add(ParkHistory parkHistory)
		{
			var result = _parkHistoryService.Add(parkHistory);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("update")]
		public IActionResult Update(ParkHistory parkHistory)
		{
			var result = _parkHistoryService.Update(parkHistory);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("delete")]
		public IActionResult Delete(int id)
		{
			var result = _parkHistoryService.Delete(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _parkHistoryService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getbyid")]
		public IActionResult GetById(int carId)
		{
			var result = _parkHistoryService.GetById(carId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
