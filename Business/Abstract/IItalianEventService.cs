using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IItalianEventService
    {
        IDataResult<List<ItalianEvent>> GetAll();
        IDataResult<List<ItalianEvent>> GetAllByCategory(string categoryName);
        IDataResult<List<ItalianEvent>> GetAllByTime(string time);
        IDataResult<ItalianEvent> GetById(int id);
        IDataResult<List<ItalianEvent>> ReadJson();
        IResult Add(ItalianEvent italianEvent);
        IResult Delete(ItalianEvent italianEvent);
        IResult Update(ItalianEvent italianEvent);
        IResult AddingDataInJson();
        IResult RemovingAllData();
        IResult UpdatingDataJson();
    }
}
