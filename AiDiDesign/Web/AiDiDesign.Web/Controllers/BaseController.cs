namespace AiDiDesign.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using AiDiDesign.Data;
    using AiDiDesign.Data.Models;

    public class BaseController : Controller
    {
        protected IAiDiDesignData data;

        public BaseController(IAiDiDesignData data)
        {
            this.data = data;
        }

        public BaseController()
            : this(new AiDiDesignData())
        {
        }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.data.Users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}