﻿using Nancy;
using Nancy.ModelBinding;
using NancyDemo.Data;
using NancyDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo
{
    public class DinnerModule : NancyModule
    {
        public DinnerModule(IDinnerService svc)
            : base("/dinner")
        {
            Get["/"] = x =>
            {
                return Response.AsJson<object>(svc.GetAll());
            };

            Post["/"] = _ =>
            {
                Dinner dinner = this.Bind<Dinner>();
                svc.Create(dinner);
                return HttpStatusCode.OK;
            };

            Put["/{id:int}"] = parameters =>
            {
                Dinner dinner = this.Bind<Dinner>();
                dinner.Id = parameters.id;
                svc.Update(dinner);

                return HttpStatusCode.OK;
            };

            Delete["/{id:int}"] = x =>
            {
                svc.Delete(x.id);
                return HttpStatusCode.OK;
            };
        }
    }
}
