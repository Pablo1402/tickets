using Business.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public static class DbInitializer
    {
        public static void ExecuteInitializer(this TicketupContext context)
        {
            if (!context.UserTypes.ToList().Any())
            {
                context.UserTypes.Add(new Business.Entities.UserType(UserTypeEnum.USER.ToString()));
                context.UserTypes.Add(new Business.Entities.UserType(UserTypeEnum.SYSTEM.ToString()));
                context.UserTypes.Add(new Business.Entities.UserType(UserTypeEnum.CLIENT.ToString()));
                context.UserTypes.Add(new Business.Entities.UserType(UserTypeEnum.ADMIN.ToString()));
                context.SaveChanges();
            }

            if (!context.StorePlans.ToList().Any())
            {
                context.StorePlans.Add(new Business.Entities.StorePlan(StorePlanEnum.FULL.ToString(),true));
                context.StorePlans.Add(new Business.Entities.StorePlan(StorePlanEnum.TRIAL.ToString(),true));
                context.StorePlans.Add(new Business.Entities.StorePlan(StorePlanEnum.BASIC.ToString(),true));
                context.StorePlans.Add(new Business.Entities.StorePlan(StorePlanEnum.STANDARD.ToString(),true));
                context.StorePlans.Add(new Business.Entities.StorePlan(StorePlanEnum.EXPERT.ToString(),true));
                context.SaveChanges();
            }

            if (!context.Stores.ToList().Any())
            {
                context.Stores.Add(new Business.Entities.Store()
                {
                    Active = true,
                    CreateDate = DateTime.Now,
                    Email = "systemstore@ticketup.com",
                    Name ="System Store",
                    Image ="image",
                    StorePlanId = context.StorePlans.FirstOrDefault(x => x.Name == StorePlanEnum.FULL.ToString()).Id
                });
                context.SaveChanges();
            }
            if (!context.Users.ToList().Any())
            {
                var user = new Business.Entities.User(context.UserTypes.FirstOrDefault(x => x.Name == UserTypeEnum.SYSTEM.ToString()).Id
                    ,"System User"
                    ,"system.user"
                    ,"systemuser@ticketup.com"
                    ,"123456");
                user.setDateCreate(DateTime.Now);
                user.setStoreId(context.Stores.FirstOrDefault(x => x.Name == "System Store").Id);
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
