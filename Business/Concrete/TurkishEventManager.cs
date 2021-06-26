using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TurkishEventManager : ITurkishEventService
    {
        string url = "https://s3.us-west-2.amazonaws.com/secure.notion-static.com/c86e0795-cfbb-42b9-8164-739f72ebf585/3455dde5.json?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAT73L2G45O3KS52Y5%2F20210626%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20210626T090435Z&X-Amz-Expires=86400&X-Amz-Signature=c5eb176b51e53008cd9dfd9e305d39dc819d84c85cf9441815c8933766a5bca8&X-Amz-SignedHeaders=host&response-content-disposition=filename%20%3D\"3455dde5.json\"";
        ITurkishEventDal _turkishEventDal;

        public TurkishEventManager(ITurkishEventDal turkishEventDal)
        {
            _turkishEventDal = turkishEventDal;
        }

        [SecuredOperation("admin,data.add")]
        [ValidationAspect(typeof(TurkishEventValidator))]
        [CacheRemoveAspect("ITurkishEventService.Get")]
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

        [SecuredOperation("admin,data.add")]
        [ValidationAspect(typeof(TurkishEventValidator))]
        [CacheRemoveAspect("ITurkishEventService.Get")]
        public IResult Update(TurkishEvent turkishEvent)
        {
            _turkishEventDal.Update(turkishEvent);
            return new SuccessResult(Messages.UpdatedDataFromDatabaseSuccessful);
        }

        [CacheRemoveAspect("ITurkishEventService.Get")]
        public IResult Delete(TurkishEvent turkishEvent)
        {
            _turkishEventDal.Delete(turkishEvent);
            return new SuccessResult(Messages.DeletedDataFromDatabaseSuccessfull);
        }

        [CacheAspect]
        public IDataResult<List<TurkishEvent>> GetAll()
        {
            return new SuccessDataResult<List<TurkishEvent>>(_turkishEventDal.GetAll(), Messages.ListingFromDatabaseSuccessful);
        }

        [CacheAspect]
        public IDataResult<List<TurkishEvent>> GetAllByCategory(string categoryName)
        {
            return new SuccessDataResult<List<TurkishEvent>>(_turkishEventDal.GetAll(e => e.dc_Kategori == categoryName), Messages.ListingFromDatabaseSuccessful);
        }

        [CacheAspect]
        public IDataResult<List<TurkishEvent>> GetAllByTime(string time)
        {
            return new SuccessDataResult<List<TurkishEvent>>(_turkishEventDal.GetAll(e => e.dc_Zaman == time), Messages.ListingFromDatabaseSuccessful);
        }

        [CacheAspect]
        public IDataResult<TurkishEvent> GetById(int id)
        {
            return new SuccessDataResult<TurkishEvent>(_turkishEventDal.Get(e => e.ID == id), Messages.ListingFromDatabaseSuccessful);
        }

        [CacheAspect(5)]
        //[PerformanceAspect(4)]
        public IDataResult<List<TurkishEvent>> ReadJson()
        {
            List<TurkishEvent> turkishEvent = JsonHelper<TurkishEvent>.LoadJson(url);
            return new SuccessDataResult<List<TurkishEvent>>(turkishEvent, Messages.ListingFromSourceSuccessful);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ITurkishEventService.Get")]
        public IResult AddingDataInJson()
        {
            List<TurkishEvent> turkishEvent = JsonHelper<TurkishEvent>.LoadJson(url);
            _turkishEventDal.AddRange(turkishEvent);
            return new SuccessResult(Messages.AddedDataFromSourceSuccessfull);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ITurkishEventService.Get")]
        public IResult RemovingAllData()
        {
            List<TurkishEvent> turkishEvent = _turkishEventDal.GetAll();
            _turkishEventDal.RemoveRange(turkishEvent);
            return new SuccessResult(Messages.DeletedDataFromSourceSuccessful);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ITurkishEventService.Get")]
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
