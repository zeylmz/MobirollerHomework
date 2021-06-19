using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITurkishEventService
    {
        IDataResult<List<TurkishEvent>> GetAll();
        IDataResult<List<TurkishEvent>> GetAllByCategory(string categoryName);
        IDataResult<List<TurkishEvent>> GetAllByTime(string time);
        IDataResult<TurkishEvent> GetById(int id);
        IDataResult<List<TurkishEvent>> ReadJson();
        IResult Add(TurkishEvent turkishEvent);
        IResult Delete(TurkishEvent turkishEvent);
        IResult Update(TurkishEvent turkishEvent);
        IResult AddingDataInJson();
        IResult RemovingDataInJson();
        IResult UpdatingDataJson();
    }
}
