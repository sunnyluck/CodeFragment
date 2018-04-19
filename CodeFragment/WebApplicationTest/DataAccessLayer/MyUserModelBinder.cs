
using System;
using System.Web.Mvc;
using WebApplicationTest.Models;

namespace WebApplicationTest.DataAccessLayer
{
    public class MyUserModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var user = new User();
            user.FirstName = controllerContext.RequestContext.HttpContext.Request.Form["FirstName"];
            user.LastName = controllerContext.RequestContext.HttpContext.Request.Form["LastName"];
            return user;
        }
    }
}