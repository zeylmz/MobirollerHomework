﻿using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTurkishEventDal : EfEntityRepositoryBase<TurkishEvent, MyHomeworkContext>, ITurkishEventDal
    {
    }
}
