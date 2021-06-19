using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
    public class TurkishEventsController : ControllerBase
    {
        ITurkishEventService _turkishEventService;

        public TurkishEventsController(ITurkishEventService turkishEventService)
        {
            _turkishEventService = turkishEventService;
        }

        [HttpPost("add")]        
        public IActionResult Add(TurkishEvent turkishEvent)
        {
            var result = _turkishEventService.Add(turkishEvent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]        
        public IActionResult Delete(TurkishEvent turkishEvent)
        {
            var result = _turkishEventService.Delete(turkishEvent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updated")]        
        public IActionResult Update(TurkishEvent turkishEvent)
        {
            var result = _turkishEventService.Update(turkishEvent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]        
        public IActionResult GetAll()
        {
            var result = _turkishEventService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbycategory")]        
        public IActionResult GetAllByCategory(string categoryName)
        {
            var result = _turkishEventService.GetAllByCategory(categoryName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbytime")]        
        public IActionResult GetAllByTime(string time)
        {
            var result = _turkishEventService.GetAllByTime(time);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]        
        public IActionResult GetById(int id)
        {
            var result = _turkishEventService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("readjson")]        
        public IActionResult ReadJson()
        {
            var result = _turkishEventService.ReadJson();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("addingdatainjson")]        
        public IActionResult AddingDataInJson()
        {
            var result = _turkishEventService.AddingDataInJson();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("removingdatainjson")]        
        public IActionResult RemovingDataInJson()
        {
            var result = _turkishEventService.RemovingDataInJson();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("updatingdatainjson")]        
        public IActionResult UpdatingDataJson()
        {
            var result = _turkishEventService.UpdatingDataJson();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
