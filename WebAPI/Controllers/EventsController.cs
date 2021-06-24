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
            string ip = remoteIpAddress.ToString();

            if (ip == "::1" || ip == "127.0.0.1" || ip == "0.0.0.1")
            {
                return BadRequest(Messages.LocalIpInformation);
            }

            var localization = FindIpLocalization.RequestLocalization(ip);
            if (localization == "Italy")
            {
                var italianResult = _italianEventService.ReadJson();
                if (italianResult.Success)
                {
                    return Ok(italianResult);
                }
                return BadRequest(italianResult);
            }

            var turkishResult = _turkishEventService.ReadJson();
            if (turkishResult.Success)
            {
                return Ok(turkishResult);
            }
            return BadRequest(turkishResult);
        }
    }
}
