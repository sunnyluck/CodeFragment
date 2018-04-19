using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationTest.DataAccessLayer;
using WebApplicationTest.Models;

namespace WebApplicationTest.ViewModels
{
    public class UserBusinessLayer
    {
        public List<User> GetUserList()
        {
            var dbEfOperation = new DbEfOperation();
            return dbEfOperation.UserList.ToList();
        }

        public User SaveUser(User user)
        {
            var dbEfOperation = new DbEfOperation();
            dbEfOperation.UserList.Add(user);
            dbEfOperation.SaveChanges();
            return user;
        }
    }
}