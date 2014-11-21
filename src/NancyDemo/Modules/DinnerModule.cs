using Nancy;
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
        public DinnerModule(IMyContext ctx)
            : base("/dinner")
        {
            Get["/"] = x =>
            {
                return Response.AsJson<object>(ctx.Dinners.ToArray());
            };

            Post["/"] = _ =>
            {
                Dinner dinner = this.Bind<Dinner>();

                ctx.Dinners.Add(dinner);
                ctx.SaveChanges();

                return HttpStatusCode.OK;
            };

            Put["/{id:int}"] = parameters =>
            {
                Dinner dinner = this.Bind<Dinner>();

                dinner.Id = parameters.id;
                ctx.Dinners.Attach(dinner);
                ctx.Entry(dinner).State = EntityState.Modified;
                ctx.SaveChanges();

                return HttpStatusCode.OK;
            };

            Delete["/{id:int}"] = x =>
            {
                var dinner = new Dinner() { Id = x.id };
                ctx.Entry(dinner).State = EntityState.Deleted;

                ctx.SaveChanges();

                return HttpStatusCode.OK;
            };
        }
    }
}
