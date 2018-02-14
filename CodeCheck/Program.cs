using System;
using ItemCore;
using System.Collections.Generic;
using System.Linq;
using CommonLib;

namespace CodeCheck
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CheckOrderBy();
        }

        private static void CheckOrderBy()
        {
            var list = new List<MyModel>();
            for (var i = 0; i < 20; i++)
            {
                list.Add(new MyModel()
                {
                    CreatedAt = DateTime.Now,
                    Id = i + 1,
                    OrderNumber = i,
                    Name = Char.ConvertFromUtf32(i)
                });
            }
            var query = list.AsQueryable();
            query = query.Where(s => !string.IsNullOrEmpty(s.Name));
            query = query.OrderIf(s => s.OrderNumber, OrderByStatus.Desc, true)
                .OrderIf(s => s.CreatedAt, OrderByStatus.Asc, true);
            query = query.Where(s => s.CreatedAt.HasValue);
            Console.WriteLine(query.ContainOrderBy());
            Console.ReadLine();
        }
    }
}