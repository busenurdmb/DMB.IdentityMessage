using DMB.IdentityMessage.BusinessLayer.Abstract;
using DMB.IdentityMessage.BusinessLayer.Concrete;
using DMB.IdentityMessage.DataAccessLayer.Abstract;
using DMB.IdentityMessage.DataAccessLayer.Context;
using DMB.IdentityMessage.DataAccessLayer.EfEntityFramework;
using DMB.IdentityMessage.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DMB.IdentityMessage.BusinessLayer
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IMailService, MailManager>();
            services.AddScoped<IMailDal, EfMailDal>();
            services.AddDbContext<DMBContext>();

            



        }
    }
}
