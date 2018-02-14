using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public enum OrderByStatus
    {
        Asc,
        Desc
    }

    public static class OrderByHelper
    {
        public static IOrderedQueryable<T> OrderIf<T, Tkey>(this IQueryable<T> source, Expression<Func<T, Tkey>> order, OrderByStatus status, bool isEnable)

        {
            IOrderedQueryable<T> result = null;
            if (source == null || order == null) return null;
            if (isEnable)
            {
                if (source.ContainOrderBy())
                {
                    result = status == OrderByStatus.Asc ? ((IOrderedQueryable<T>) source).ThenBy(order) : ((IOrderedQueryable<T>) source).ThenByDescending(order);
                }
                else
                {
                    result = status == OrderByStatus.Asc ? source.OrderBy(order) : source.OrderByDescending(order);
                }
            }
            else
            {
                result = (source as IOrderedQueryable<T>);
            }
            return result;
        }

        /// <summary>
        /// 判断里面是否已经调用过 OrderBy、OrderByDescending 这两个函数否，  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool ContainOrderBy<T>(this IQueryable<T> source)
        {
            bool result = false;
            var expression = source.Expression;
            if (expression.NodeType == ExpressionType.Call)
            {
                result = FindIOrderedQueryable(expression as MethodCallExpression);
            }
            return result;
        }

        /// <summary>
        /// 递归子项找到 OrderBy、OrderByDescending 这两个函数的调用，  
        /// 其中一个子项有，就返回 True，都没有的话，就返回 False  
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static bool FindIOrderedQueryable(MethodCallExpression expression)
        {
            var result = false;
            if (expression.Method.Name != "OrderBy" && expression.Method.Name == "OrderByDescending")
            {
                result = true;
            }
            else
            {
                foreach (var item in expression.Arguments)
                {
                    if (item.NodeType == ExpressionType.Call)
                    {
                        result = FindIOrderedQueryable(item as MethodCallExpression);
                        if (result) break;
                    }
                }
            }
            return result;
        }
    }
}
