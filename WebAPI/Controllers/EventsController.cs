using Business.Abstract;
using Business.Constant;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        IItalianEventService _italianEventService;
        ITurkishEventService _turkishEventService;

        public EventsController(IItalianEventService italianEventService, ITurkishEventService turkishEventService)
        {
            _italianEventService = italianEventService;
            _turkishEventService = turkishEventService;
        }

        [HttpGet("getevents")]
        public IActionResult GetEvents()
        {
            IPAddress remoteIpAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4();

            if (remoteIpAddress.ToString() == "::1" || remoteIpAddress.ToString() == "127.0.0.1" || remoteIpAddress.ToString() == "0.0.0.1")
            {
                return Ok(Messages.LocalIpInformation);
            }

            var clientIp = IpDataAPIHelper.RunApi(remoteIpAddress.ToString());
            if (clientIp.country_name == "Italy")
            {
                var italianResult = _italianEventService.ReadJson();
                if (italianResult.Success)
                {
                    return Ok(italianResult);
                }
                return BadRequest(italianResult);
            }

            var result = _turkishEventService.ReadJson();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
