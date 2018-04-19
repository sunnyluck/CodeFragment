using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationTest.DataAccessLayer;
using WebApplicationTest.Models;
using WebApplicationTest.ViewModels;

namespace WebApplicationTest.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult Index()
        {
            var userListViewModel = new UserListViewModel();
            var userBal = new UserBusinessLayer();
            var userList = userBal.GetUserList();

            var userViewModels = new List<UserViewModel>();

            foreach (var item in userList)
            {
                var userViewModel = new UserViewModel();
                userViewModel.FirstName = item.FirstName;
                userViewModel.LastName = item.LastName;
                if (string.IsNullOrEmpty(item.LastName))
                    userViewModel.Color = "red";
                else
                    userViewModel.Color = "green";
                userViewModels.Add(userViewModel);
            }
            userListViewModel.UserList = userViewModels;
            return View(userListViewModel);
        }

        public ActionResult AddNew()
        {
            return View("CreateUser", new CreateUserViewModel());
            //return View("CreateUser");
        }

        public ActionResult SaveUser(User user, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save User":
                    if (ModelState.IsValid)
                    {
                        var userBal = new UserBusinessLayer();
                        userBal.SaveUser(user);
                        return this.RedirectToAction("Index");
                        //return Content(string.Concat(user.FirstName, "|", user.LastName));
                    }
                    else
                    {
                        var vm = new CreateUserViewModel();
                        vm.FirstName = user.FirstName;
                        if (!string.IsNullOrEmpty(user.LastName))
                            vm.LastName = user.LastName;
                        else
                            vm.LastName = ModelState["LastName"].Value.AttemptedValue;
                        return View("CreateUser", vm);                        
                        //return View("CreateUser");
                    }
                case "Cancel":
                    return this.RedirectToAction("Index");
                default:
                    break;
            }
            return new EmptyResult();
        }

        /// <summary>
        /// 创建自定义 Model Binder ，代替默认的ModelBinder：
        /// </summary>
        /// <param name="user"></param>
        /// <param name="BtnSubmit"></param>
        /// <returns></returns>
        //public ActionResult SaveUser([ModelBinder(typeof(MyUserModelBinder))]User user, string BtnSubmit)
        //{
        //    switch (BtnSubmit)
        //    {
        //        case "Save User":
        //            return Content(string.Concat(user.FirstName, "|", user.LastName));
        //        case "Cancel":
        //            return this.RedirectToAction("Index");
        //        default:
        //            break;
        //    }
        //    return new EmptyResult();
        //}
    }
}