using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TurkishEventManager : ITurkishEventService
    {
        string url = "https://s3.us-west-2.amazonaws.com/secure.notion-static.com/c86e0795-cfbb-42b9-8164-739f72ebf585/3455dde5.json?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAT73L2G45O3KS52Y5%2F20210620%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20210620T222552Z&X-Amz-Expires=86400&X-Amz-Signature=e106795240ac7a61839e88f4f38a1b7e0cdd4206791b7645ea672b4e7d0d42c7&X-Amz-SignedHeaders=host&response-content-disposition=filename%20%3D\"3455dde5.json\"";
        ITurkishEventDal _turkishEventDal;

        public TurkishEventManager(ITurkishEventDal turkishEventDal)
        {
            _turkishEventDal = turkishEventDal;
        }

        [ValidationAspect(typeof(TurkishEventValidator))]
        public IResult Add(TurkishEvent turkishEvent)
        {
            IResult result = BusinessRules.Run
                (      
                    DataCountExceeded()
                );

            if (result != null)
            {
                return result;
            }

            _turkishEventDal.Add(turkishEvent);
            return new SuccessResult(Messages.AddedDataFromDatabaseSuccessfull);
        }        

        [ValidationAspect(typeof(TurkishEventValidator))]
        public IResult Update(TurkishEvent turkishEvent)
        {
            _turkishEventDal.Update(turkishEvent);
            return new SuccessResult(Messages.UpdatedDataFromDatabaseSuccessful);
        }

        public IResult Delete(TurkishEvent turkishEvent)
        {
            _turkishEventDal.Delete(turkishEvent);
            return new SuccessResult(Messages.DeletedDataFromDatabaseSuccessfull);
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
                List<TurkishEvent> turkishEvent = JsonHelper<TurkishEvent>.LoadJson(url);
                return new SuccessDataResult<List<TurkishEvent>>(turkishEvent,Messages.ListingFromSourceSuccessful);
        }

        public IResult AddingDataInJson()
        {
            List<TurkishEvent> turkishEvent = JsonHelper<TurkishEvent>.LoadJson(url);
            _turkishEventDal.AddRange(turkishEvent);
            return new SuccessResult(Messages.AddedDataFromSourceSuccessfull);
        }

        public IResult RemovingDataInJson()
        {
            List<TurkishEvent> turkishEvent = JsonHelper<TurkishEvent>.LoadJson(url);
            _turkishEventDal.RemoveRange(turkishEvent);
            return new SuccessResult(Messages.DeletedDataFromSourceSuccessful);
        }

        public IResult UpdatingDataJson()
        {
            List<TurkishEvent> turkishEvent = JsonHelper<TurkishEvent>.LoadJson(url);
            _turkishEventDal.RemoveRange(turkishEvent);
            return new SuccessResult(Messages.UpdatedDataFromSourceSuccessful);
        }

        private IResult DataCountExceeded()
        {
            var result = _turkishEventDal.GetAll();
            if (result.Count > 20000)
            {
                return new ErrorResult(Messages.DataCountExceeded);
            }
            return new SuccessResult();
        }
    }
}
