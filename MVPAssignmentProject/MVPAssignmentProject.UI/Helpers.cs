using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVPAssignmentProject.Infrastructure.DatabaseContext;

namespace MVPAssignmentProject.UI
{
    public static class Helpers
    {
        public class SelectListModelFunctionClass
        {
            public int Id { get; set; }
          
            public string Title { get; set; }
        }

        public static SelectList GetPropertyStatusDd()
        {
            using (MVPAssignmentDbContext db = new MVPAssignmentDbContext())
            {
                List<SelectListItem> ddlist = new List<SelectListItem>();
                var collection = db.Database.SqlQuery<SelectListModelFunctionClass>(@"select PropertyTypeId as Id, TypeName as Title From PropertyTypes").ToList();
                ddlist.Add(new SelectListItem { Text = "--Select--", Value = "0" });
                foreach (var item in collection)
                {

                    ddlist.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
                }

                return new SelectList(ddlist.ToList(), "Value", "Text");
            }
        }

        [Authorize]
        public static Guid GetCurrentUser()
        {

            try
            {
                var user = HttpContext.Current.User.Identity.GetUserId();

                Guid CurrentUserid = new Guid(user);
                return CurrentUserid;

            }
            catch (Exception)
            {

                return new Guid();
            }

        }

        public static int GetCurrentLoginBrokerId()
        {

            int brokerId = 0;
            Guid userId = GetCurrentUser();
            using (MVPAssignmentDbContext db = new MVPAssignmentDbContext())
            {
                brokerId = db.Database.SqlQuery<int>("select isnull(BrokerId,0) as BrokerId From AspNetUsers where id=@id", new SqlParameter("@id", userId))
                    .FirstOrDefault();

            }

            return brokerId;
        }


    }
}