using Business.Abstract;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GlobalEventManager : IGlobalEventService
    {
        IItalianEventService _italianEventService;
        ITurkishEventService _turkishEventService;

        public GlobalEventManager(IItalianEventService talianEventService, ITurkishEventService turkishEventService)
        {
            _italianEventService = talianEventService;
            _turkishEventService = turkishEventService;
        }

        public IResult ReadJson()
        {
            return null;
        }
    }
}
