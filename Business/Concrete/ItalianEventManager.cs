using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ItalianEventManager : IItalianEventService
    {
        string url = "https://s3.us-west-2.amazonaws.com/secure.notion-static.com/8febcaa6-c2f8-4fab-b05b-141bafe4d344/1d6a2360.json?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAT73L2G45O3KS52Y5%2F20210623%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20210623T170106Z&X-Amz-Expires=86400&X-Amz-Signature=cf833ae4dbbc3b258aef972b2c1ba9a394f571cb3d6960d2f22bcc3e534783d5&X-Amz-SignedHeaders=host&response-content-disposition=filename%20%3D\"1d6a2360.json\"";
        IItalianEventDal _italianEventDal;

        public ItalianEventManager(IItalianEventDal italianEventDal)
        {
            _italianEventDal = italianEventDal;
        }

        [SecuredOperation("admin,data.add")]
        [ValidationAspect(typeof(ItalianEventValidator))]
        [CacheRemoveAspect("ITurkishEventService.Get")]
        public IResult Add(ItalianEvent italianEvent)
        {
            IResult result = BusinessRules.Run
                (
                    DataCountExceeded()
                );

            if (result != null)
            {
                return result;
            }

            _italianEventDal.Add(italianEvent);
            return new SuccessResult(Messages.AddedDataFromDatabaseSuccessfull);
        }

        [SecuredOperation("admin,data.add")]
        [ValidationAspect(typeof(ItalianEventValidator))]
        [CacheRemoveAspect("ITurkishEventService.Get")]
        public IResult Update(ItalianEvent italianEvent)
        {
            _italianEventDal.Update(italianEvent);
            return new SuccessResult(Messages.UpdatedDataFromDatabaseSuccessful);
        }

        [SecuredOperation("admin,data.add")]
        [CacheRemoveAspect("ITurkishEventService.Get")]
        public IResult Delete(ItalianEvent italianEvent)
        {
            _italianEventDal.Delete(italianEvent);
            return new SuccessResult(Messages.DeletedDataFromDatabaseSuccessfull);
        }

        [CacheAspect]
        public IDataResult<List<ItalianEvent>> GetAll()
        {
            return new SuccessDataResult<List<ItalianEvent>>(_italianEventDal.GetAll(), Messages.ListingFromDatabaseSuccessful);
        }

        [CacheAspect]
        public IDataResult<List<ItalianEvent>> GetAllByCategory(string categoryName)
        {
            return new SuccessDataResult<List<ItalianEvent>>(_italianEventDal.GetAll(e => e.dc_Categoria == categoryName), Messages.ListingFromDatabaseSuccessful);
        }

        [CacheAspect]
        public IDataResult<List<ItalianEvent>> GetAllByTime(string time)
        {
            return new SuccessDataResult<List<ItalianEvent>>(_italianEventDal.GetAll(e => e.dc_Orario == time), Messages.ListingFromDatabaseSuccessful);
        }

        [CacheAspect]
        public IDataResult<ItalianEvent> GetById(int id)
        {
            return new SuccessDataResult<ItalianEvent>(_italianEventDal.Get(e => e.ID == id), Messages.ListingFromDatabaseSuccessful);
        }

        [CacheAspect(5)]
        //[PerformanceAspect(4)]
        public IDataResult<List<ItalianEvent>> ReadJson()
        {
            List<ItalianEvent> italianEvent = JsonHelper<ItalianEvent>.LoadJson(url);
            return new SuccessDataResult<List<ItalianEvent>>(italianEvent, Messages.ListingFromSourceSuccessful);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ITurkishEventService.Get")]
        public IResult AddingDataInJson()
        {
            List<ItalianEvent> italianEvent = JsonHelper<ItalianEvent>.LoadJson(url);
            _italianEventDal.AddRange(italianEvent);
            return new SuccessResult(Messages.AddedDataFromSourceSuccessfull);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ITurkishEventService.Get")]
        public IResult RemovingAllData()
        {
            List<ItalianEvent> italianEvent = _italianEventDal.GetAll();
            _italianEventDal.RemoveRange(italianEvent);
            return new SuccessResult(Messages.DeletedDataFromSourceSuccessful);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ITurkishEventService.Get")]
        public IResult UpdatingDataJson()
        {
            List<ItalianEvent> italianEvent = JsonHelper<ItalianEvent>.LoadJson(url);
            _italianEventDal.RemoveRange(italianEvent);
            return new SuccessResult(Messages.UpdatedDataFromSourceSuccessful);
        }

        private IResult DataCountExceeded()
        {
            var result = _italianEventDal.GetAll();
            if (result.Count > 15000)
            {
                return new ErrorResult(Messages.DataCountExceeded);
            }
            return new SuccessResult();
        }

    }
}
