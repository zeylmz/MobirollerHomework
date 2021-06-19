using Business.Abstract;
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

        [HttpGet("readjson")]
        public IActionResult ReadJson()
        {
            var result = _turkishEventService.ReadJson();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("addrange")]
        public IActionResult AddRange()
        {
            var result = _turkishEventService.AddRange();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
