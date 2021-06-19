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
    public class ItalianEventsController : ControllerBase
    {
        IItalianEventService _italianEventService;

        public ItalianEventsController(IItalianEventService italianEventService)
        {
            _italianEventService = italianEventService;
        }

        [HttpPost("add")]
        public IActionResult Add(ItalianEvent italianEvent)
        {
            var result = _italianEventService.Add(italianEvent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ItalianEvent italianEvent)
        {
            var result = _italianEventService.Delete(italianEvent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updated")]
        public IActionResult Update(ItalianEvent italianEvent)
        {
            var result = _italianEventService.Update(italianEvent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _italianEventService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbycategory")]
        public IActionResult GetAllByCategory(string categoryName)
        {
            var result = _italianEventService.GetAllByCategory(categoryName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbytime")]
        public IActionResult GetAllByTime(string time)
        {
            var result = _italianEventService.GetAllByTime(time);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _italianEventService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("readjson")]
        public IActionResult ReadJson()
        {
            var result = _italianEventService.ReadJson();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("addingdatainjson")]
        public IActionResult AddingDataInJson()
        {
            var result = _italianEventService.AddingDataInJson();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("removingdatainjson")]
        public IActionResult RemovingDataInJson()
        {
            var result = _italianEventService.RemovingDataInJson();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("updatingdatainjson")]
        public IActionResult UpdatingDataJson()
        {
            var result = _italianEventService.UpdatingDataJson();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
