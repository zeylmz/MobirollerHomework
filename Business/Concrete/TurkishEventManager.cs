using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace Business.Concrete
{
    public class TurkishEventManager : ITurkishEventService
    {
        string url = "https://s3.us-west-2.amazonaws.com/secure.notion-static.com/c86e0795-cfbb-42b9-8164-739f72ebf585/3455dde5.json?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAT73L2G45O3KS52Y5%2F20210618%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20210618T103100Z&X-Amz-Expires=86400&X-Amz-Signature=241cdfe2b90d06d6e76bcb2396391ee78b59a0e107621ea5a990434c560aef93&X-Amz-SignedHeaders=host&response-content-disposition=filename%20%3D\"3455dde5.json\"";
        ITurkishEventDal _turkishEventDal;

        public TurkishEventManager(ITurkishEventDal turkishEventDal)
        {
            _turkishEventDal = turkishEventDal;
        }

        public IResult Add(TurkishEvent turkishEvent)
        {
            _turkishEventDal.Add(turkishEvent);
            return new SuccessResult(Messages.AddedDataSuccessful);
        }

        public IResult Update(TurkishEvent turkishEvent)
        {
            _turkishEventDal.Delete(turkishEvent);
            return new SuccessResult(Messages.DeletedDataSuccessful);
        }

        public IResult Delete(TurkishEvent turkishEvent)
        {
            _turkishEventDal.Delete(turkishEvent);
            return new SuccessResult(Messages.DeletedDataSuccessful);
        }

        public IDataResult<List<TurkishEvent>> GetAll()
        {
            return new SuccessDataResult<List<TurkishEvent>>(_turkishEventDal.GetAll(), Messages.ListingFromDatabaseSuccessful);
        }

        public IDataResult<List<TurkishEvent>> GetAllByCategory(string categoryName)
        {
            return new SuccessDataResult<List<TurkishEvent>>(_turkishEventDal.GetAll(e => e.dc_Kategori == categoryName), Messages.ListingFromDatabaseSuccessful);
        }

        public IDataResult<List<TurkishEvent>> GetAllByTime(string time)
        {
            return new SuccessDataResult<List<TurkishEvent>>(_turkishEventDal.GetAll(e => e.dc_Zaman == time), Messages.ListingFromDatabaseSuccessful);
        }

        public IDataResult<TurkishEvent> GetById(int id)
        {
            return new SuccessDataResult<TurkishEvent>(_turkishEventDal.Get(e => e.ID == id), Messages.ListingFromDatabaseSuccessful);
        }

        public IDataResult<List<TurkishEvent>> ReadJson()
        {
            using (var webClient = new WebClient())
            {
                string jsonData = webClient.DownloadString(url);
                List<TurkishEvent> turkishEvents = JsonConvert.DeserializeObject<List<TurkishEvent>>(jsonData);
                return new SuccessDataResult<List<TurkishEvent>>(turkishEvents,Messages.ListingFromSourceSuccessful);
            }
        }

        public IResult AddRange()
        {
            using (var webClient = new WebClient())
            {
                string jsonData = webClient.DownloadString(url);
                List<TurkishEvent> turkishEvents = JsonConvert.DeserializeObject<List<TurkishEvent>>(jsonData);
                _turkishEventDal.AddRange(turkishEvents);
            }
            return new SuccessResult(Messages.AddedDataInTurkishSuccessful);
        }
    }
}
