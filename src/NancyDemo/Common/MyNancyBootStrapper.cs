using NancyDemo.Data;
using NancyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo
{
    public class MyNancyBootStrapper : Nancy.DefaultNancyBootstrapper
    {        
        protected override void ConfigureApplicationContainer(
            Nancy.TinyIoc.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);            
        }

        protected override void ConfigureRequestContainer(
            Nancy.TinyIoc.TinyIoCContainer container, Nancy.NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Register<IDinnerService>(new DinnerService());
        }
    }
}
