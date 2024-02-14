using MVPAssignmentProject.Infrastructure.DatabaseContext;
using MVPAssignmentProject.Infrastructure.Services;
using MVPAssignmentProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVPAssignmentProject.Domain.Model;
using System.Threading.Tasks;
using MVPAssignmentProject.UI.Models;

namespace MVPAssignmentProject.UI.Controllers
{
    public class BrokerRegisterController : Controller
    {
        private readonly IBroker _iBroker;

        public BrokerRegisterController()
        {
            this._iBroker = new BrokerService(new MVPAssignmentDbContext());
        }
        // GET: BrokerRegister
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(BrokerDetails brokerDetails)
        {
            int brokerId = await _iBroker.Insert(brokerDetails);
            var controller = DependencyResolver.Current.GetService<AccountController>();
            controller.ControllerContext = new ControllerContext(this.Request.RequestContext, controller);
            var model = new RegisterViewModel
            {
                ConfirmPassword = brokerDetails.ConfirmPassword,
                Password = brokerDetails.Password,
                Email = brokerDetails.Email,
                BrokerId = brokerId
            };
            if (brokerId > 0)
            {
                var result = await controller.Register(model);
            }
            
            return RedirectToAction("Index","Home");
        }


    }
}