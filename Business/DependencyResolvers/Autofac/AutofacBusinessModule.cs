﻿using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TurkishEventManager>().As<ITurkishEventService>();
            builder.RegisterType<EfTurkishEventDal>().As<ITurkishEventDal>();

            builder.RegisterType<ItalianEventManager>().As<IItalianEventService>();
            builder.RegisterType<EfItalianEventDal>().As<IItalianEventDal>();
        }
    }
}