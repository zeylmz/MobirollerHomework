using Core.DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IItalianEventDal : IEntityRepository<ItalianEvent>
    {
        void AddRange(List<ItalianEvent> italianEvents);
    }
}
