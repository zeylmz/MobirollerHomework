using Business.Abstract;
using Business.Constant;
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
        string url = "https://s3.us-west-2.amazonaws.com/secure.notion-static.com/8febcaa6-c2f8-4fab-b05b-141bafe4d344/1d6a2360.json?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAT73L2G45O3KS52Y5%2F20210620%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20210620T222517Z&X-Amz-Expires=86400&X-Amz-Signature=801697f99b9a3d9260ecf40cb02eeb805cef8f450ab3381a066b99c0cc4d60a7&X-Amz-SignedHeaders=host&response-content-disposition=filename%20%3D\"1d6a2360.json\"";
        IItalianEventDal _italianEventDal;

        public ItalianEventManager(IItalianEventDal italianEventDal)
        {
            _italianEventDal = italianEventDal;
        }

        public IResult Add(ItalianEvent italianEvent)
        {
            _italianEventDal.Add(italianEvent);
            return new SuccessResult(Messages.AddedDataFromDatabaseSuccessfull);
        }

        public IResult Update(ItalianEvent italianEvent)
        {
            _italianEventDal.Update(italianEvent);
            return new SuccessResult(Messages.UpdatedDataFromDatabaseSuccessful);
        }

        public IResult Delete(ItalianEvent italianEvent)
        {
            _italianEventDal.Delete(italianEvent);
            return new SuccessResult(Messages.DeletedDataFromDatabaseSuccessfull);
        }

        public IDataResult<List<ItalianEvent>> GetAll()
        {
            return new SuccessDataResult<List<ItalianEvent>>(_italianEventDal.GetAll(), Messages.ListingFromDatabaseSuccessful);
        }

        public IDataResult<List<ItalianEvent>> GetAllByCategory(string categoryName)
        {
            return new SuccessDataResult<List<ItalianEvent>>(_italianEventDal.GetAll(e => e.dc_Categoria == categoryName), Messages.ListingFromDatabaseSuccessful);
        }

        public IDataResult<List<ItalianEvent>> GetAllByTime(string time)
        {
            return new SuccessDataResult<List<ItalianEvent>>(_italianEventDal.GetAll(e => e.dc_Orario == time), Messages.ListingFromDatabaseSuccessful);
        }

        public IDataResult<ItalianEvent> GetById(int id)
        {
            return new SuccessDataResult<ItalianEvent>(_italianEventDal.Get(e => e.ID == id), Messages.ListingFromDatabaseSuccessful);
        }

        public IDataResult<List<ItalianEvent>> ReadJson()
        {
            List<ItalianEvent> italianEvent = JsonHelper<ItalianEvent>.LoadJson(url);
            return new SuccessDataResult<List<ItalianEvent>>(italianEvent, Messages.ListingFromSourceSuccessful);
        }

        public IResult AddingDataInJson()
        {
            List<ItalianEvent> italianEvent = JsonHelper<ItalianEvent>.LoadJson(url);
            _italianEventDal.AddRange(italianEvent);
            return new SuccessResult(Messages.AddedDataFromSourceSuccessfull);
        }

        public IResult RemovingDataInJson()
        {
            List<ItalianEvent> italianEvent = JsonHelper<ItalianEvent>.LoadJson(url);
            _italianEventDal.RemoveRange(italianEvent);
            return new SuccessResult(Messages.DeletedDataFromSourceSuccessful);
        }

        public IResult UpdatingDataJson()
        {
            List<ItalianEvent> italianEvent = JsonHelper<ItalianEvent>.LoadJson(url);
            _italianEventDal.RemoveRange(italianEvent);
            return new SuccessResult(Messages.UpdatedDataFromSourceSuccessful);
        }
    }
}
