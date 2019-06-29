using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OSMTilesDownloader.Helper
{
    public class Utilities
    {
        public static String nameof<T>(Expression<Func<T>> name)
        {
            MemberExpression expressionBody = (MemberExpression)name.Body;
            return expressionBody.Member.Name;
        }
    }
}
